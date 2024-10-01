namespace CS212;

public class Program
{
    public static void Main(string[] args)
    {
        // Reading CSV data
        var csvReader = new CsvReader("students.csv");
        var csvData = csvReader.ReadData();

        // Parsing student data
        var studentParser = new StudentParser();
        var students = studentParser.ParseStudents(csvData);

        // Simulate API post for each student
        foreach (var student in students)
        {
            student.SimulateApiPost();
            Console.WriteLine("\n");
        }
    }
}
