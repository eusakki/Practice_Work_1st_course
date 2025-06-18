using PracticeWork_1st_course_;

var list = new DoublyLinkedList();
string filePath = "realestate.json";

bool exit = false;
while (!exit)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("1. Add item");
    Console.WriteLine("2. Remove item");
    Console.WriteLine("3. Print list");
    Console.WriteLine("4. Print from end");
    Console.WriteLine("5. Sort by price descending");
    Console.WriteLine("6. Search unsold apartments between 200000-500000");
    Console.WriteLine("7. Edit element by index");
    Console.WriteLine("8. Save to file");
    Console.WriteLine("9. Load from file");
    Console.WriteLine("0. Exit");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Choose option: ");
    Console.ResetColor();

    switch (Console.ReadLine())
    {
        case "1":
            Console.Write("Enter property type (Apartment, House, Commercial, Land): ");
            var type = Enum.Parse<PropertyType>(Console.ReadLine()!);
            Console.Write("Enter price: ");
            var price = double.Parse(Console.ReadLine()!);
            Console.Write("Is sold? (true/false): ");
            var sold = bool.Parse(Console.ReadLine()!);
            Console.Write("Enter position to insert: ");
            var pos = int.Parse(Console.ReadLine()!);

            list.AddAt(pos, new RealEstate(type, price, sold));
            break;

        case "2":
            Console.Write("Enter position to remove: ");
            var index = int.Parse(Console.ReadLine()!);
            list.RemoveAt(index);
            break;

        case "3":
            list.PrintList();
            break;

        case "4":
            list.PrintFromEnd();
            break;

        case "5":
            list.SortByPriceDescending();
            Console.WriteLine("Sorted!");
            break;

        case "7":
            Console.Write("Enter index to change element: ");
            int indexSet = int.Parse(Console.ReadLine());
            Console.Write("Enter new property type(Apartment, House, Commercial, Land): ");
            var newType = Enum.Parse<PropertyType>(Console.ReadLine()!);
            Console.Write("Enter new property price: ");
            var newPrice = double.Parse(Console.ReadLine());
            Console.Write("Is sold? (true/false): ");
            var newSold = bool.Parse(Console.ReadLine()!);

            try
            {
                list[indexSet] = new RealEstate(newType, newPrice, newSold);
                Console.WriteLine("Element has changed.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Incorrect index!");
            }
            break;

        case "6":
            var found = list.Search();
            foreach (var item in found)
                Console.WriteLine(item);
            break;

        case "8":
            list.Serialize(filePath);
            Console.WriteLine("Saved to file.");
            break;

        case "9":
            list.Deserialize(filePath);
            Console.WriteLine("Loaded  from file.");
            break;

        case "0":
            exit = true;
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
    Console.WriteLine();
}
