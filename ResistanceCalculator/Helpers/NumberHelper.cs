using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistanceCalculator.Helpers
{
    internal class NumberHelper
    {
        public static string FormatNumber(double value)
        {
            if (value >= 1_000_000_000)
                return (value / 1_000_000_000D).ToString("0.#") + "B"; 
            else if (value >= 1_000_000)
                return (value / 1_000_000D).ToString("0.#") + "M"; 
            else if (value >= 1_000)
                return (value / 1_000D).ToString("0.#") + "K"; 
            else
                return value.ToString(); 
        }
    }
}
