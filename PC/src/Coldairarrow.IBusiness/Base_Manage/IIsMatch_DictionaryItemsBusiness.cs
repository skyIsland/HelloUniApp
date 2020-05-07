using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Base_Manage
{
    public interface IIsMatch_DictionaryItemsBusiness
    {
        Task<PageResult<IsMatch_DictionaryItems>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<IsMatch_DictionaryItems> GetTheDataAsync(string id);
        Task AddDataAsync(IsMatch_DictionaryItems data);
        Task UpdateDataAsync(IsMatch_DictionaryItems data);
        Task DeleteDataAsync(List<string> ids);
    }
}