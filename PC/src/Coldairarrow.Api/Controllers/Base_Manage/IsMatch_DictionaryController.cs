using Coldairarrow.Business.Base_Manage;
using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Base_Manage
{
    [Route("/Base_Manage/[controller]/[action]")]
    public class IsMatch_DictionaryController : BaseApiController
    {
        #region DI

        public IsMatch_DictionaryController(IIsMatch_DictionaryBusiness isMatch_DictionaryBus)
        {
            _isMatch_DictionaryBus = isMatch_DictionaryBus;
        }

        IIsMatch_DictionaryBusiness _isMatch_DictionaryBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<IsMatch_Dictionary>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _isMatch_DictionaryBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<IsMatch_Dictionary> GetTheData(IdInputDTO input)
        {
            return await _isMatch_DictionaryBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(IsMatch_Dictionary data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _isMatch_DictionaryBus.AddDataAsync(data);
            }
            else
            {
                await _isMatch_DictionaryBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _isMatch_DictionaryBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}