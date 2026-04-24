using System.Text;

namespace GenericClassWork.GenericBuilderExample;

// Базовый класс для любого содержимого
public abstract class DeliveryBox
{
    public string Label { get; set; }
}

// Конкретные реализации
public class PizzaBox : DeliveryBox
{
    public int Slices { get; set; }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine("Это коробка с пиццей");
        builder.AppendLine($"Label: {Label}");
        builder.AppendLine($"Количество кусочков: {Slices}");
        
        return builder.ToString();
    }
}

public class CoffeeBox : DeliveryBox
{
    public string Additional { get; set; }
    public bool HasTube { get; set; }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine("Это коробка с кофе");
        builder.AppendLine($"Label: {Label}");
        builder.AppendLine($"Доп ингредиент: {Additional}");
        builder.AppendLine(HasTube 
            ? "С трубочкой"
            : "Без трубочки");
        
        return builder.ToString();
    }
}