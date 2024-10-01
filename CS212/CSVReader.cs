namespace CS212;

public class CsvReader(string csvFile)
{
    public List<string[]> ReadData()
    {
        var data = new List<string[]>();
        const string csvSplitBy = ",";

        // Read everything, including the header row:
        try
        {
            using var reader = new StreamReader(csvFile);
            while (reader.ReadLine() is { } line)
            {
                var row = line.Split(csvSplitBy);
                data.Add(row);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error reading CSV file: {e.Message}");
        }

        return data;
    }
}
