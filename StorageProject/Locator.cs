public static class Locator {
    public static readonly SaveSystem SaveSystem;
    public static readonly ProgramData ProgramData;
    public static readonly NamesManager NamesManager;

    static Locator() {
        SaveSystem = new SaveSystem();
        ProgramData = new ProgramData(SaveSystem);
        NamesManager = new NamesManager();

        ProgramData.AddSaveElement(NamesManager);

        SaveSystem.Load(ProgramData);
    }
}