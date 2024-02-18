using Newtonsoft.Json;
using System.Text;

[Serializable]
public class ProgramData {
    private readonly SaveSystem _saveSystem;
    private List<ISaveElement> _saveElements = new List<ISaveElement>();

    public ProgramData(SaveSystem saveSystem) {
        _saveSystem = saveSystem;
    }

    //private List<string> _names { get; set; } = new List<string>();
    //public List<string> Names {
    //    get { return _names; }
    //    set {
    //        _names = value;
    //        Save();
    //    }
    //}

    //public void SetValue(ProgramData programData) {
    //    _names = programData._names;
    //}

    public void Save() {
        if (_saveSystem != null) {
            StringBuilder globalStateText = new StringBuilder();


            foreach (ISaveElement element in _saveElements) {
                globalStateText.AppendLine(JsonConvert.SerializeObject(element));
            }

            _saveSystem.Save(globalStateText.ToString());
        }
    }

    public void Load(string[] strings) {
        for (int i = 0; i < _saveElements.Count; i++) {
            ISaveElement item = _saveElements[i];

            for (int j = 0; j < strings.Length; j++) {
                if (strings[j].Contains(item.Name)) {
                    item.Load(strings[j]);
                }
            }
        }
    }

    public void AddSaveElement(ISaveElement saveElement) {
        _saveElements.Add(saveElement);
    }
}