namespace WordsGame;

public class Utils 
{
    
    /* SHORT FORM:
    public static string Scramble(string original)
    {
        string result;
     
        do
        {
           result = new string(original.ToCharArray().OrderBy(x=>Guid.NewGuid()).ToArray());
        } while (result.Equals(original) && original.Length > 1);

        return result;
    }
    */
    
    public static string Scramble(string original)
    {
        string result;
        
        if (original.Length <= 1)
        {
            return original;
        }

        var random = new Random();
    
        do
        {
            var charArray = original.ToCharArray();
            for (var i = charArray.Length - 1; i > 0; i--)
            {
                var j = random.Next(0, i + 1);
                (charArray[i], charArray[j]) = (charArray[j], charArray[i]);
            }
            
            result = new string(charArray);
        
        } while (result.Equals(original));

        return result;
    }


    public static List<string> SlurpLines(string filePath)
    {
        List<string> words = new();
        foreach (string line in File.ReadLines(filePath))
        {
            words.Add(line.Trim());
        }
        return words;
    }

    public static string PickRandom(List<string> entries)
    {
        var i = new Random().NextInt64() % entries.Count;
        return entries[(int)i];
    }

    public static int MapCharToPoints(char letter)
    {
        var upperCaseLetter = char.ToUpper(letter);
        switch (upperCaseLetter)
        {
            case 'D':
            case 'G':
                return 2;
            case 'B':
            case 'C':
            case 'M':
            case 'P':
                return 3;
            case 'F':
            case 'H':
            case 'V':
            case 'W':
            case 'Y':
                return 4;    
            case 'K':
                return 5;   
            case 'J':
            case 'X':
                return 8;  
            case 'Q':
            case 'Z':
                return 10;   
            default:
                return 1;
        }
    }
    
    public static bool IsWithinTimeSpan(DateTime start, DateTime end, TimeSpan timeSpan)
    {
        var upperBound = start + timeSpan;
        return end >= start && end <= upperBound;
    }

    public static int CalculatePointsWithTime(TimeSpan timeSpan, double timeAsSeconds , int points)
    {
        return Convert.ToInt32(Math.Round(points * (timeSpan.TotalSeconds - timeAsSeconds) / timeSpan.TotalSeconds));
    }
}