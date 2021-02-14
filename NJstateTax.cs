using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollGoC
{
    class NJstateTax
    {
        public static double PayRateNJ(double GrossIncome)
        {
            if (GrossIncome <= 19999)
            {
                return Math.Round(0.014 * GrossIncome,2);

            }

            else if (GrossIncome >= 20000 && GrossIncome <= 34999)
            {
                return Math.Round(0.0175 * GrossIncome,2);
            }

            else if (GrossIncome >= 35000 && GrossIncome <= 39999)
            {
                return Math.Round(0.035 * GrossIncome,2);
            }
            else if (GrossIncome >= 40000 && GrossIncome <= 75000)
            {
                return Math.Round(0.0553 * GrossIncome,2);
            }
            else if (GrossIncome >= 75001 && GrossIncome <= 499999)
            {
                return Math.Round(0.0673 * GrossIncome,2);
            }
            else if (GrossIncome >= 500000 && GrossIncome <= 4999999)
            {
                return Math.Round(0.0897 * GrossIncome,2);
            }
            else
            {
                return Math.Round(0.1075 * GrossIncome,2);
            }
        }

    }
}
