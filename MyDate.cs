using System;
namespace MyDateTime
{
    public class MyDate
    {
        // Instance variables
        private int _year = 1;
        private int _month = 1;
        private int _day = 1;

        private enum MONTHS
        { Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };

        private enum DAYS
        { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };

        private static readonly int[] DAYS_IN_MONTHS
            = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        // Constructor
        public MyDate(int day, int month, int year)
        {
            _day = day;
            _month = month;
            _year = year;
        }

        private int DayMax() // For current year and month
        {
            int currentMonth = GetMonth();
            int currentYear = GetYear();
            if (IsLeapYear(currentYear) && currentMonth == 2)
                return 29;
            else
                return DAYS_IN_MONTHS[currentMonth - 1];
                // MONTHS enum indexed to 1, but DAYS array to 0 
        }

        private int DayMax(int month, int year) // For different month and year
        {
            if (IsLeapYear(year) && month == 2)
                return 29;
            else
            {
                if (month >= 1 && month <= 12)
                {
                    return DAYS_IN_MONTHS[month - 1];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid month!");
                }
            }

        }

        public void SetYear(int year)
        {
            try
            {
                if (1 <= year && year <= 9999)
                    _year = year;
                else
                    throw new ArgumentOutOfRangeException("Invalid year!");
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void SetMonth(int month)
        {
            try
            {
                if (1 <= month && month <= 12)
                    _month = month;
                else
                    throw new ArgumentOutOfRangeException("Invalid month!");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void SetDay(int day)
        {
            try
            {
                if (1 <= day && day <= DayMax())
                    _day = day;
                else
                    throw new ArgumentOutOfRangeException("Invalid day!");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void SetDate(int day, int month, int year)
        {
            try
            {
                if (IsValidDate(day, month, year))
                {
                    SetYear(year);
                    SetMonth(month);
                    SetDay(day);
                }
                else
                    throw new ArgumentOutOfRangeException("Invalid day, month, or year!");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public int GetYear()
        {
            return _year;
        }

        public int GetMonth()
        {
            return _month;
        }

        public int GetDay()
        {
            return _day;
        }

        public MyDate NextDay()
        {
            int currentDay = GetDay();
            if (currentDay < DayMax())
            {
                SetDay(currentDay + 1);
            }
            else
            {
                SetDay(1);
                NextMonth();
            }
            return this;
        }

        public MyDate NextMonth() 
        {
            int currentMonth = GetMonth();
            if (currentMonth < 12)
            {
                int nextMonth = currentMonth + 1;
                if (GetDay() > DayMax(nextMonth, GetYear()))
                {
                    SetDay(DayMax(nextMonth, GetYear()));
                }
                SetMonth(nextMonth);
            }
            else
            {
                SetMonth(1);
                NextYear();
            }
            return this;
        }

        public MyDate NextYear() 
        {
            int currentYear = GetYear();
            if (currentYear < 9999)
            {
                
                if (GetDay() > DayMax())
                { SetDay(DayMax()); }

                int nextYear = currentYear + 1;
                if (GetDay() > DayMax(GetMonth(), nextYear))
                {
                    SetDay(DayMax(GetMonth(), nextYear));
                }

                SetYear(currentYear + 1);

                return this;
            }
            else
            {
                throw new InvalidOperationException("Year out of range!");
            }
        }
    

        public MyDate PreviousDay()
        {
            int currentDay = GetDay();
            if (currentDay > 1)
            {
                SetDay(currentDay - 1);
            }
            else
            {
                PreviousMonth();
                SetDay(DayMax());
            }
            return this;
        }

        public MyDate PreviousMonth()
        {
            int currentMonth = GetMonth();
            if (currentMonth > 1)
            {
                int prevMonth = currentMonth - 1;
                if (GetDay() > DayMax(prevMonth, GetYear()))
                {
                    SetDay(DayMax(prevMonth, GetYear()));
                }
                SetMonth(prevMonth);
            }
            else
            {
                SetMonth(12);
                PreviousYear();
            }
            return this;
        }

        public MyDate PreviousYear()
        {
            int currentYear = GetYear();
            if (currentYear > 1)
            {
                SetYear(currentYear - 1);

                if (GetDay() > DayMax())
                { SetDay(DayMax()); }

                return this;
            }
            else
            {
                throw new InvalidOperationException("Year out of range!");
            }
        }

        override public string ToString()
        {
            DAYS day = (DAYS)GetDayOfWeek(GetDay(), GetMonth(), GetYear());
            return $"{day} {GetDay()} {GetMonth()} {GetYear()}";
        }

        static bool IsLeapYear(int year)
        {
            /* A year is a leap year if it is divisible by 4 but not by
            100, or it is divisible by 400 */

            if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
            { return true; }

            return false;
        }

        bool IsValidDate(int day, int month, int year) // Reversed order to d, m, y.
        {
            int dayMax = DayMax(month, year);
            if (year > 9999    || year < 1)       { return false; }
            if (month > 12     || month < 1)      { return false; }
            if (day > dayMax   || day < 1)        { return false; }

            return true;
        }

        int GetDayOfWeek(int day, int month, int year)
        {
            /* tomohiko sakamoto algorithm. source:
             *  https://www.geeksforgeeks.org/tomohiko-sakamotos-algorithm-finding-day-week/ */

            int[] t = { 0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };

            if (month < 3) { year -= 1; }

            return (year + year / 4 - year / 100 + year / 400
                                + t[month - 1] + day) % 7;
        }
        
    }
}
