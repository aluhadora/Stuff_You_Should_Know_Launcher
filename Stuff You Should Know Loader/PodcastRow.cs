using System.Net;
using System.Windows.Forms;

namespace Stuff_You_Should_Know_Loader
{
  public partial class PodcastRow : UserControl
  {
    public Podcast Podcast;

    public PodcastRow()
    {
      InitializeComponent();
    }

    public void Populate(Podcast podcast)
    {
      Podcast = podcast;
      titleLabel.Text = podcast.Title;
      dateLabel.Text = podcast.Date;
      descriptionLabel.Text = podcast.Description;
    }

    public void GetImage(WebClient web)
    {
      Podcast.PopulateImage(web);
      pictureBox.BackgroundImage = Podcast.Image;
    }

    private void PodcastRow_Load(object sender, System.EventArgs e)
    {
      foreach (Control control in Controls)
      {
        control.Click += PodcastRow_Click;
      }
    }

    private void PodcastRow_Click(object sender, System.EventArgs e)
    {
      this.InvokeOnClick(this, e);
    }
  }
}
