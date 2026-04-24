using System.Text;

var path = @"C:\app\note.txt";   // путь к файлу
 
var text = "Hello METANIT.COM"; // строка для записи
 
// запись в файл
using (var fstream = new FileStream(path, FileMode.OpenOrCreate))
{
    // преобразуем строку в байты
    byte[] buffer = Encoding.Default.GetBytes(text);
    // запись массива байтов в файл
    fstream.Write(buffer, 0, buffer.Length);
    Console.WriteLine("Текст записан в файл");
}
 
// чтение из файла
using (var fstream = File.OpenRead(path))
{
    // выделяем массив для считывания данных из файла
    byte[] buffer = new byte[fstream.Length];
    // считываем данные
    var readBytes = fstream.Read(buffer, 0, buffer.Length);
    if (readBytes > 0)
    {
        // декодируем байты в строку
        string textFromFile = Encoding.Default.GetString(buffer);
        Console.WriteLine($"Текст из файла: {textFromFile}");
    }
}
File.ReadAllText(path);