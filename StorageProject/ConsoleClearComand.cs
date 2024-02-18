public class ConsoleClearComand : Comand {
    public override string Descriprion => "Очистить консоль";

    public override void Run() {
        Console.Clear();
    }
}
