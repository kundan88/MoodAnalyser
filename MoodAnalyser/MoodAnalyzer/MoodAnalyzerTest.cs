using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerTest
{
    public class MoodAnalyzer
    {
        public string message;

        public MoodAnalyzer(string message)
        {
            this.message = message;
        }
        public MoodAnalyzer()
        {
            this.message = "I am in any Mood";
        }
        public string AnalyseMood()
        {
            try
            {
                if (message.Contains("SAD"))
                {
                    Console.WriteLine("The Mood is SAD");
                    return "SAD";
                }
                else
                {
                    Console.WriteLine("The Mood is HAPPY");
                    return "HAPPY";
                }
            }
            catch (NullReferenceException)
            {
                //throw new Moodanalyzercustomexception(Moodanalyzercustomexception.Exceptiontype.EMPTY_NULL, "Mood should not be null");
                return "HAPPY";
            }

        }
    }
}
