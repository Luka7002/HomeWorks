using System;

static class BankService
{
    public static void TakeMoney(Card card, string currency, decimal amount)
    {
        Account acc = FindAccount(card, currency);
        if (acc == null)
        {
            Console.WriteLine("ანგარიში ვერ მოიძებნა");
            return;
        }
        if (acc.Balance < amount)
        {
            Console.WriteLine("არასაკმარისი თანხა");
            return;
        }

        acc.Balance = acc.Balance - amount;
        card.Transactions.Add(new Transaction { Date = DateTime.Now, Type = "გამოტანა", Amount = amount, Currency = currency });
        JsonStorage.Save();
        Logger.Log("გამოტანა: " + amount + " " + currency);
        Console.WriteLine("წარმატებით გამოიტანეთ");
    }

    public static void PutMoney(Card card, string currency, decimal amount)
    {
        Account acc = FindAccount(card, currency);
        if (acc == null)
        {
            acc = new Account();
            acc.Currency = currency;
            acc.Balance = 0;
            card.Accounts.Add(acc);
        }

        acc.Balance = acc.Balance + amount;
        card.Transactions.Add(new Transaction { Date = DateTime.Now, Type = "შეტანა", Amount = amount, Currency = currency });
        JsonStorage.Save();
        Logger.Log("შეტანა: " + amount + " " + currency);
        Console.WriteLine("წარმატებით შეიტანეთ");
    }

    public static void Convert(Card card, string from, string to, decimal amount)
    {
        Account fromAcc = FindAccount(card, from);
        if (fromAcc == null || fromAcc.Balance < amount)
        {
            Console.WriteLine("არასაკმარისი თანხა");
            return;
        }

        decimal usdRate = 2.65m;
        decimal eurRate = 2.90m;
        decimal inGel = amount;

        if (from == "USD") inGel = amount * usdRate;
        if (from == "EUR") inGel = amount * eurRate;

        decimal result = inGel;
        if (to == "USD") result = inGel / usdRate;
        if (to == "EUR") result = inGel / eurRate;

        Account toAcc = FindAccount(card, to);
        if (toAcc == null)
        {
            toAcc = new Account();
            toAcc.Currency = to;
            toAcc.Balance = 0;
            card.Accounts.Add(toAcc);
        }

        fromAcc.Balance = fromAcc.Balance - amount;
        toAcc.Balance = toAcc.Balance + result;
        card.Transactions.Add(new Transaction { Date = DateTime.Now, Type = "კონვერტაცია", Amount = amount, Currency = from });
        JsonStorage.Save();
        Logger.Log("კონვერტაცია: " + amount + " " + from + " -> " + to);
        Console.WriteLine("კონვერტაცია შესრულდა");
    }

    static Account FindAccount(Card card, string currency)
    {
        for (int i = 0; i < card.Accounts.Count; i++)
        {
            if (card.Accounts[i].Currency == currency)
                return card.Accounts[i];
        }
        return null;
    }
}
