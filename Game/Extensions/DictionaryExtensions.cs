using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.FirstOrDefault(kv => EqualityComparer<TKey>.Default.Equals(kv.Key, key)).Value;
        }
    }
}
