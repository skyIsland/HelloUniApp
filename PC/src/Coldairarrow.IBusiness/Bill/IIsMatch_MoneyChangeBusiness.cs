using Coldairarrow.Entity.Bill;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Bill
{
    public interface IIsMatch_MoneyChangeBusiness
    {
        Task<PageResult<IsMatch_MoneyChange>> GetDataListAsync(PageInput<ConditionDTO> input);
        Task<IsMatch_MoneyChange> GetTheDataAsync(string id);
        Task AddDataAsync(IsMatch_MoneyChange data);
        Task UpdateDataAsync(IsMatch_MoneyChange data);
        Task DeleteDataAsync(List<string> ids);
    }
}