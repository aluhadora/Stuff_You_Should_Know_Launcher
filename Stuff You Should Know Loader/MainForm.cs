using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Stuff_You_Should_Know_Loader
{
  public partial class MainForm : Form
  {
    private WebClient _web;
    private const int RowHeight = 70;


    public MainForm()
    {
      InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      _web = new WebClient();

      var podcasts = GetBasicPodcasts();
      int borderWidth = (Width - ClientSize.Width) / 2;
      int titlebarHeight = Height - ClientSize.Height - 2 * borderWidth;
      Height = Math.Max(Height, (podcasts.Count() + 2) * RowHeight + titlebarHeight);

      new Thread(() => Go(podcasts)).Start();
    }

    private void Go(IEnumerable<Podcast> podcasts)
    {
      MakeRows(podcasts);

      Invoke(new Action(GetImages));
    }

    private void GetImages()
    {
      foreach (PodcastRow control in Controls)
      {
        control.Invoke(new Action<WebClient>(control.GetImage), _web);
      }
    }

    private void MakeRows(IEnumerable<Podcast> podcasts)
    {
      int y = 0;

      foreach (var podcast in podcasts)
      {
        //PopulatePodcast(podcast);
        MakeRow(y, podcast);

        y += RowHeight;
      }
    }

    private void MakeRow(int y, Podcast podcast)
    {
      if (InvokeRequired)
      {
        BeginInvoke(new Action<int, Podcast>(MakeRow), y, podcast);
        return;
      }

      var control = new PodcastRow
      {
        Top = y, Left = 0,
      };
      control.Populate(podcast);
      control.Click += RowClick;

      Controls.Add(control);
    }

    private void RowClick(object sender, EventArgs e)
    {
      var control = (PodcastRow) sender;

      var newSource = _web.DownloadString(control.Podcast.URL);
      const string reg = "(?<=<!--<div>PLAY: )(.+)(?=)</div>-->";
      string mp3URL = Regex.Match(newSource, reg, RegexOptions.Singleline).Groups[0].Value;
      mp3URL = mp3URL.Substring(0, mp3URL.IndexOf("<"));

      Process.Start(@"C:\Program Files (x86)\VideoLAN\VLC\vlc.exe", "-Iskins \"" + mp3URL + "\"");
      Close();
    }

    public string FeaturedTableSource()
    {
      string source = _web.DownloadString(@"http://www.stuffyoushouldknow.com/podcasts/");
      const string reg = "(?<=<div id=\"podcast_recent_header\">Most Recent Episodes</div>)(.*)(?=index:99999999999;)";
      return Regex.Match(source, reg, RegexOptions.Singleline).Groups[0].Value;
    }

    private IEnumerable<string> FeaturedRows()
    {
      var tableSource = FeaturedTableSource();

      const string reg = "(?<=<span class=\"fw_grey caption\"><p class=\"post_date_only\">).*?(?=<div class=\"post-edit\"></div>)";

      var lastIndex = 0;
      var rows = new List<string>();
      Group @group = Regex.Match(tableSource.Substring(lastIndex), reg, RegexOptions.Singleline).Groups[0];
      do
      {
        var capture = @group.Captures[0];
        lastIndex += capture.Index;
        rows.Add(capture.Value);
        @group = Regex.Match(tableSource.Substring(lastIndex), reg, RegexOptions.Singleline).Groups[0];

      } while (@group.Captures.Count > 0);

      return rows;
    }

    private IEnumerable<Podcast> GetBasicPodcasts()
    {
      var players = new List<Podcast>();
      var rows = FeaturedRows();
      const string urlReg = "(?<=<a href=\").*?(?=\" title)";
      const string imageReg = "(?<=src=\").*?(?=\" class)";
      const string descriptionReg = "(?<=<p>).*?(?=</p>)";
      
      foreach (var row in rows)
      {
        var workingRow = row;
        var date = workingRow.Substring(0, workingRow.IndexOf("<", StringComparison.CurrentCulture));
        var url = Regex.Match(workingRow, urlReg, RegexOptions.Singleline).Groups[0].Value;
        workingRow = workingRow.Substring(workingRow.IndexOf(url, StringComparison.CurrentCulture) + url.Length + 9);
        var title = workingRow.Substring(0, workingRow.IndexOf("\""));
        var imageURL = Regex.Match(workingRow, imageReg, RegexOptions.Singleline).Groups[0].Value;
        var description = Regex.Match(workingRow, descriptionReg, RegexOptions.Singleline).Groups[0].Value;
        description = FixString(description);
        title = FixString(title);

        players.Add(new Podcast
        {
          Date = date,
          URL = url,
          Title = title,
          ImageURL = imageURL,
          Description = description,
        });
      }

      return players;
    }

    private string FixString(string value)
    {
      value = value.Replace("â€™", "'");
      value = value.Replace("&#8217;", "'");
      return value;
    }
  }
}
