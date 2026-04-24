using System.Text;

namespace GenericClassWork.BuilderExample;

public class Breakfast
{
    public List<string> Base { get; set; }
    public string Drink { get; set; }
    public List<string> Species { get; set; }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"База: {string.Join(", ",  Base)}");
        stringBuilder.AppendLine($"Специи: {string.Join(", ",  Species)}");
        stringBuilder.AppendLine($"Напиток: {Drink}");
        
        return stringBuilder.ToString();
    }
}