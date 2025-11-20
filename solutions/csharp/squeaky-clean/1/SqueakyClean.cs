public static class Identifier
{
    public static string Clean(string identifier)
    {
        var result = "";
        for (var i = 0; i < identifier.Length; i++) {
            if ((identifier[i] != ' ' && identifier[i] != '\0' && identifier[i] != '-') && (!char.IsLetter(identifier[i]) || (identifier[i] >= 'α' && identifier[i] <= 'ω'))) {
                continue;
            }
            
            switch (identifier[i]) {
                case ' ':
                    result += "_";
                    break;
                case '\0':
                    result += "CTRL";
                    break;
                case '-':
                    result += char.ToUpper(identifier[i + 1]);
                    i++;
                    break;
                default:
                    result += identifier[i];
                    break;
            }
            Console.WriteLine(result);
        }
        
        return result;
    }
}