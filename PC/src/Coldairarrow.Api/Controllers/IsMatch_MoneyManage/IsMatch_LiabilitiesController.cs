using Coldairarrow.Business.IsMatch_MoneyManage;
using Coldairarrow.Entity.IsMatch_MoneyManage;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.IsMatch_MoneyManage
{
    [Route("/IsMatch_MoneyManage/[controller]/[action]")]
    public class IsMatch_LiabilitiesController : BaseApiController
    {
        #region DI

        public IsMatch_LiabilitiesController(IIsMatch_LiabilitiesBusiness isMatch_LiabilitiesBus)
        {
            _isMatch_LiabilitiesBus = isMatch_LiabilitiesBus;
        }

        IIsMatch_LiabilitiesBusiness _isMatch_LiabilitiesBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<IsMatch_Liabilities>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _isMatch_LiabilitiesBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<IsMatch_Liabilities> GetTheData(IdInputDTO input)
        {
            return await _isMatch_LiabilitiesBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(IsMatch_Liabilities data)
        {
            data.Year = data.Time.Value.Year;
            data.Month = data.Time.Value.Month;

            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _isMatch_LiabilitiesBus.AddDataAsync(data);
            }
            else
            {
                await _isMatch_LiabilitiesBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _isMatch_LiabilitiesBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}