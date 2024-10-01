namespace CS212;

public class Assignment(string name, int maxPoints, string dueDate, AssignmentType? assignmentType)
    : IGradable
{
    public string Name => name;

    public int MaxPoints { get; set; } = maxPoints;

    public string DueDate { get; set; } = dueDate;

    public AssignmentType? AssignmentType { get; set; } = assignmentType;
}