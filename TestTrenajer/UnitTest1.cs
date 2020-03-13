﻿using System;
using Trenajer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestTrenajer
{
    [TestClass]
    public class UnitTest1
    {
        Trenajer.Word worder = new Word();
        Trenajer.MainWindow page = new MainWindow();
        
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
    }
}
