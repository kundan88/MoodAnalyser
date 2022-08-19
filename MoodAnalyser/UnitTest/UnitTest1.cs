
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerTest;


namespace MoodAnalyzerTest
{
    [TestClass]
    public class Tests
    {
        MoodAnalyzer moodAnalyzer;
        [TestMethod]
        public void Setup()
        {
            moodAnalyzer = new MoodAnalyzer("I am in SAD Mood");
        }
        //<summary>
        //uc1Refactor-1.1 :Given message "I am in SAD mood" returns SAD
        //</summary>
        [TestMethod]
        public void Given_Message_In_Sad_Mood_Return_Sad_Message()
        {
            //Arrange
            string message = "I am in SAD Mood";
            moodAnalyzer = new MoodAnalyzer(message);

            //Act
            string expected = "SAD";
            string actual = moodAnalyzer.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        //<summary>
        //uc1Refactor-1.2 :Given message "I am in any mood" returns HAPPY
        //</summary>
        [TestMethod]
        public void Given_Message_In_Happy_Mood_Return_Happy_Message()
        {
            //Arrange
            string message = "I am in Any Mood";
            moodAnalyzer = new MoodAnalyzer(message);

            //Act
            string expected = "HAPPY";
            string actual = moodAnalyzer.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        //<summary>
        //uc2-2.1 :Given message "Handle Null Exception" returns HAPPY
        //</summary>
        [TestMethod]
        public void Handle_Null_Exception_returns_HAPPY()
        {
            //Arrange
            string message = " ";
            moodAnalyzer = new MoodAnalyzer(message);

            //Act
            string expected = "HAPPY";
            string actual = moodAnalyzer.AnalyseMood();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        //<summary>
        //uc3.1 :Given message "Handle Null Exception" returns HAPPY
        //</summary>
        [TestMethod]
        public void Given_NullMood_Return_CustomException()
        {
            //Arrange
            string message = null;
            string expected = "Mood should not be null";
            try
            {
                //Act
                moodAnalyzer = new MoodAnalyzer(message);
            }
            catch (Moodanalyzercustomexception exception)
            {
                //Assert
                Assert.AreEqual(expected, exception.Message);
            }
        }
        //<summary>
        //uc3.2 :Given Empty Mood throw custom exception
        //</summary>
        [TestMethod]
        public void Given_EmptyMood_Return_CustomException()
        {
            //Arrange
            string message = " ";
            string expected = "Mood should not be empty";
            try
            {
                //Act
                moodAnalyzer = new MoodAnalyzer(message);
            }
            catch (Moodanalyzercustomexception exception)
            {
                //Assert
                Assert.AreEqual(expected, exception.Message);
            }
        }
        //<summary>
        //uc4.1 :Given Mood analyser Class name should return mood analyser object
        //</summary>
        [TestMethod]
        public void MoodAnalyserClassName_ShouldReturn_MoodAnalyserObject()
        {
            string message = null;
            object expected = new MoodAnalyzer(message);
            object obj = MoodAnalyzerFactory.CreateMoodAnalyzer("MoodAnalyzerTest.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(obj);
        }
        //<summary>
        //uc4.2 :Given Mood analyser Class name when improper should throw exception
        //</summary>
        [TestMethod]
        public void MoodAnalyzerClassName_Improper_should_throwMoodanalyzerException()
        {
            string expected = "Class not found";
            try
            {
                object obj = MoodAnalyzerFactory.CreateMoodAnalyzer("Moodanalyzer.Mood", "Mood");
            }
            catch (Moodanalyzercustomexception exception)
            {
                //Assert
                Assert.AreEqual(expected, exception.Message);
            }
        }
        /// <summary>
        /// TC-4.3 Given MoodAnalyse Class Name When Constructor is Improper Should Throw Exception
        /// </summary>
        [TestMethod]
        public void MoodAnalyzerClassName_ConstructorIsImproper_Should_ThrowMoodAnalyserException()
        {
            object obj = null;
            string expected = "Constructor not found";
            try
            {
                obj = MoodAnalyzerFactory.CreateMoodAnalyzer("MoodAnalyserDay12.MoodAnalyser", "AnalyserMood");
            }
            catch (Moodanalyzercustomexception exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
        /// <summary>
        /// TC-5.1  Given MoodAnalyse Class Name Should Return MoodAnalyser Object
        /// </summary>
        [TestMethod]
        public void MoodAnalyzerClassName_ShouldReturnMoodAnalyserObject_UsingParametrizedConstructor()
        {
            object expected = new MoodAnalyzer("HAPPY");
            object obj = MoodAnalyzerFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerTest.MoodAnalyzer", "MoodAnalyzer");
            expected.Equals(obj);
        }
        /// <summary>
        /// TC-5.2  Given MoodAnalyse Class Name When Improper Should Throw Exception
        /// </summary>
        [TestMethod]
        public void MoodAnalyzerClassName_WhenImproper_UsingParametrizedConstructor_ShouldThrowExcpetion()
        {
            string expected = "Class not found";
            try
            {
                object obj = MoodAnalyzerFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerTest.Mood", "MoodAnalyzer");
            }
            catch (Moodanalyzercustomexception exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
        /// <summary>
        /// TC-5.3  Given MoodAnalyse Class Name When Constructor is Improper Should Throw Exception
        /// </summary>
        [TestMethod]
        public void MoodAnalyzerClassName_WhenConstructorIsImproper_UsingParametrizedConstructor_ShouldThrowExcpetion()
        {
            string expected = "Constructor not found";
            try
            {
                object obj = MoodAnalyzerFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerTest.MoodAnalyzer", "Mood");
            }
            catch (Moodanalyzercustomexception exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
    }
}

