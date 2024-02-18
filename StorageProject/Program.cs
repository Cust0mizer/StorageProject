using Newtonsoft.Json;
using System.Text;

namespace StorageProject {
    public class Program {
        static void Main(string[] args) {
            List<IAction> actions =
            [
                new SumAction(),
                new DisinctAction(),
                new DelenieAction(),
                new UmnojenieAction(),
                new GetCosValueAction(),
            ];

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Введите действие");

            for (int i = 0; i < actions.Count; i++) {
                sb.AppendLine($"{i + 1} - {actions[i].Discriprion}");
            }

            while (InputHelper.Input(sb.ToString(), 1, actions.Count + 1, out int inputValue)) {
                actions[inputValue - 1].Run();
            }



            //CreateNewItemComand сreateNewItemComand = new CreateNewItemComand();
            //ConsoleClearComand consoleClearComand = new ConsoleClearComand();
            //List<Comand> comands = new List<Comand>();

            //comands.Add(consoleClearComand);
            //comands.Add(сreateNewItemComand);

            //while (true) {
            //    if (InputHelper.Input(ComandHelper.GetDescriprionFromComand(comands), 1, comands.Count + 1, out int inputValue)) {
            //        inputValue--;

            //        if (inputValue == comands.Count) {
            //            break;
            //        }

            //        comands[inputValue].Run();
            //    }
            //}
        }
    }
}

public abstract class Comand {
    public abstract string Descriprion { get; }
    public abstract void Run();
}

public class Storage {
    Dictionary<Item, int> _items = new Dictionary<Item, int>();

    public void Add(Item item, int count) {
        if (!_items.TryAdd(item, count)) {
            _items[item] += count;
        }
    }
}

public class Item {
    public string Name { get; private set; }
    public float Cost { get; private set; }

    public Item(string name, float cost) {
        Name = name;
        Cost = cost;
    }
}

public class CreateNewItemComand : Comand {
    private NamesManager _namesManager = Locator.NamesManager;
    public override string Descriprion => "Создать новый предмет";

    public override void Run() {
        MyConsole.GoodMessagePrint("Введите название нового предмета");
        string itemName = Console.ReadLine();

        if (!string.IsNullOrEmpty(itemName)) {
            itemName = itemName.ToLower();

            if (_namesManager.ContainsName(itemName)) {
                MyConsole.ErorPrint("Такой уже есть!");
                return;
            }

            MyConsole.GoodMessagePrint($"Введите цену предмета {itemName}");
            if (float.TryParse(Console.ReadLine(), out float costValue)) {
                using (FileStream file = new FileStream(Constans.ItemPath, FileMode.Append)) {
                    using (StreamWriter streamWriter = new StreamWriter(file)) {
                        Item item = new Item(itemName, costValue);
                        string text = JsonConvert.SerializeObject(item);
                        streamWriter.WriteLine(text);
                        _namesManager.AddNewName(itemName);
                    }
                }
            }
            else {
                MyConsole.ErorPrint(Constans.INCORRECT_INPUT);
            }
        }
        else {
            MyConsole.ErorPrint(Constans.INCORRECT_INPUT);
        }
    }
}

public class SaveSystem {
    public void Save(string programData) {
        using (FileStream fileStream = new FileStream(Constans.GlobalSave, FileMode.OpenOrCreate)) {
            using (StreamWriter streamWriter = new StreamWriter(fileStream)) {
                streamWriter.Write(programData);
            }
        }
    }

    public void Load(ProgramData programData) {
        if (File.Exists(Constans.GlobalSave)) {
            string[] stringText = File.ReadAllLines(Constans.GlobalSave);
            programData.Load(stringText);
        }
    }
}


public interface IAction {
    public string Discriprion { get; }
    public void Run();
}

public class SumAction : IAction {
    public string Discriprion => "Сложение";

    public void Run() {
        Console.WriteLine("Введите первое");
        float.TryParse(Console.ReadLine(), out float firstValue);
        Console.WriteLine("Введите второе");
        float.TryParse(Console.ReadLine(), out float secondValue);
        float result = firstValue + secondValue;
        MyConsole.GoodMessagePrint($"first + second = {result}");
    }
}

public class DisinctAction : IAction {
    public string Discriprion => "Вычитание";

    public void Run() {
        Console.WriteLine("Введите первое");
        float.TryParse(Console.ReadLine(), out float firstValue);
        Console.WriteLine("Введите второе");
        float.TryParse(Console.ReadLine(), out float secondValue);
        float result = firstValue - secondValue;
        MyConsole.GoodMessagePrint($"first - second = {result}");
    }
}

public class DelenieAction : IAction {
    public string Discriprion => "Делить";

    public void Run() {
        Console.WriteLine("Введите первое");
        float.TryParse(Console.ReadLine(), out float firstValue);
        Console.WriteLine("Введите второе");
        float.TryParse(Console.ReadLine(), out float secondValue);
        float result = firstValue / secondValue;
        MyConsole.GoodMessagePrint($"first - second = {result}");
    }
}

public class UmnojenieAction : IAction {
    public string Discriprion => "Умножать";

    public void Run() {
        Console.WriteLine("Введите первое");
        float.TryParse(Console.ReadLine(), out float firstValue);
        Console.WriteLine("Введите второе");
        float.TryParse(Console.ReadLine(), out float secondValue);
        float result = firstValue * secondValue;
        MyConsole.GoodMessagePrint($"first - second = {result}");
    }
}

public class GetCosValueAction : IAction {
    public string Discriprion => "Косинус числа";

    public void Run() {
        Console.WriteLine("Введите первое");
        float.TryParse(Console.ReadLine(), out float firstValue);
        float result = MathF.Cos(firstValue);
        MyConsole.GoodMessagePrint($"Cos({firstValue}) = {result}");
    }
}