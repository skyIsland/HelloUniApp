using Coldairarrow.Entity.IsMatch_MoneyManage;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.IsMatch_MoneyManage
{
    public interface IIsMatch_PayBusiness
    {
        Task<PageResult<IsMatch_Pay>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<IsMatch_Pay> GetTheDataAsync(string id);
        Task AddDataAsync(IsMatch_Pay data);
        Task UpdateDataAsync(IsMatch_Pay data);
        Task DeleteDataAsync(List<string> ids);
    }
}