using System;

namespace MultiDictionary
{
    public class MultiValueDictHelper : IMultiValueDictHelper
    {
        // Add key/value in the dict
        public void Add(MultiValueDictionary<string, string> multiValDict, string[] cmdItems)
        {
            if (!multiValDict.Contains(cmdItems[1], cmdItems[2]))
            {
                multiValDict.Add(cmdItems[1], cmdItems[2]);
                Console.WriteLine(") Added");
            }
            else
            {
                Console.WriteLine(") ERROR, member already exists for key.");
            }
        }

        // Gets all keys/members in the dict
        public void GetAllItems(MultiValueDictionary<string, string> multiValDict)
        {
            var i = 1;
            foreach (var item in multiValDict)
            {
                Console.WriteLine($"{i}) {item.Key}: {item.Value}");
                ++i;
            }
        }
        // Gets all the keys in the dict.
        public void GetAllKeys(MultiValueDictionary<string, string> multiValDict)
        {
            int i = 1;
            if (multiValDict.Count > 0)
            {
                foreach (var item in multiValDict.Keys)
                {
                    Console.WriteLine($"{i}) {item}");
                    ++i;
                }
            }
            else
            {
                Console.WriteLine(") empty set.");
            }
        }
        // Gets all the members in the dict.
        public void GetAllMembers(MultiValueDictionary<string, string> multiValDict)
        {
            var i = 1;
            foreach (var item in multiValDict)
            {
                Console.WriteLine($"{i}) {item.Value}");
                ++i;
            }
        }
        // Gets members for a key
        public void GetKeyMember(MultiValueDictionary<string, string> multiValDict, string key)
        {
            var members = multiValDict.ContainsKey(key);
            if (members)
            {
                int i = 1;
                foreach (var item in multiValDict[key])
                {
                    Console.WriteLine($"{i}) {item}");
                    ++i;
                }
            }
            else
            {
                Console.WriteLine("> MEMBERS bad");
                Console.WriteLine(") ERROR, key does not exist");
            }

        }

        // Removes all the member in that key
        public void RemoveAllRecord(MultiValueDictionary<string, string> multiValDict, string key)
        {
            if (multiValDict.ContainsKey(key))
            {
                multiValDict.Remove(key);
                Console.WriteLine(") Removed.");
            }
            else
            {
                Console.WriteLine(") ERROR, key does not exist.");
            }
        }

        // Removes member from a key 
        public void RemoveRecord(MultiValueDictionary<string, string> multiValDict, string[] cmdItems)
        {
            if (multiValDict.Contains(cmdItems[1], cmdItems[2]))
            {
                multiValDict.Remove(cmdItems[1], cmdItems[2]);
                Console.WriteLine(") Removed.");
            }
            else if (!multiValDict.ContainsKey(cmdItems[1]))
            {
                Console.WriteLine("Error, key does not exist");
            }
            else
            {
                Console.WriteLine("Error, member does not exist.");
            }
        }

    }
}
