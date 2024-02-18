


public static class InputHelper {
    public static bool Input(string text, int min, int max, out int inputValue) {
        inputValue = -1;
        bool result = false;
        Console.WriteLine(text);

        if (int.TryParse(Console.ReadLine(), out int inputResult)) {
            inputValue = inputResult;

            if (inputResult >= min && inputResult <= max) {
                result = true;
            }
        }
        return result;
    }
}
