namespace CS212;

public interface IGradable {
    string Name { get; }
    int MaxPoints { get; set; }
    string DueDate { get; set; }
}