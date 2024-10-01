namespace CS212;

public class PartTimeStudent(string name, string id, int hoursWorkedPerWeek) : Student(name, id, StudentType.PartTime)
{
    private double CalculateWorkload()
    {
        return hoursWorkedPerWeek + CalculateAverageGrade();
    }

    public override void SimulateApiPost()
    {
        base.SimulateApiPost();
        Console.WriteLine($"Hours Worked Per Week: {hoursWorkedPerWeek}");
        Console.WriteLine($"Workload: {CalculateWorkload()}");
    }
}
