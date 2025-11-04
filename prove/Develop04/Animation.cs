public class Animation
{
    List<string> _loadingSymbols = new List<string>();

    public Animation(List<string> symbols)
    {
        foreach (string symbol in symbols)
        {
            _loadingSymbols.Add(symbol);
        }
    }

    public void LoadingAnimation(int duration, string doKill = null)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        DateTime killTime = DateTime.Now;

        if (doKill != null)
        {
            killTime = DateTime.Parse(doKill);
        }

        while (DateTime.Now < endTime && (doKill == null || DateTime.Now < killTime))
        {
            foreach (string s in _loadingSymbols)
            {
                Console.Write(s);
                Thread.Sleep(500);
                Console.Write("\b \b");
            }
        }
        Console.WriteLine("\b \b");
    }
}