namespace CS212;

public class Grade {
    private readonly Assignment _assignment;
    private readonly int _grade;

    public Grade(Assignment assignment, int grade) {
        _assignment = assignment;
        _grade = grade;
    }

    public Assignment getAssignment() {
        return _assignment;
    }

    public int getGrade() {
        return _grade;
    }
}