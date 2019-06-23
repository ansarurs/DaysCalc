using System;
using System.Collections.Generic;
using System.Text;

namespace DaysCalculator
{
    public class NotValidFormatException:Exception
    {
        public NotValidFormatException(string message):base(message)
        {

        }
        

    }
}
