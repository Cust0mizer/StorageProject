using System.Text;

public static class ComandHelper {
    public static string GetDescriprionFromComand(List<Comand> comands) {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("Что хотите сделать?\n");

        for (int i = 0; i < comands.Count; i++) {
            stringBuilder.Append($"{i + 1} - {comands[i].Descriprion} \n");
        }

        stringBuilder.Append($"{comands.Count + 1} - Закрыть приложение");
        return stringBuilder.ToString();
    }
}
