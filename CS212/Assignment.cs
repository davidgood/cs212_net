namespace CS212;

public class Assignment {
    private readonly String _name;
    private readonly int _maxPoints;
    private readonly String _dueDate;

    public Assignment(String name, int maxPoints, String dueDate) {
        _name = name;
        _maxPoints = maxPoints;
        _dueDate = dueDate;
    }

    public String getName() {
        return _name;
    }

    public int getMaxPoints() {
        return _maxPoints;
    }

    public String getDueDate() {
        return _dueDate;
    }
}