using System;

static class CardValidator
{
    public static bool CheckCardNumber(string num)
    {
        if (num == null || num.Length != 16)
            return false;
        for (int i = 0; i < num.Length; i++)
        {
            if (num[i] < '0' || num[i] > '9')
                return false;
        }
        return true;
    }

    public static bool CheckExpiry(string exp)
    {
        try
        {
            string[] parts = exp.Split('/');
            int month = int.Parse(parts[0]);
            int year = int.Parse(parts[1]);
            if (year < 100) year = year + 2000;
            DateTime end = new DateTime(year, month, 1).AddMonths(1).AddDays(-1);
            return end >= DateTime.Today;
        }
        catch
        {
            return false;
        }
    }
}
