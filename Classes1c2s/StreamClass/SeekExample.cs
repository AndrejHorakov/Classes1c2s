using System.Text;

namespace StreamClass;

public class SeekExample
{
    string path = "note.dat";

    string text = "hello world";

    public void Run()
    {
        using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
        {
            // преобразуем строку в байты
            byte[] input = Encoding.Default.GetBytes(text);
            // запись массива байтов в файл
            fstream.Write(input, 0, input.Length);
            Console.WriteLine("Текст записан в файл");
        }

// чтение части файла
        using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
        {
            // перемещаем указатель в конец файла, до конца файла- пять байт
            fstream.Seek(-5, SeekOrigin.End); // минус 5 символов с конца потока

            // считываем четыре символов с текущей позиции
            byte[] output = new byte[5];
            var readBytes = fstream.Read(output, 0, output.Length);
            if (readBytes > 0)
            {
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(output);
                Console.WriteLine($"Текст из файла: {textFromFile}"); // world
            }
        }
    }
}