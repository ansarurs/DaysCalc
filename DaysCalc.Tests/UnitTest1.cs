using System;

using DaysCalculator;
//using DaysCalcLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DaysCalc.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Leap year test
            int year = 2016, month = 1, Day = 1;
            int year2 = 2017, month2 = 1, Day2 = 1;
            DateTime date = new DateTime(year, month, Day);
            DateTime date2 = new DateTime(year2, month2, Day2);

            int resultdays = (date2 - date).Days;

            int days = (new DateFormat() { days = Day, month = month, Year = year } -  new DateFormat() { days = Day2, month = month2, Year = year2 }).days;

            Assert.AreEqual(resultdays, days);


        }
        [TestMethod]
        public void TestMethod2()
        {
            // The starting date is excluded because the difference is from the date

            int year = 1870, month = 1, Day = 1;
            int year2 = 2020, month2 = 1, Day2 = 1;
            DateTime date = new DateTime(year, month, Day);
            DateTime date2 = new DateTime(year2, month2, Day2);

            int resultdays = (date2 - date).Days;

            int days = (new DateFormat() { days = Day, month = month, Year = year } - new DateFormat() { days = Day2, month = month2, Year = year2 }).days;


           
            Assert.AreEqual(resultdays, days);




        }

        [TestMethod]
        public void TestMethod4()
        {
            // negative testcase

            int year = 1870, month = 1, Day = 1;
            int year2 = 2020, month2 = 1, Day2 = 1;
            DateTime date = new DateTime(year, month, Day);
            DateTime date2 = new DateTime(year2, month2, Day2);

            int resultdays = (date2 - date).Days;
            // Wrong input for the second parameter to get the incorrect value from the date
            int days = (new DateFormat() { days = Day, month = month, Year = year } - 
                new DateFormat() { days = Day2, month = month2, Year = year }).days;


           

            Assert.AreNotEqual(resultdays, days);




        }

        [TestMethod]
        public void TestMethod3()
        {
            Exception except = null;
            try
            {
                int year = 1870, month = 1, Day = 1;
                int year2 = 2020, month2 = 1, Day2 = 1;
                DateTime date = new DateTime(year, month, Day);
                DateTime date2 = new DateTime(year2, month2, Day2);

                int resultdays = (date2 - date).Days;
                // Wrong input for the second parameter to get the incorrect value from the date
                int days = (new DateFormat() { days = Day, month = month, Year = year } -
                    new DateFormat() { days = 0, month = month2, Year = year }).days;




            }
            catch (NotValidFormatException ex)
            {
                except = ex;
             
            }
            Assert.IsNotNull(except);
                       

        }

        [TestMethod]
        public void TestMethod5()
        {
            Exception except = null;
            try
            {
                int year = 1870, month = 1, Day = 1;
                int year2 = 2020, month2 = 1, Day2 = 1;
                DateTime date = new DateTime(year, month, Day);
                DateTime date2 = new DateTime(year2, month2, Day2);

                int resultdays = (date2 - date).Days;
                // Wrong input for the second parameter to get the incorrect value from the date
                int days = (new DateFormat() { days = Day, month = month, Year = year } -
                    new DateFormat() { days = 1, month = month2, Year = 0 }).days;
            }
            catch (NotValidFormatException ex)
            {
                except = ex;

            }
            Assert.IsNotNull(except);


        }

        [TestMethod]
        public void TestMethod7()
        {
            Exception except = null;
            try
            {// Leap year success case
                int year = 1870, month = 1, Day = 1;
                int year2 = 2016, month2 = 1, Day2 = 1;
                DateTime date = new DateTime(year, month, Day);
                DateTime date2 = new DateTime(year2, month2, Day2);

                int resultdays = (date2 - date).Days;
                // Wrong input for the second parameter to get the incorrect value from the date
                int days = (new DateFormat() { days = Day, month = month, Year = year } -
                    new DateFormat() { days = Day2, month = month2, Year = year2 }).days;
                Assert.AreEqual(days, resultdays);
            }
            catch (NotValidFormatException ex)
            {
                except = ex;

            }
            Assert.IsNull(except);


        }
        [TestMethod]
        public void TestMethod6()
        {
            Exception except = null;
            try
            {
                // Leap year failure case
                int year = 1870, month = 1, Day = 1;
                int year2 = 2016, month2 = 2, Day2 = 30;
             
                // Wrong input for the second parameter to get the incorrect value from the date
                int days = (new DateFormat() { days = Day, month = month, Year = year } -
                    new DateFormat() { days = Day2, month = month2, Year = year2 }).days;
            }
            catch (NotValidFormatException ex)
            {
                except = ex;

            }
            Assert.IsNotNull(except);


        }
    }
}
