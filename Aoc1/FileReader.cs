namespace Aoc1
{
    public class FileReader
    {
        public string[] ReadLinesFromFile(string path)
        {
            return (File.ReadAllLines(path));
        }
    }

}


