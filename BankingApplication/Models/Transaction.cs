using System;

class Transaction
{
    public DateTime Date { get; set; }
    public string Type { get; set; } = "";
    public decimal Amount { get; set; }
    public string Currency { get; set; } = "";
}
