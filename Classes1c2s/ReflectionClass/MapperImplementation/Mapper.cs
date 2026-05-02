namespace ReflectionClass.MapperImplementation;

public static class Mapper
{
    public static void Map<TSource, TDest>(TSource source, TDest dest)
    {
        // TODO: Получить список свойств source (typeof(TSource).GetProperties())
        var propertiesSource = typeof(TSource).GetProperties();
        // TODO: Получить список свойств dest
        var propertiesDest = dest?.GetType().GetProperties();
        // TODO: Пройтись циклом по свойствам source
        foreach (var property in propertiesSource)
        {
            propertiesDest.FirstOrDefault(x => (x.Name == property.Name) && (x.PropertyType == property.PropertyType))?
                .SetValue(dest, property.GetValue(source));
        }
        // TODO: Найти в dest свойство с таким же именем и типом
        // TODO: Если нашли — прочитать значение из source и записать в dest
    }
}