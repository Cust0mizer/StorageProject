using Newtonsoft.Json;

[Serializable]
public class NamesManager : ISaveElement {
    public string Name => typeof(NamesManager).ToString();
    private ProgramData _programData = Locator.ProgramData;
    [JsonProperty]
    private List<string> _names = new List<string>();

    public void AddNewName(string name) {
        _names.Add(name);
        _programData.Save();
    }

    public bool ContainsName(string name) {
        return _names.Contains(name);
    }

    public void Load(string text) {
        NamesManager namesManager = JsonConvert.DeserializeObject<NamesManager>(text);
        _names = namesManager._names;
    }
}