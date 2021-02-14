using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollGoC
{
    class GrossIncome
    {
        public static int CalculateOvertimeHour(int hour)
        {
            if (hour > 40)
            {
                return hour - 40;
            }
            else
            {
                return 0;
            }
        }
        public static double CalculateOvertimePay(int overtimeHour, double hourlyWage)
        {
            return Math.Round(hourlyWage * 1.5 * overtimeHour,2);
        }

        public static double CalculateGrossIncome(int hour, double overtimePay, double hourlyWage)
        {
            if (hour <= 40)
            {
                return Math.Round(hourlyWage * hour,2);
            }
            else
            {
                return Math.Round((hourlyWage * hour) + overtimePay,2);
            }
        }
    }
}
