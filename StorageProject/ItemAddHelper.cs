public static class ItemAddHelper {
    public static void AddItems() {
        if (File.Exists(Constans.GlobalSave)) {
            var names = File.ReadLines(Constans.GlobalSave).ToArray();
            Random random = new Random();
            var element = names[random.Next(0, names.Length)];
        }
    }
}
