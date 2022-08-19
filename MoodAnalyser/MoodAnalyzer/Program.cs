namespace MoodAnalyzerTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mood Analyzer");
            MoodAnalyzer moodAnalyzer = new MoodAnalyzer();
            moodAnalyzer.AnalyseMood(" I am in SAD mood");
        }
    }
}
