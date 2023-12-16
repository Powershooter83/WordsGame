namespace WordsGame;

public class WordsGameAlternative : IWordsGame
{
    private string word;

    public string Start(string word)
    {
        this.word = word;
        return Utils.Scramble(word);
    }
    

    /* Mormal:
    public int Grade(string solution)
    {
        var points = 0;

        for (var i = 0; i < word.Length; i++)
        {
            if (i + 1 > solution.Length)
            {
                break;
            }
            
            if (solution[i].Equals(word[i]))
            {
                points += Utils.MapCharToPoints(word[i]);
            }

        }

        return points;
    }
    */

    // With JetBrains Rider Magic:
    public int Grade(string solution)
    {
        return word.TakeWhile((t, i) => i + 1 <= solution.Length).Where((t, i) => solution[i].Equals(t)).Sum(Utils.MapCharToPoints);
    }
}