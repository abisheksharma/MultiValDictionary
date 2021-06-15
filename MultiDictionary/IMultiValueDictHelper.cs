using Microsoft.Collections.Extensions;

namespace MultiDictionary
{
    internal interface IMultiValueDictHelper
    {
        void Add(MultiValueDictionary<string, string> multiValDict, string[] cmdItems);
        void GetAllItems(MultiValueDictionary<string, string> multiValDict);
        void GetAllKeys(MultiValueDictionary<string, string> multiValDict);
        void GetAllMembers(MultiValueDictionary<string, string> multiValDict);
        void GetKeyMember(MultiValueDictionary<string, string> multiValDict, string key);
        void RemoveAllRecord(MultiValueDictionary<string, string> multiValDict, string key);
        void RemoveRecord(MultiValueDictionary<string, string> multiValDict, string[] cmdItems);
    }
}