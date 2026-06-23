using System.Collections.Generic;

class Card
{
    public string CardNumber { get; set; } = "";
    public string ExpiryDate { get; set; } = "";
    public string Pin { get; set; } = "";
    public List<Account> Accounts { get; set; } = new List<Account>();
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();
}
