using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollGoC
{
    class CTstateTax
    {
        public static double PayRateCT(double GrossIncome)
        {
            if (GrossIncome <= 10000)
            {
                return Math.Round(0.030 * GrossIncome,2);
            }

            else if (GrossIncome >= 10001 && GrossIncome <= 50000)
            {
                return Math.Round(0.050 * GrossIncome,2);
            }

            else if (GrossIncome >= 50001 & GrossIncome <= 100000)
            {
                return Math.Round(0.055 * GrossIncome,2);
            }
            else if (GrossIncome >= 100001 && GrossIncome <= 200000)
            {
                return Math.Round(0.060 * GrossIncome,2);
            }
            else if (GrossIncome >= 200001 && GrossIncome <= 250000)
            {
                return Math.Round(0.0650 * GrossIncome,2);
            }
            else if (GrossIncome >= 250001 && GrossIncome <= 500000)
            {
                return Math.Round(0.0690 * GrossIncome,2);
            }
            else
            {
                return Math.Round(0.0699 * GrossIncome,2);
            }
        }

    }
}
