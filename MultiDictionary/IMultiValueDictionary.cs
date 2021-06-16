using System.Collections.Generic;

namespace MultiDictionary
{
    public interface IMultiValueDictionary<TKey, TValue>
    {
        void Add(TKey key, TValue val);
        void Clear();
        bool ContainsKey(TKey key);
        void Remove(TKey key);
        void Remove(TKey key, TValue val);
        bool Contains(TKey key, TValue val);
        IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();
    }
}