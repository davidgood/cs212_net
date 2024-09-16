namespace CS212;

using System.IO;

public class Program {

    public static void Main(String[] args) {
        var students = new List<Student>();
        var assignments = new List<Assignment>();

        // Read grades from a CSV file
        string csvFile = "/Users/davidgood/projects/csharp/CS212/students.csv"; 
        string line;
        string csvSplitBy = ",";
        
        try  {
            using var reader = new StreamReader(csvFile);
            
            // Read header line to extract assignment names
            if ((line = reader.ReadLine()) != null) {
                string[] headers = line.Split(csvSplitBy);
                for (int i = 1; i < headers.Length; i++) { // Skip the first column which is student name
                    assignments.Add(new Assignment(headers[i], 100, "2024-09-30")); // Assign a dummy due date
                }
            }

            // Read each student's grades
            while ((line = reader.ReadLine()) != null) {
                string[] values = line.Split(csvSplitBy);
                string studentName = values[0];
                string studentId = "S" + (students.Count + 1);

                Student student = new Student(studentName, studentId);
                students.Add(student);

                for (int i = 1; i < values.Length; i++) { // Skip the first column which is student name
                    int grade = int.Parse(values[i]);
                    student.addGrade(assignments[i - 1], grade);
                }
            }
        } catch (IOException e) {
            Console.WriteLine(e.StackTrace);
        }

        // Calculate and display the average grade for each assignment
        foreach (var assignment in assignments) {
            double averageGrade = calculateAverageGrade(students, assignment);
            Console.WriteLine($"Average grade for {assignment.getName()} : {averageGrade}");
        }

        // Simulate API interaction
        foreach (Student student in students) {
            student.simulateAPIPost();
        }

        // Sort students by average grade and display the sorted list
        students = students.OrderBy(student => student.calculateAverageGrade()).ToList();      
        Console.WriteLine("Students sorted by average grade:");
        foreach (Student student in students) {
            Console.WriteLine(student.getName() + ": " + student.calculateAverageGrade());
        }
    }

    public static double calculateAverageGrade(List<Student> students, Assignment assignment) {
        double total = 0;
        int count = 0;
        foreach (Student student in students) {
            int? grade = student.getGrade(assignment);
            if (grade != null) {
                total += grade.Value;
                count++;
            }
        }
        return count > 0 ? total / count : 0;
    }
}