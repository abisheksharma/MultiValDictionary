using System;
using System.Collections;
using System.Collections.Generic;

namespace MultiDictionary
{
    public class MultiValueDictionary<TKey, TValue>
    {
        private Dictionary<string, List<string>> dict;

        public MultiValueDictionary()
        {
            // initialize a new instance of MultiValueDictionary with default initial capacity
            dict = new Dictionary<string, List<string>>();
        }
        // Gets each key in this MultivalueDict that has one or more values
        public IEnumerable<string> Keys => dict.Keys;
        // Return number of keys with one or more values
        public int Count => dict.Count;
        // Add the key and val to the multivaluedict, if key already exist just add the value to that key
        public void Add(string key, string val)
        {           
            if (dict.ContainsKey(key))
            {
                dict[key].Add(val);
            }
            else
            {
                dict.Add(key, new List<string>() { val });
            }
        }
        // Removed all teh items in the MultiValueDict
        public void Clear()
        {
            dict.Clear();
        }
        // Returns true if the MultiValueDict contains the key
        public bool ContainsKey(string key)
        {            
            return dict.ContainsKey(key);
        }
        // Removed the key and all its value from the MultiValueDict 
        public void Remove(string key)
        {         
            if (dict.ContainsKey(key))
            {
                dict.Remove(key);
            }
        }
        // Removed the given value from the key in MultiValueDict and if there are no value left it removed the key as well
        public void Remove(string key, string val)
        {           
            if (dict.TryGetValue(key, out List<string> collection) && collection.Remove(val))
            {
                if (collection.Count == 0)
                    dict.Remove(key);
            }
        }
        // Returns true if the MultiValueDict contains the key/val combination
        public bool Contains(string key, string val)
        {           
            return (dict.TryGetValue(key, out List<string> collection) && collection.Contains(val));
        }
        // Returns list of values associated with the provided key
        public List<string> this[string key]
        {
            get
            {
                if (dict.TryGetValue(key, out List<string> collection))
                    return collection;

                throw new KeyNotFoundException();
            }
        }
        // Get an enumerator over the key/value in the MultiValueDict
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            foreach (var entry in dict)
            {
                var collection = entry.Value;

                foreach (var item in collection)
                {
                    yield return new KeyValuePair<string, string>(entry.Key, item);
                }
            }
        }

    }
}