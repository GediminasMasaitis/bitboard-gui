using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitboardGui
{
    class BitboardParser
    {
        private bool TryParseValue(string text, out ulong value)
        {
            text = text.Trim();
            if (text.StartsWith("0x"))
            {
                text = text.Substring(2, text.Length - 2);
                return ulong.TryParse(text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out value);
            }

            return ulong.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out value);
        }

        public bool TryParseBitboard(string text, out ulong bitboard)
        {
            bitboard = default;
            text = text.Trim();
            var split = text.Split(new[] { "<<", ">>", "&", "|", "+", "-", "~" }, StringSplitOptions.TrimEntries);
            var leftText = split[0].Trim();
            if (split.Length == 1)
            {
                return TryParseValue(leftText, out bitboard);
            }

            if (split.Length != 2)
            {
                return false;
            }

            var rightText = split[1].Trim();
            if (leftText == string.Empty)
            {
                if (!TryParseValue(rightText, out var value))
                {
                    return false;
                }

                if (text.Contains("-"))
                {
                    bitboard = unchecked((ulong)(-(long)value));
                    return true;
                }

                if (text.Contains("~"))
                {
                    bitboard = ~value;
                    return true;
                }

                return false;
            }

            if (!TryParseValue(leftText, out var left))
            {
                return false;
            }
            if (!TryParseValue(rightText, out var right))
            {
                return false;
            }

            if (text.Contains("<<"))
            {
                bitboard = left << (int)right;
                return true;
            }

            if (text.Contains(">>"))
            {
                bitboard = left >> (int)right;
                return true;
            }

            if (text.Contains("&"))
            {
                bitboard = left & right;
                return true;
            }

            if (text.Contains("|"))
            {
                bitboard = left | right;
                return true;
            }

            if (text.Contains("+"))
            {
                bitboard = left + right;
                return true;
            }

            if (text.Contains("-"))
            {
                bitboard = left - right;
                return true;
            }

            return false;
        }
    }
}
