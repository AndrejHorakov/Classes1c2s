namespace LinqWorking;

public class StudentsExample
{
    public List<Student> Students { get; set; } =
    [
        new() { Age = 17, Grade = 4.8, Name = "John" },
        new() { Age = 18, Grade = 3.8, Name = "Anna" },
        new() { Age = 16, Grade = 3.6, Name = "Kirill" },
        new() { Age = 19, Grade = 4.7, Name = "Anton" },
        new() { Age = 17, Grade = 5.0, Name = "Vladimir" },
        new() { Age = 15, Grade = 1.8, Name = "Mihael" },
        new() { Age = 21, Grade = 2.56, Name = "Angelina" }
    ];
}
public class Student
{
    public string Name;
    public int Age;
    public double Grade;
}