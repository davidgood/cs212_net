namespace CS212;

public class StudentParser
{
    private readonly Dictionary<AssignmentType, List<Assignment>> _assignmentMap = new();
    private readonly List<Assignment> _assignments = []; // Store assignments here

    public StudentParser()
    {
        // Create a mapping of AssignmentTypes to hold the assignments when they're parsed:
        foreach (var type in Enum.GetValues<AssignmentType>())
        {
            _assignmentMap[type] = []; // Initialize each assignment type
        }
    }

    public List<Student> ParseStudents(List<string[]> csvData)
    {
        var students = new List<Student>();
        var id = 0;

        // Parse header row (assignment names only)
        ParseHeaderRow(csvData[0]);

        // Parse student data (remaining rows)
        for (var rowIndex = 1; rowIndex < csvData.Count; rowIndex++)
        {
            var row = csvData[rowIndex];
            var name = row[0];
            var studentType = Enum.Parse<StudentType>(row[1], true);
            var student = CreateStudent(studentType, name, ++id, row); // Pre-increment ID so it's not Zero

            GetAssignments(row, student);

            students.Add(student);
        }

        return students;
    }

    private void ParseHeaderRow(string[] headerRow)
    {
        // The first row is the header
        for (var i = 2; i < headerRow.Length - 1; i += 2)
        {
            var assignmentName = headerRow[i]; // Only store the assignment name
            _assignments.Add(new Assignment(assignmentName, 100, "2024-09-30", null)); // We’ll set type later
        }
    }

    private Student CreateStudent(StudentType studentType, string name, int id, string[] row) =>
        studentType switch
        {
            StudentType.PartTime => new PartTimeStudent(name, $"ID_{id}",
                int.Parse(row[^1])), // Last column is hours worked
            StudentType.Online => CreateOnlineStudent(name, $"ID_{id}"),
            _ => new Student(name, $"ID_{id}", StudentType.FullTime)
        };

    private OnlineStudent CreateOnlineStudent(string name, string id)
    {
        var student = new OnlineStudent(name, id);
        SimulateOnlineStudentData(student);
        return student;
    }

    private void GetAssignments(string[] row, Student student)
    {
        // Assign grades and assignment types to the student
        for (int i = 2; i < row.Length - 1; i += 2)
        {
            var grade = int.Parse(row[i]);
            var type = Enum.Parse<AssignmentType>(row[i + 1], true); // Parse assignment type from data row
            var assignment = _assignments[(i - 2) / 2]; // Get corresponding assignment
            assignment.AssignmentType = type; // Set the type in the assignment
            student.AddGrade(assignment, grade); // Assign grade to the student
            _assignmentMap[type].Add(assignment); // Add assignment to assignmentMap
        }
    }

    private void SimulateOnlineStudentData(OnlineStudent student)
    {
        var random = new Random();
        var posts = random.Next(1, 16);
        for (var i = 0; i < posts; i++)
        {
            student.IncrementForumPosts();
            student.CompleteVideoLecture();
        }
    }
}

