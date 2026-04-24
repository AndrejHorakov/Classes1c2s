using System.Diagnostics;
using System.Drawing;

public delegate void AccountHandler(string message);
public class Account
{
    int sum;
    // Создаем переменную делегата
    AccountHandler? taken;
    public Account(int sum) => this.sum = sum;
    // Регистрируем делегат
    public void RegisterHandler(AccountHandler podarok)
    {
        taken = podarok;
    }
    public void Add(int sum) => this.sum += sum;
    public void Take(int sum)
    {
        if (this.sum >= sum)
        {
            this.sum -= sum;
            // вызываем делегат, передавая ему сообщение
            taken?.Invoke($"Со счета списано {sum} у.е.");
        }
        else
        {
            taken?.Invoke($"Недостаточно средств. Баланс: {this.sum} у.е.");
        }
    }
}

interface A
{
    private void Add(int sum)
    {
        
    }
}

class Program : A
{
    delegate void PrintMessage(string message);

    public Func<string ,int, double> Method => (str, numb) => numb + str.Length ;

    static void Main(string[] args)
    {
        // создаем банковский счет
        Account account = new Account(200);
        // Добавляем в делегат ссылку на метод PrintSimpleMessage
        account.RegisterHandler(PrintRedMessage);
        // Два раза подряд пытаемся снять деньги
        account.Take(100);
        account.Take(150);
        Console.ReadKey();
        
        void PrintSimpleMessage(string message) => Console.WriteLine(message);
        void PrintRedMessage(string message) => Debug.WriteLine(message);
    }
}