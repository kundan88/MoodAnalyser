using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyzerTest
{
    public class Moodanalyzercustomexception : Exception
    {
        Exceptiontype type;
        public enum Exceptiontype
        {
            EMPTY_NULL,
            EMPTY_MOOD
        }
        public Moodanalyzercustomexception(Exceptiontype type, string message) : base(message)
        {
            this.type = type;
        }
    }
}

