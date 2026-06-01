class Homework
{
    static void Main(string[] args)
    {
        Task1();
        Task2();
        Task3();
        Task4();
    }

    #region Task 1 - ლუწი და კენტი რიცხვები
    static void Task1()
    {
        Console.WriteLine("===== დავალება 1: ლუწი და კენტი რიცხვები =====");

        Console.Write("შეიყვანეთ მასივის ზომა (n): ");
        int n = int.Parse(Console.ReadLine()!);

        Console.Write($"შეიყვანეთ {n} ელემენტი (გამოყოფილი სფეისით): ");
        int[] arr = Console.ReadLine()!
                           .Split(' ')
                           .Select(int.Parse)
                           .ToArray();

        int[] evens = arr.Where(x => x % 2 == 0).ToArray();
        int[] odds  = arr.Where(x => x % 2 != 0).ToArray();

        Console.WriteLine("მასივი#1 : " + string.Join(" ", evens));
        Console.WriteLine("მასივი#2: "  + string.Join(" ", odds));
    }
    #endregion

    #region Task 2 - კონტაქტების აპლიკაცია (Dictionary + LINQ)
    static void Task2()
    {
        Console.WriteLine("===== დავალება 2: კონტაქტების აპლიკაცია =====");

        var contacts = new Dictionary<string, string>();

        // დამატება
        contacts.Add("ლუკა",   "555-100-200");
        contacts.Add("გიორგი", "555-300-400");
        contacts.Add("ანა",    "555-500-600");
        contacts.Add("მარიამ", "555-700-800");

        Console.WriteLine(">> კონტაქტები დამატების შემდეგ:");
        foreach (var c in contacts)
            Console.WriteLine($"   {c.Key}: {c.Value}");

        // განახლება
        contacts["გიორგი"] = "555-999-000";
        Console.WriteLine("\n>> განახლების შემდეგ (გიორგი):");
        foreach (var c in contacts)
            Console.WriteLine($"   {c.Key}: {c.Value}");

        // წაშლა
        contacts.Remove("ანა");
        Console.WriteLine("\n>> წაშლის შემდეგ (ანა):");
        foreach (var c in contacts)
            Console.WriteLine($"   {c.Key}: {c.Value}");

        // LINQ - კონტაქტები დახარისხებული სახელით
        Console.WriteLine("\n>> LINQ - კონტაქტები დახარისხებული სახელის მიხედვით:");
        contacts
            .OrderBy(c => c.Key)
            .ToList()
            .ForEach(c => Console.WriteLine($"   {c.Key}: {c.Value}"));
    }
    #endregion

    #region Task 3 - ელემენტების დათვლა და ჯამი
    static void Task3()
    {
        Console.WriteLine("===== დავალება 3: ელემენტების დათვლა =====");

        Console.Write("შეიყვანეთ მასივის ზომა (n): ");
        int n = int.Parse(Console.ReadLine()!);

        Console.Write($"შეიყვანეთ {n} ელემენტი (გამოყოფილი სფეისით): ");
        int[] arr = Console.ReadLine()!
                           .Split(' ')
                           .Select(int.Parse)
                           .ToArray();

        var result = arr
            .GroupBy(x => x)
            .OrderBy(g => g.Key)
            .Select(g => new
            {
                Value = g.Key,
                Count = g.Count(),
                Sum   = g.Key * g.Count()
            });

        foreach (var item in result)
            Console.WriteLine($"{item.Value} appears {item.Count} times sum {item.Sum}");
    }
    #endregion

    #region Task 4 - ტოპ N მონაწილე
    static void Task4()
    {
        Console.WriteLine("===== დავალება 4: ტოპ N მონაწილე =====");

        int[] scores = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Console.Write("შეიყვანეთ ტოპ N: ");
        int topN = int.Parse(Console.ReadLine()!);

        int[] top = scores
            .OrderByDescending(x => x)
            .Take(topN)
            .OrderBy(x => x)
            .ToArray();

        Console.WriteLine(string.Join(" ", top));
    }
    #endregion
}