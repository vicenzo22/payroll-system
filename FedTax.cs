using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollGoC
{
    class FedTax
    {
        public static double FedRate(double grossIncome)
        {
            if  (grossIncome <= 9875)
            {
                return Math.Round(0.10 * grossIncome,2);
            }

            else if (grossIncome >= 9876 && grossIncome <= 40125)
            {
                return Math.Round(0.12 * grossIncome,2);
            }

            else if (grossIncome >= 40126 && grossIncome <= 85525)
            {
                return Math.Round(0.22 * grossIncome,2);
            }
            else if (grossIncome >= 85526 && grossIncome <= 163300)
            {
                return Math.Round(0.24 * grossIncome,2);
            }
            else if (grossIncome >= 163301 && grossIncome <= 207350)
            {
                return Math.Round(0.32 * grossIncome,2);
            }
            else if (grossIncome >= 207351 && grossIncome <= 518400)
            {
                return Math.Round(0.35 * grossIncome,2);
            }
            else
            {
                return Math.Round(0.37 * grossIncome,2);
            }

        }
        /*
        public static double MarriedFedRate(double grossIncomeMarried, string MarriedRate)
        {
            if (MarriedFedRate == "TaxBracket1")
            {
                return grossIncomeMarried -= (0.03 * grossIncomeMarried);
            }

            else if (MarriedFedRate == "TaxBracket2")
            {
                return grossIncomeMarried -= (0.05 * grossIncomeMarried);
            }

            else if (MarriedFedRate == "TaxBracket3")
            {
                return grossIncomeMarried -= (0.055 * grossIncomeMarried);
            }
            else (MarriedFedRate == "TaxBracket4")
            {
                return grossIncomeMarried -= (0.060 * grossIncomeMarried);
            }
           
        }
        */

    }
}

