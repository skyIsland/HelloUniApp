using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Base_Manage
{
    public interface IIsMatch_DictionaryItemsBusiness
    {
        Task<PageResult<IsMatch_DictionaryItemsDTO>> GetDataListAsync(PageInput<IsMatch_DictionaryItemsInputDTO> input);
        Task<IsMatch_DictionaryItemsDTO> GetTheDataAsync(string id);

        Task<List<SelectOption>> GetOptionListAsync(string dictionaryCode);

        Task AddDataAsync(IsMatch_DictionaryItems data);
        Task UpdateDataAsync(IsMatch_DictionaryItems data);
        Task DeleteDataAsync(List<string> ids);
    }

    public class IsMatch_DictionaryItemsInputDTO
    {
        public string DictionaryId { get; set; }

        public string DictionaryItemText { get; set; }


        public string Id { get; set; }
        public string keyword { get; set; }
    }
}