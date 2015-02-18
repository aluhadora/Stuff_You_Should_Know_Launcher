using System.Drawing;
using System.IO;
using System.Net;

namespace Stuff_You_Should_Know_Loader
{
  public class Podcast
  {
    public string Title { get; set; }
    public string URL { get; set; }
    public string Date { get; set; }
    public string ImageURL { get; set; }
    public string Row { get; set; }
    public string Description { get; set; }

    public Image Image { get; set; }

    public void PopulateImage(WebClient web)
    {
      Stream stream = web.OpenRead(ImageURL);
      if (stream == null) return;
      Image = new Bitmap(stream);
    }
  }
}
