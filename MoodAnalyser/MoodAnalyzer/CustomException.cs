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
            NO_SUCH_CLASS,
            NO_SUCH_CONSTRUCTOR,
            EMPTY_MESSAGE,
            NULL_MESSAGE,
            NO_SUCH_FIELD,
        }
        public Moodanalyzercustomexception(Exceptiontype type, string message) : base(message)
        {
            this.type = type;
        }
    }
}

