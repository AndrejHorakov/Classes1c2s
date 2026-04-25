namespace Multithreading.ExamplesToImplement;

class Exam
{
    static CountdownEvent countdown = new(20); // Ждем 20 студентов

    public static void Main()
    {
        Console.WriteLine("Преподаватель открыл ведомость и ждет...");

        for (int i = 1; i <= 20; i++)
        {
            int studentId = i;
            Task.Run(() => {
                Thread.Sleep(new Random().Next(1000, 5000)); // Студент пишет
                Console.WriteLine($"Студент {studentId} сдал работу.");
                // Сообщил о том, что завершил
                countdown.Signal();
            });
        }

        countdown.Wait();
        // Ждём всех студентов
        Console.WriteLine("ВСЕ СДАЛИ! Преподаватель закрывает кабинет.");
    }
}