using System.IO;
using System.Text;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
 
namespace Vocab
{
  static class Program
  {
    static void Main(string[] args)
    {
      CreateCSV(args[0]);      
    }
 
    static void CreateCSV(string directory)
    {
      using (var stream = new StreamWriter("vocab.csv", false, Encoding.UTF8))
      {
        foreach (var f in new DirectoryInfo(directory).GetFiles())
        {
          using (var so = ShellObject.FromParsingName(f.FullName))
          {
            //
            // The Title property contains the vocabulary separated by " - "
            //
            var title = so.Properties.GetProperty(SystemProperties.System.Title).ValueAsObject.ToString();
            var index = title.IndexOf(" - ");
            var left = title.Substring(0, index - 1);
            var right = title.Substring(index + 3);
            //
            // The Album property stores the category (e.g. Food and Drink).
            //
            var category = so.Properties.GetProperty(SystemProperties.System.Music.AlbumTitle).ValueAsObject.ToString().Substring(3);
            //
            // The Artist property stores the type of vocabulary (verb, noun, ...).
            //
            var kind = so.Properties.GetProperty(SystemProperties.System.Music.DisplayArtist).ValueAsObject.ToString();
 
            var line = string.Format("{0};{1};{2};{3}", left, right, category, kind);
            stream.WriteLine(line);
          }
        }
      }
    }
  }
}