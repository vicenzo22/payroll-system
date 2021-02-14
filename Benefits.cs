using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollGoC
{
    class Benefits
    {
        public static double soc_sec_adm(double grossIncomeSSA)
        {
            return Math.Round(0.062 * grossIncomeSSA,2); 
        }

        public static double medicare(double grossIncomeMED)
        {
            return Math.Round(0.0145 * grossIncomeMED,2); 
        }
        public static double healthCoverage(double grossIncomeHealth, string healthCoverage)
        {
            if (healthCoverage == "Premium Pack")
            {
                return 250;
            }

            else if (healthCoverage == "Gold Pack")
            {
                return 150;
            }

            else
            {
                return 75;
            }
        }
        public static double dentalCoverage(double grossIncomeDental, string dentalCoverage)
        {
            if (dentalCoverage == "Premium Pack")
            {
                return  175;
            }

            else if (dentalCoverage == "Gold Pack")
            {
                return  100;
            }

            else
            {
                return  50;
            }
        }
        public static double visionCoverage(double grossIncomeVision, string visionCoverage)
        {
            if (visionCoverage == "Premium Pack")
            {
                return  100;
            }

            else if (visionCoverage == "Gold Pack")
            {
                return  75;
            }

            else
            {
                return  40;
            }
        }

        public static double retirement(double grossIncomeRET)
        {
            return Math.Round(grossIncomeRET * 0.04,2);
        }
    }
}

