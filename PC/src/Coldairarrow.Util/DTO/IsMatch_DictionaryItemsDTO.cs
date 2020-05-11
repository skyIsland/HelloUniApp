using Coldairarrow.Entity.Base_Manage;
using System.Collections.Generic;

namespace Coldairarrow.Util
{
    [Map(typeof(IsMatch_DictionaryItems))]
    public class IsMatch_DictionaryItemsDTO : IsMatch_DictionaryItems
    {
        public string DictionaryName { get; set; }
    }
}
