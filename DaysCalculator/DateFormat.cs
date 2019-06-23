using System;

namespace DaysCalculator
{
    public class DateFormat
    {
        public int days { get; set; }
        public int month { get; set; }
        public int Year { get; set; }
        /// <summary>
        /// Operator overloading to 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static DateFormat operator -(DateFormat from, DateFormat to)
        {
            DateFormat dateFormat = new DateFormat();
            try
            {
                // if the dates are in valid format
                if (ValidateDateFormat(from) && ValidateDateFormat(to))
                {
                    dateFormat.days = CalculateDays(from, to);
                }

            }
            catch (NotValidFormatException ex)
            {
                throw new NotValidFormatException(ex.Message);
                
            }
           
            return dateFormat;
        }
        /// <summary>
        /// this function is to validate the date format and throw the exception i fneeded
        /// </summary>
        /// <param name="dateFormat"></param>
        /// <returns></returns>
        static bool ValidateDateFormat(DateFormat dateFormat)
        {
            bool fResult = true;
            if (dateFormat == null)
            {
                fResult = false;
                throw new NotValidFormatException("date is NULL");
            }
            else if (dateFormat.Year < 1)
            {
                fResult = false;
                throw new NotValidFormatException("Invalid Year");
            }
            // Checking the leap year and feb month days are seperated here and other days are taken from array
            else if (((!CheckForLeapYear(dateFormat.Year) && (dateFormat.month == 2 && dateFormat.days > 28)) ||
                (CheckForLeapYear(dateFormat.Year) && (dateFormat.month == 2 && dateFormat.days > 29))) ||
                (dateFormat.days < 1 || dateFormat.days > monthDays[dateFormat.month - 1]))

            {
                fResult = false;
                throw new NotValidFormatException("Month days are invalid");
            }
            else if (dateFormat.month > 12 || dateFormat.month < 1)
            {
                fResult = false;
                throw new NotValidFormatException("Invalid Month");
            }
                
            

        
            return fResult;


        }
        /// <summary>
        /// Check for leap Year
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        static bool CheckForLeapYear(int Year)
        {
            return (((Year % 4 == 0) && (Year % 100 != 0)) || (Year % 400 == 0)) ? true : false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
         static int CalculateDaysFromDifferentiating(DateFormat dt1, DateFormat dt2)
        {
            int leapYrsDays = CountLeapYearsBetweenTwoDates(dt1, dt2);

            int numOfyears = dt2.Year - dt1.Year;

            int totalNumOfDays = numOfyears * 365 - dt1.days;


            for (int i = 0; i < dt1.month - 1; i++)
            {
                totalNumOfDays -= monthDays[i];
            }
            //Till end month
            for (int j = dt2.month; j < 12; j++)
            {
                totalNumOfDays -= monthDays[j];
            }

            totalNumOfDays -= (dt2.days > monthDays[dt2.month] ? dt2.days - monthDays[dt2.month] : monthDays[dt2.month] - dt2.days);

            totalNumOfDays += CountLeapYearsBetweenTwoDates(dt1, dt2);

            return totalNumOfDays;
        }
        /// <summary>
        /// Calculate the days between date1 and date
        /// </summary>
        /// <param name="dateFrom"> date from</param>
        /// <param name="dateTo"> date to</param>
        /// <returns>returns the number of days between these two dates</returns>
         static int CalculateDays(DateFormat dateFrom, DateFormat dateTo)
        {

            // from the biginning 
            int countOfDays = dateFrom.Year * 365 + dateFrom.days;

            // Add days for months  
            for (int i = 0; i < dateFrom.month - 1; i++)
            {
                countOfDays += monthDays[i];
            }

            //Add one day for the leap year 
            countOfDays += CountLeapYears(dateFrom);

            int countOfDaysTo = dateTo.Year * 365 + dateTo.days;
            for (int i = 0; i < dateTo.month - 1; i++)
            {
                countOfDaysTo += monthDays[i];
            }
            countOfDaysTo += CountLeapYears(dateTo);

            // return difference between two counts 
            return (countOfDaysTo - countOfDays);

        }
        /// <summary>
        /// Counting the leap years
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        static int CountLeapYears(DateFormat date)
        {
            int years = date.Year;

            //  if the current year needs to be considered 
            if (date.month <= 2)
            {
                years--;
            }
            // Leap Year logic
            return years / 4 - years / 100 + years / 400;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        static int CountLeapYearsBetweenTwoDates(DateFormat dateFrom, DateFormat dateTo)
        {
            int countOflpYears = 0;

            for (int yearCounter = dateFrom.Year; yearCounter < dateTo.Year; yearCounter++)
            {
                if (CheckForLeapYear(dateFrom.Year))
                {
                    // Counting every four years
                    //For loop increments one counter here
                    yearCounter += 3;
                    countOflpYears += 1;
                }

            }

            return countOflpYears;
        }
        static int[] monthDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    }
}

