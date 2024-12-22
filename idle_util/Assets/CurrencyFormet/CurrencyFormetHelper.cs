using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util.Currency
{
    public static class CurrencyFormetHelper
    {
        public static string FormatNumber(double number)
        {
            if (number >= 1_000) // K
                return $"{number / 1_000:0.#}k";

            if (number >= 1_000_000) // M
                return $"{number / 1_000_000:0.#}m";

            if (number >= 1_000_000_000) // B
                return $"{number / 1_000_000_000:0.#}b";

            if (number >= 1_000_000_000_000) // T
                return $"{number / 1_000_000_000_000:0.#}t";

            return number.ToString("0");
        }
    }
}