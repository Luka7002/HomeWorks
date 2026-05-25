// კონსოლიდან რიცხვს ვიღებთ და ვამოწმებთ იყოფა თუ არა 5-ზე
static void Exercise1()
{
    Console.Write("შეიყვანე რიცხვი: ");
    int num = int.Parse(Console.ReadLine()!);

    // თუ გაყოფის ნაშთი 0-ია, მაშინ იყოფა
    if (num % 5 == 0)
        Console.WriteLine("Yes");
    else
        Console.WriteLine("NO");
}

// ჯამი, სხვაობა, ნამრავლი, გაყოფა
static void Exercise2()
{
    Console.Write("X = ");
    int x = int.Parse(Console.ReadLine()!);
    Console.Write("Y = ");
    int y = int.Parse(Console.ReadLine()!);

    // გამოკლება და გაყოფა დიდიდან პატარას ვაკლებთ
    int bigger  = Math.Max(x, y);
    int smaller = Math.Min(x, y);

    Console.WriteLine($"X+Y  {x + y}");
    Console.WriteLine($"X-Y  {bigger - smaller}");
    Console.WriteLine($"X*Y  {x * y}");

    // 0-ზე გაყოფა არ შეიძლება
    if (smaller == 0)
        Console.WriteLine("X/Y  Not Allowed To Divide By Zero");
    else
        Console.WriteLine($"X/Y  {bigger / smaller}");
}

// ორი ცვლადის მნიშვნელობების გაცვლა
static void Exercise3()
{
    Console.Write("x = ");
    int x = int.Parse(Console.ReadLine()!);
    Console.Write("y = ");
    int y = int.Parse(Console.ReadLine()!);

    // დამხმარე ცვლადში ვინახავთ x-ს, შემდეგ ვცვლით
    int temp = x;
    x = y;
    y = temp;

    Console.WriteLine($"x = {x} ; y = {y}");
}

// გამრავლების ტაბულა შეყვანილი რიცხვისთვის
static void Exercise4()
{
    Console.Write("შეიყვანე რიცხვი: ");
    int n = int.Parse(Console.ReadLine()!);

    // 1-დან 9-მდე ვამრავლებთ
    for (int i = 1; i <= 9; i++)
        Console.WriteLine($"{n} * {i} = {n * i}");
}

// 1-დან n-მდე ლუწი რიცხვების კვადრატები
static void Exercise5()
{
    Console.Write("n = ");
    int n = int.Parse(Console.ReadLine()!);

    // i += 2 რადგან მხოლოდ ლუწებს გადავდივართ
    for (int i = 2; i <= n; i += 2)
        Console.WriteLine(i * i);
}

// მენიუ
Console.WriteLine("აირჩიე სავარჯიშო (1-5):");
string choice = Console.ReadLine()!;

switch (choice)
{
    case "1": Exercise1(); break;
    case "2": Exercise2(); break;
    case "3": Exercise3(); break;
    case "4": Exercise4(); break;
    case "5": Exercise5(); break;
    default:  Console.WriteLine("არასწორი არჩევანი."); break;
}