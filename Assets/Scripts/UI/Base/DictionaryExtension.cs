using System.Collections.Generic;

namespace UI.Base
{
    public static class DictionaryExtension
    {
        public static Tvalue TryGetValue<Tkey, Tvalue>(this Dictionary<Tkey, Tvalue> dict, Tkey key)
        {
            Tvalue value;
            dict.TryGetValue(key, out value);
            return value;
        }
    }
}