using Coldairarrow.Business.Bill;
using Coldairarrow.Entity.Bill;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Bill
{
    [Route("/Bill/[controller]/[action]")]
    public class IsMatch_MoneyChangeController : BaseApiController
    {
        #region DI

        public IsMatch_MoneyChangeController(IIsMatch_MoneyChangeBusiness isMatch_MoneyChangeBus)
        {
            _isMatch_MoneyChangeBus = isMatch_MoneyChangeBus;
        }

        IIsMatch_MoneyChangeBusiness _isMatch_MoneyChangeBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<IsMatch_MoneyChange>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _isMatch_MoneyChangeBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<IsMatch_MoneyChange> GetTheData(IdInputDTO input)
        {
            return await _isMatch_MoneyChangeBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(IsMatch_MoneyChange data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _isMatch_MoneyChangeBus.AddDataAsync(data);
            }
            else
            {
                await _isMatch_MoneyChangeBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _isMatch_MoneyChangeBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}