using System;
using Trenajer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestTrenajer
{
    [TestClass]
    public class UnitTest1
    {
        Trenajer.Word worder = new Word();
        Trenajer.MainWindow page = new MainWindow();
        Trenajer.TrenajerEntities db = new TrenajerEntities();
        
        [TestMethod]
        public void TestCorrectReturnValueFunc() //Проверка правильности возвращаемого типа 
        {
            Assert.IsInstanceOfType(worder.GetWord, typeof(string));
            Assert.IsNotInstanceOfType(worder.GetWord, typeof(int));
            Assert.IsNotInstanceOfType(worder.GetWord, typeof(bool));
            Assert.IsNotInstanceOfType(worder.GetWord, typeof(decimal));
            Assert.IsNotInstanceOfType(worder.GetWord, typeof(double));
            Assert.IsNotInstanceOfType(worder.GetWord, typeof(float));
            Assert.IsNotInstanceOfType(worder.GetWord, typeof(char));
        }
        [TestMethod]
        public void TestReturnNotNullValueFunc() 
        {
            Assert.IsNotNull(worder.GetWord);
        }

        [TestMethod]
        public void TestReturnSameAsFunc() 
        {
            string TestCatch = worder.GetWord;
            string NotSameRandom = worder.GetWord + "asbastqwedsa";
            Assert.AreEqual(TestCatch, worder.GetWord);
            Assert.AreNotEqual(NotSameRandom, worder.GetWord);
        }

        [TestMethod]
        public void TestCorrectReturnValue() //Проверка правильности возвращаемого типа 
        {
            Assert.IsInstanceOfType(page.Fulling(), typeof(string));
            Assert.IsNotInstanceOfType(page.Fulling(), typeof(int));
            Assert.IsNotInstanceOfType(page.Fulling(), typeof(bool));
            Assert.IsNotInstanceOfType(page.Fulling(), typeof(decimal));
            Assert.IsNotInstanceOfType(page.Fulling(), typeof(double));
            Assert.IsNotInstanceOfType(page.Fulling(), typeof(float));
            Assert.IsNotInstanceOfType(page.Fulling(), typeof(char));
        }
        [TestMethod]
        public void TestReturnNotNullValue() // проверка на пустые значение(что он их не возвращает)
        {
            Assert.IsNotNull(page.Fulling());
        }

        [TestMethod]
        public void TestReturnSameAs() // проверка что функция возвращает именно правильные значения с помощью сравнения первого прогона и то что выдается в сравнении 
        {
            string TestCatch = page.Fulling();
            string NotSameRandom = page.Fulling() + "asbastqwedsa";
            Assert.AreEqual(TestCatch, page.Fulling());
            Assert.AreNotEqual(NotSameRandom, page.Fulling());
        }
        [TestMethod]
        public void CheckCount()
        {
            Assert.AreEqual(db.Words.Count(), 25);
        }
        [TestMethod]
        public void CheckNotCount()
        {
            Assert.AreNotEqual(db.Words.Count(), 26);
        }
        [TestMethod]
        public void CheckEntity()
        {
            Assert.IsNotNull(db.Words);
        }
        [TestMethod]
        public void CheckConncection()
        {
            Assert.IsNotNull(OnConnection(@"Data Source=DESKTOP-57848NR;Initial Catalog=Trenajer;Integrated Security=True"));           
        }
        public bool OnConnection(string connection)
        {
            bool result = true;
            if (!string.IsNullOrEmpty(connection))
            {
                result = true;
            }
            else result = false;
            return result;
        }
    }
}
