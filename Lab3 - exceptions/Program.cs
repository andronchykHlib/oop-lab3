var files = Enumerable.Range(10, 20).ToArray();
string filesFolder = "../../../files/";

foreach (var fileName in files)
{
    string fileNameWithExtension = $"{fileName}.txt";
    try
    {
        string[] content = File.ReadAllText($"{filesFolder}{fileNameWithExtension}").Split('\n');
        int n1 = int.Parse(content[0]);
        int n2 = int.Parse(content[1]);
        int sum = n1 + n2;
        int mid = (n1 + n2) / 2;
        Console.WriteLine($"{sum}/{mid}");
    }
    catch (FileNotFoundException e)
    {
        WriteInFile("no_file.txt", fileNameWithExtension);
    }
    catch (FormatException e)
    {
        WriteInFile("bad_data.txt", fileNameWithExtension);
    }
    catch (OverflowException e)
    {
        WriteInFile("overflow.txt", fileNameWithExtension);
    }
}


void WriteInFile(string path, string fileName) {
    try
    {
        if (!File.Exists(path))
        {
            using FileStream fs = File.Create(path);
        }

        using (StreamWriter sw = new StreamWriter(path, true))
        {
            sw.WriteLine(fileName);
        }
    }
    catch (IOException e)
    {
        throw new Exception("Can't use file");
    }
}