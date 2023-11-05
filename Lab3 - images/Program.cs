using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

string imagesFolder = "../../../images";

string[] fileNames = Directory.GetFiles(imagesFolder);

foreach (var fileName in fileNames)
{
    Regex regexExtenstionForImage = new Regex(@"\.(bmp|gif|tiff|jpeg|jpg|png)$", RegexOptions.IgnoreCase);
    string fileExtension = Path.GetExtension(fileName);

    if (regexExtenstionForImage.IsMatch(fileExtension))
    {
        try
        {
            Console.WriteLine(fileName);
            string fileNameNoExtension = Regex.Replace(fileName, @"\.\w+$", "");
            Bitmap image = new Bitmap(fileName);
            image.RotateFlip(RotateFlipType.Rotate180FlipX);
            image.Save($"{fileNameNoExtension}-mirrored.gif");
        }
        catch (Exception e)
        {
            MessageBox.Show("Can't read image bitmap.");
            throw;
        }
    }
}
