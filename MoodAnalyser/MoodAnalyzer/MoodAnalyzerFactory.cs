using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MoodAnalyzerTest
{
    public class MoodAnalyzerFactory
    {

        /// <summary>
        /// uc-4 CreateMoodAnalyzer method create object of mood analyzer class
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <return></return>
        public static object CreateMoodAnalyzer(string className, string constructorName)
        {
            //Create pattern to check class name and constructor name are same or not
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className, pattern);
            //Computation
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyzeType = assembly.GetType(className);
                    return Activator.CreateInstance(moodAnalyzeType);
                }
                catch (ArgumentNullException)
                {
                    throw new Moodanalyzercustomexception(Moodanalyzercustomexception.Exceptiontype.NO_SUCH_CLASS, "Class not found");
                }
            }
            else
            {
                throw new Moodanalyzercustomexception(Moodanalyzercustomexception.Exceptiontype.NO_SUCH_CONSTRUCTOR, "Constructor not found");
            }
        }
    }
}

