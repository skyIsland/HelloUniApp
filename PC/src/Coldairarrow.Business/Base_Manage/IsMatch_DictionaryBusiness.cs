using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Base_Manage
{
    public class IsMatch_DictionaryBusiness : BaseBusiness<IsMatch_Dictionary>, IIsMatch_DictionaryBusiness, ITransientDependency
    {
        public IsMatch_DictionaryBusiness(IRepository repository)
            : base(repository)
        {
        }

        protected override string _textField => "DictionaryName";

        #region 外部接口

        public async Task<PageResult<IsMatch_Dictionary>> GetDataListAsync(PageInput<ConditionDTO> input)
        {
            var q = GetIQueryable();
            var where = LinqHelper.True<IsMatch_Dictionary>();
            var search = input.Search;

            //筛选
            if (!search.Condition.IsNullOrEmpty() && !search.Keyword.IsNullOrEmpty())
            {
                var newWhere = DynamicExpressionParser.ParseLambda<IsMatch_Dictionary, bool>(
                    ParsingConfig.Default, false, $@"{search.Condition}.Contains(@0)", search.Keyword);
                where = where.And(newWhere);
            }

            return await q.Where(where).GetPageResultAsync(input);
        }

        public async Task<IsMatch_Dictionary> GetTheDataAsync(string id)
        {
            return await GetEntityAsync(id);
        }

        public async Task AddDataAsync(IsMatch_Dictionary data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(IsMatch_Dictionary data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        #endregion

        #region 私有成员

        #endregion
    }
}