using System;

class Program
{
    static void Main(string[] args)
    {
        Logger.Log("აპლიკაცია გაეშვა");
        JsonStorage.Load();

        while (true)
        {
            Console.WriteLine("\n--- ბანკომატი ---");
            Console.Write("ბარათის ნომერი (0 გასასვლელად): ");
            string cardNum = Console.ReadLine();

            if (cardNum == "0")
                break;

            Console.Write("ვადა (MM/YY): ");
            string expiry = Console.ReadLine();

            if (!CardValidator.CheckCardNumber(cardNum) || !CardValidator.CheckExpiry(expiry))
            {
                Console.WriteLine("ბარათის მონაცემები არასწორია!");
                Logger.Log("ვერიფიკაცია ჩავარდა: არასწორი ბარათის ნომერი ან ვადა");
                continue;
            }

            Card card = null;
            for (int i = 0; i < JsonStorage.Data.Cards.Count; i++)
            {
                if (JsonStorage.Data.Cards[i].CardNumber == cardNum && JsonStorage.Data.Cards[i].ExpiryDate == expiry)
                {
                    card = JsonStorage.Data.Cards[i];
                    break;
                }
            }

            if (card == null)
            {
                Console.WriteLine("ბარათი ვერ მოიძებნა!");
                Logger.Log("ვერიფიკაცია ჩავარდა: ბარათი ვერ მოიძებნა");
                continue;
            }

            Console.Write("PIN კოდი: ");
            string pin = Console.ReadLine();

            if (card.Pin != pin)
            {
                Console.WriteLine("PIN არასწორია!");
                Logger.Log("ვერიფიკაცია ჩავარდა: არასწორი PIN");
                continue;
            }

            Logger.Log("წარმატებული შესვლა: " + cardNum);
            ShowMenu(card);
        }
    }

    static void ShowMenu(Card card)
    {
        while (true)
        {
            Console.WriteLine("\n1 - ნაშთი");
            Console.WriteLine("2 - გამოტანა");
            Console.WriteLine("3 - ბოლო 5 ოპერაცია");
            Console.WriteLine("4 - შეტანა");
            Console.WriteLine("5 - PIN შეცვლა");
            Console.WriteLine("6 - ვალუტის კონვერტაცია");
            Console.WriteLine("0 - გასვლა");
            Console.Write("აირჩიეთ: ");

            string choice = Console.ReadLine();

            try
            {
                if (choice == "1")
                {
                    for (int i = 0; i < card.Accounts.Count; i++)
                        Console.WriteLine(card.Accounts[i].Currency + " : " + card.Accounts[i].Balance);
                }
                else if (choice == "2")
                {
                    Console.Write("ვალუტა: ");
                    string cur = Console.ReadLine();
                    Console.Write("თანხა: ");
                    decimal money = decimal.Parse(Console.ReadLine());
                    BankService.TakeMoney(card, cur, money);
                }
                else if (choice == "3")
                {
                    int count = card.Transactions.Count;
                    if (count == 0)
                    {
                        Console.WriteLine("ოპერაციები არ არის");
                        continue;
                    }
                    int start = count - 5;
                    if (start < 0) start = 0;
                    for (int i = count - 1; i >= start; i--)
                    {
                        Transaction t = card.Transactions[i];
                        Console.WriteLine(t.Date + " " + t.Type + " " + t.Amount + " " + t.Currency);
                    }
                }
                else if (choice == "4")
                {
                    Console.Write("ვალუტა: ");
                    string cur = Console.ReadLine();
                    Console.Write("თანხა: ");
                    decimal money = decimal.Parse(Console.ReadLine());
                    BankService.PutMoney(card, cur, money);
                }
                else if (choice == "5")
                {
                    Console.Write("ძველი PIN: ");
                    string oldPin = Console.ReadLine();
                    Console.Write("ახალი PIN: ");
                    string newPin = Console.ReadLine();
                    if (card.Pin != oldPin)
                    {
                        Console.WriteLine("ძველი PIN არასწორია");
                        continue;
                    }
                    card.Pin = newPin;
                    JsonStorage.Save();
                    Logger.Log("PIN შეიცვალა");
                    Console.WriteLine("PIN შეიცვალა");
                }
                else if (choice == "6")
                {
                    Console.Write("საიდან: ");
                    string from = Console.ReadLine();
                    Console.Write("სად: ");
                    string to = Console.ReadLine();
                    Console.Write("თანხა: ");
                    decimal money = decimal.Parse(Console.ReadLine());
                    BankService.Convert(card, from, to, money);
                }
                else if (choice == "0")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("არასწორი არჩევანი");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("შეცდომა მოხდა, სცადეთ თავიდან");
                Logger.Log("შეცდომა მენიუში: " + ex.Message);
            }
        }
    }
}
