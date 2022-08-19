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

        public MoodAnalyzer()
        {
            this.message = " I am in SAD mood";
        }
        public string AnalyseMood(string Message)
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
    }
}
