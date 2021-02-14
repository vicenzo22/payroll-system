using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollGoC
{
    class NYstateTax
    {
        public static double PayRateNY(double GrossIncome)
        {
            if (GrossIncome <= 12000)
            {
                return  Math.Round(0.03078 * GrossIncome,2);
            }

            else if (GrossIncome >= 12001 && GrossIncome <= 25000)
            {
                return  Math.Round(0.03762 * GrossIncome,2);
            }
            else if (GrossIncome >= 25001 && GrossIncome <= 50000)
            {
                return  Math.Round(0.03819 * GrossIncome,2);
            }
            else
            {
                return  Math.Round(0.03876 * GrossIncome,2);
            }
        }
    }
}

