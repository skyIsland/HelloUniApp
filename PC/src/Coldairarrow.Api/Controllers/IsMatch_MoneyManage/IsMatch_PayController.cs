using Coldairarrow.Business.IsMatch_MoneyManage;
using Coldairarrow.Entity.IsMatch_MoneyManage;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IsMatch_MoneyManage
{
    [Route("/IsMatch_MoneyManage/[controller]/[action]")]
    public class IsMatch_PayController : BaseApiController
    {
        #region DI

        public IsMatch_PayController(IIsMatch_PayBusiness isMatch_PayBus)
        {
            _isMatch_PayBus = isMatch_PayBus;
        }

        IIsMatch_PayBusiness _isMatch_PayBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<IsMatch_Pay>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _isMatch_PayBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<IsMatch_Pay> GetTheData(IdInputDTO input)
        {
            return await _isMatch_PayBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(IsMatch_Pay data)
        {
            data.Year = data.PayTime.Value.Year;
            data.Month = data.PayTime.Value.Month;
            data.Day = data.PayTime.Value.Day;

            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _isMatch_PayBus.AddDataAsync(data);
            }
            else
            {
                await _isMatch_PayBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _isMatch_PayBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}