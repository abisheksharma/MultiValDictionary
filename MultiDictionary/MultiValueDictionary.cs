using System;
using System.Collections;
using System.Collections.Generic;

namespace MultiDictionary
{
    public class MultiValueDictionary<TKey, TValue> : IMultiValueDictionary<TKey, TValue>
    {
        private Dictionary<TKey, List<TValue>> dict;

        public MultiValueDictionary()
        {
            // initialize a new instance of MultiValueDictionary with default initial capacity
            dict = new Dictionary<TKey, List<TValue>>();
        }
        // Gets each key in this MultivalueDict that has one or more values
        public IEnumerable<TKey> Keys => dict.Keys;
        // Return number of keys with one or more values
        public int Count => dict.Count;
        // Add the key and val to the multivaluedict, if key already exist just add the value to that key
        public void Add(TKey key, TValue val)
        {           
            if (dict.ContainsKey(key))
            {
                dict[key].Add(val);
            }
            else
            {
                dict.Add(key, new List<TValue>() { val });
            }
        }
        // Removed all teh items in the MultiValueDict
        public void Clear()
        {
            dict.Clear();
        }
        // Returns true if the MultiValueDict contains the key
        public bool ContainsKey(TKey key)
        {            
            return dict.ContainsKey(key);
        }
        // Removed the key and all its value from the MultiValueDict 
        public void Remove(TKey key)
        {         
            if (dict.ContainsKey(key))
            {
                dict.Remove(key);
            }
        }
        // Removed the given value from the key in MultiValueDict and if there are no value left it removed the key as well
        public void Remove(TKey key, TValue val)
        {           
            if (dict.TryGetValue(key, out List<TValue> collection) && collection.Remove(val))
            {
                if (collection.Count == 0)
                    dict.Remove(key);
            }
        }
        // Returns true if the MultiValueDict contains the key/val combination
        public bool Contains(TKey key, TValue val)
        {           
            return (dict.TryGetValue(key, out List<TValue> collection) && collection.Contains(val));
        }
        // Returns list of values associated with the provided key
        public List<TValue> this[TKey key]
        {
            get
            {
                if (dict.TryGetValue(key, out List<TValue> collection))
                    return collection;

                throw new KeyNotFoundException();
            }
        }
        // Get an enumerator over the key/value in the MultiValueDict
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var entry in dict)
            {
                var collection = entry.Value;

                foreach (var item in collection)
                {
                    yield return new KeyValuePair<TKey, TValue>(entry.Key, item);
                }
            }
        }

    }
}