namespace CS212;

public abstract class Person(string name, string id)
{
    protected string Name { get; } = name;

    protected string Id { get; } = id;

    public abstract void SimulateApiPost();
}
