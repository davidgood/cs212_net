namespace CS212;

public class Student
{
    private readonly String _name;
    private readonly String _id;
    private readonly List<Grade> _grades;

    public Student(String name, String id) {
        _name = name;
        _id = id;
        _grades = new List<Grade>();
    }

    public string getName() {
        return _name;
    }

    public string getId() {
        return _id;
    }

    public void addGrade(Assignment assignment, int grade) {
        _grades.Add(new Grade(assignment, grade));
    }

    public int? getGrade(Assignment assignment) {
        foreach (var grade in _grades) {
            if (grade.getAssignment().Equals(assignment)) {
                return grade.getGrade();
            }
        }
        return null;
    }

    public double calculateAverageGrade() {
        if (!_grades.Any()) return 0;
        double total = 0;
        foreach (var grade in _grades) {
            total += grade.getGrade();
        }
        return total / _grades.Count;
    }

    public void simulateAPIPost() {
        Console.WriteLine("SimulatingPosting student data to external system:");
        Console.WriteLine($"Student Name: {_name}");  // <-- like python f strings.
        Console.WriteLine($"Student ID: {_id}");
        foreach (var grade in _grades) {
            Console.WriteLine($"Assignment: {grade.getAssignment().getName()} Grade: {grade.getGrade()}");
        }
    }
}