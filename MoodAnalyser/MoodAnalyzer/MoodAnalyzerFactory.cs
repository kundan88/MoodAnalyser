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
        /// <summary>
        /// UC-5 For parameterised constructor by pssing messge parameter to the class method
        /// </summary>
        /// <param name="className"></param>
        /// <param name="constructorName"></param>
        /// <returns></returns>
        public static object CreateMoodAnalyseUsingParameterizedConstructor(string className, string constructorName)
        {
            Type type = typeof(MoodAnalyzer);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo construct = type.GetConstructor(new[] { typeof(string) });
                    object instance = construct.Invoke(new object[] { "HAPPY" });
                    return instance;
                }

                else
                {
                    throw new Moodanalyzercustomexception(Moodanalyzercustomexception.Exceptiontype.NO_SUCH_CONSTRUCTOR, "Constructor not found");
                }
            }
            else
            {
                throw new Moodanalyzercustomexception(Moodanalyzercustomexception.Exceptiontype.NO_SUCH_CLASS, "Class not found");
            }
        }
        /// <summary>
        /// UC6: Use Reflection to invoke Method
        /// </summary>
        /// <param name="message"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzerTest.MoodAnalyzer");
                object moodAnalyseObject = MoodAnalyzerFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerTest.MoodAnalyzer", "MoodAnalyzer");
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();

            }
            catch (NullReferenceException)
            {
                throw new Moodanalyzercustomexception(Moodanalyzercustomexception.Exceptiontype.NO_SUCH_CONSTRUCTOR, "Constructor not found");

            }
        }
    }
}