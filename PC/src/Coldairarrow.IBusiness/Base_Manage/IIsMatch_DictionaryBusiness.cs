using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Base_Manage
{
    public interface IIsMatch_DictionaryBusiness
    {
        Task<PageResult<IsMatch_Dictionary>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<IsMatch_Dictionary> GetTheDataAsync(string id);
        Task AddDataAsync(IsMatch_Dictionary data);
        Task UpdateDataAsync(IsMatch_Dictionary data);
        Task DeleteDataAsync(List<string> ids);
    }
}