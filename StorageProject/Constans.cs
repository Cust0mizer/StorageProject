public static class Constans {
    public static readonly string ItemPath;
    public static readonly string GlobalSave;
    public const string INCORRECT_INPUT = "Некоректный ввод!";

    static Constans() {
        ItemPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "items");
        GlobalSave = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "globalSave.txt");
    }
}
