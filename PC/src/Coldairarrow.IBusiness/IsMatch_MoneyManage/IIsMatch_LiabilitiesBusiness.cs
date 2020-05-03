using Coldairarrow.Entity.IsMatch_MoneyManage;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IsMatch_MoneyManage
{
    public interface IIsMatch_LiabilitiesBusiness
    {
        Task<PageResult<IsMatch_Liabilities>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<IsMatch_Liabilities> GetTheDataAsync(string id);
        Task AddDataAsync(IsMatch_Liabilities data);
        Task UpdateDataAsync(IsMatch_Liabilities data);
        Task DeleteDataAsync(List<string> ids);
    }
}