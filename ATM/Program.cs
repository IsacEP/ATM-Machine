using System;
using System.Collections.Generic;

public class cardHolder
{
    string cardnum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(String cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardnum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardnum;    
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setNum(string newCardNum)
    {
        cardnum = newCardNum;
    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Välj en av följande meny:");
            Console.WriteLine("1. insättning");
            Console.WriteLine("2. Uttag");
            Console.WriteLine("3. Visa saldo");
            Console.WriteLine("4. Avsluta");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("Hur mycket pengar vill du sätta in? ");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Tack för din insättning. Ditt nya saldo är: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUSer)
        {
            Console.WriteLine("Hur mycket pengar vill du ta ut? ");
            double withdrawal = double.Parse(Console.ReadLine());
            if(currentUSer.getBalance() < withdrawal)
            {
                Console.WriteLine("inte tillräckligt med pengar: ");
            }
            else
            {
                currentUSer.setBalance(currentUSer.getBalance()-withdrawal);
                Console.WriteLine("Du har tagit ut pengar. Tack!");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Ditt saldo: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1111 1111", 1234, "Håkan", "hällström", 168));
        cardHolders.Add(new cardHolder("2222 2222", 1111, "Veronica", "Maggio", 1000000));
        cardHolders.Add(new cardHolder("3333 3333", 8899, "Louise", "Lennartsson", 32918));
        cardHolders.Add(new cardHolder("4444 4444", 1212, "Daniel", "Adams-ray", 5684));

        Console.WriteLine("Välkommen till simpleATM");
        Console.WriteLine("Var god att sätta in ditt kort");
        string debitCardNumb = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNumb = Console.ReadLine();
                currentUser = cardHolder.FirstOrDefault(a => a.Equals(debitCardNumb));
                if (currentUser != null) { break; }
                else { Console.WriteLine("Kortet medges ej. Försök igen!"); }
            }
            catch{
                Console.WriteLine("Kortet medges ej. Försök igen!");
            }
        }

        Console.WriteLine("ange ditt pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() != null) { break; }
                else { Console.WriteLine("Fel pinkod. Försök igen"); }
            }
            catch
            {
                Console.WriteLine("Fel pinkod. Försök igen");
            }
        }

        Console.WriteLine("Välommen " + currentUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch 
            {
            }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }

        } while (option != 4);
        Console.WriteLine("Ha en trevlig dag!");
    }

    private static cardHolder FirstOrDefault(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }
}
