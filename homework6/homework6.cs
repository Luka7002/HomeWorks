class Homework
{
    static void Main(string[] args)
    {
        #region Task 1 - ლუწი და კენტი რიცხვები
        Console.WriteLine("===== დავალება 1: ლუწი და კენტი რიცხვები =====");

        Console.Write("შეიყვანეთ მასივის ზომა (n): ");
        int n1 = int.Parse(Console.ReadLine()!);

        Console.Write($"შეიყვანეთ {n1} ელემენტი (გამოყოფილი სფეისით): ");
        int[] arr1 = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();

        Console.WriteLine("მასივი#1 : " + string.Join(" ", arr1.Where(x => x % 2 == 0)));
        Console.WriteLine("მასივი#2: "  + string.Join(" ", arr1.Where(x => x % 2 != 0)));
        #endregion

        Console.WriteLine();

        #region Task 2 - კონტაქტების აპლიკაცია
        Console.WriteLine("===== დავალება 2: კონტაქტების აპლიკაცია =====");

        var contacts = new Dictionary<string, string>
        {
            { "ლუკა",   "555-100-200" },
            { "გიორგი", "555-300-400" },
            { "ანა",    "555-500-600" },
            { "მარიამ", "555-700-800" }
        };

        Console.WriteLine(">> დამატების შემდეგ:");
        contacts.ToList().ForEach(c => Console.WriteLine($"   {c.Key}: {c.Value}"));

        contacts["გიორგი"] = "555-999-000";
        Console.WriteLine("\n>> განახლების შემდეგ:");
        contacts.ToList().ForEach(c => Console.WriteLine($"   {c.Key}: {c.Value}"));

        contacts.Remove("ანა");
        Console.WriteLine("\n>> წაშლის შემდეგ:");
        contacts.ToList().ForEach(c => Console.WriteLine($"   {c.Key}: {c.Value}"));

        Console.WriteLine("\n>> დახარისხებული:");
        contacts.OrderBy(c => c.Key).ToList().ForEach(c => Console.WriteLine($"   {c.Key}: {c.Value}"));
        #endregion

        Console.WriteLine();

        #region Task 3 - ელემენტების დათვლა და ჯამი
        Console.WriteLine("===== დავალება 3: ელემენტების დათვლა =====");

        Console.Write("შეიყვანეთ მასივის ზომა (n): ");
        int n3 = int.Parse(Console.ReadLine()!);

        Console.Write($"შეიყვანეთ {n3} ელემენტი (გამოყოფილი სფეისით): ");
        int[] arr3 = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();

        arr3.GroupBy(x => x)
            .OrderBy(g => g.Key)
            .ToList()
            .ForEach(g => Console.WriteLine($"{g.Key} appears {g.Count()} times sum {g.Key * g.Count()}"));
        #endregion

        Console.WriteLine();

        #region Task 4 - ტოპ N მონაწილე
        Console.WriteLine("===== დავალება 4: ტოპ N მონაწილე =====");

        Console.Write("შეიყვანეთ მონაწილეთა ქულები (გამოყოფილი სფეისით): ");
        int[] scores = Console.ReadLine()!.Split(' ').Select(int.Parse).ToArray();

        Console.Write("შეიყვანეთ ტოპ N: ");
        int topN = int.Parse(Console.ReadLine()!);

        Console.WriteLine(string.Join(" ", scores.OrderBy(x => x).TakeLast(topN)));
        #endregion
    }
}