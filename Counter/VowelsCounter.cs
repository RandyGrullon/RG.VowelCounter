using System;
using System.Collections.Generic;
using System.Linq;

namespace Counter
{
    public class VowelsCounter
    {
        public static IDictionary<char, int> Count(string text)
        {
            InputValidation(text);
            var vowels = new[]{
                'a', 'e', 'i', 'o', 'u'
            };
            return text.Where(param => vowels.Contains(char.ToLower(param)))
                .GroupBy(param => char.ToLower(param)).ToDictionary(param => param.Key, x => x.Count());
        }

        public static void InputValidation(string text){
            if (text is null)
            {
                throw new ArgumentNullException(paramName: nameof(text));
            }
        }


    }
}
