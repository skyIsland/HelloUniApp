using Coldairarrow.Business.Base_Manage;
using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Util;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Api.Controllers.Base_Manage
{
    [Route("/Base_Manage/[controller]/[action]")]
    public class IsMatch_DictionaryItemsController : BaseApiController
    {
        #region DI

        public IsMatch_DictionaryItemsController(IIsMatch_DictionaryItemsBusiness isMatch_DictionaryItemsBus)
        {
            _isMatch_DictionaryItemsBus = isMatch_DictionaryItemsBus;
        }

        IIsMatch_DictionaryItemsBusiness _isMatch_DictionaryItemsBus { get; }

        #endregion

        #region 获取

        [HttpPost]
        public async Task<PageResult<IsMatch_DictionaryItems>> GetDataList(PageInput<ConditionDTO> input)
        {
            return await _isMatch_DictionaryItemsBus.GetDataListAsync(input);
        }

        [HttpPost]
        public async Task<IsMatch_DictionaryItems> GetTheData(IdInputDTO input)
        {
            return await _isMatch_DictionaryItemsBus.GetTheDataAsync(input.id);
        }

        #endregion

        #region 提交

        [HttpPost]
        public async Task SaveData(IsMatch_DictionaryItems data)
        {
            if (data.Id.IsNullOrEmpty())
            {
                InitEntity(data);

                await _isMatch_DictionaryItemsBus.AddDataAsync(data);
            }
            else
            {
                await _isMatch_DictionaryItemsBus.UpdateDataAsync(data);
            }
        }

        [HttpPost]
        public async Task DeleteData(List<string> ids)
        {
            await _isMatch_DictionaryItemsBus.DeleteDataAsync(ids);
        }

        #endregion
    }
}