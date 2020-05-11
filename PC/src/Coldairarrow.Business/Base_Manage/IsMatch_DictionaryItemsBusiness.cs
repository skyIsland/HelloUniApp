using AutoMapper;
using Coldairarrow.Business.Cache;
using Coldairarrow.Entity.Base_Manage;
using Coldairarrow.Util;
using EFCore.Sharding;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Coldairarrow.Business.Base_Manage
{
    public class IsMatch_DictionaryItemsBusiness : BaseBusiness<IsMatch_DictionaryItems>, IIsMatch_DictionaryItemsBusiness, ITransientDependency
    {
        public IsMatch_DictionaryItemsBusiness(IRepository repository)
            : base(repository)
        {
        }

        protected override string _textField => "DictionaryItemText";
        protected override string _valueField => "DictionaryItemCode";


        #region 外部接口

        public async Task<PageResult<IsMatch_DictionaryItemsDTO>> GetDataListAsync(PageInput<IsMatch_DictionaryItemsInputDTO> input)
        {
            Expression<Func<IsMatch_DictionaryItems, IsMatch_Dictionary, IsMatch_DictionaryItemsDTO>> select = (a, b) => new IsMatch_DictionaryItemsDTO
            {
                DictionaryName = b.DictionaryName
            };
            var search = input.Search;
            select = select.BuildExtendSelectExpre();
            var q_User = GetIQueryable();
            var q = from a in q_User.AsExpandable()
                    join b in Service.GetIQueryable<IsMatch_Dictionary>() on a.DictionaryId equals b.Id into ab
                    from b in ab.DefaultIfEmpty()
                    select @select.Invoke(a, b);

            var where = LinqHelper.True<IsMatch_DictionaryItemsDTO>();

            if (!search.DictionaryId.IsNullOrEmpty())
                where = where.And(x => x.DictionaryId == search.DictionaryId);

            if (!search.DictionaryItemText.IsNullOrEmpty())
                where = where.And(x => x.DictionaryItemText.Contains(search.DictionaryItemText));

            if (!search.Id.IsNullOrEmpty())
                where = where.And(x => x.Id == search.Id);
            //if (!search.keyword.IsNullOrEmpty())
            //{
            //    var keyword = $"%{search.keyword}%";
            //    q = q.Where(x =>
            //          EF.Functions.Like(x.UserName, keyword)
            //          || EF.Functions.Like(x.RealName, keyword));
            //}

            var list = await q.Where(where).GetPageResultAsync(input);

            //await SetProperty(list.Data);

            return list;
        }

        public async Task<IsMatch_DictionaryItemsDTO> GetTheDataAsync(string id)
        {
            if (id.IsNullOrEmpty())
                return null;
            else
            {
                PageInput<IsMatch_DictionaryItemsInputDTO> input = new PageInput<IsMatch_DictionaryItemsInputDTO>
                {
                    Search = new IsMatch_DictionaryItemsInputDTO
                    {                        
                        Id = id
                    }
                };
                return (await GetDataListAsync(input)).Data.FirstOrDefault();
            }
        }

        public async Task AddDataAsync(IsMatch_DictionaryItems data)
        {
            await InsertAsync(data);
        }

        public async Task UpdateDataAsync(IsMatch_DictionaryItems data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(List<string> ids)
        {
            await DeleteAsync(ids);
        }

        public async Task<List<SelectOption>> GetOptionListAsync(string dictionaryCode)
        {
            if (dictionaryCode.IsNullOrEmpty())
                return null;
            else
            {
                var dictionary = Service.GetIQueryable<IsMatch_Dictionary>().FirstOrDefault(p => p.DictionaryCode == dictionaryCode);

                if(dictionary == null)
                {
                    return null;
                }

                PageInput<IsMatch_DictionaryItemsInputDTO> input = new PageInput<IsMatch_DictionaryItemsInputDTO>
                {
                    Search = new IsMatch_DictionaryItemsInputDTO
                    {
                        DictionaryId = dictionary.Id
                    }
                };
                var list = (await GetDataListAsync(input)).Data;

                var newlist = new List<SelectOption>();
                list.ForEach(p=> 
                {
                    newlist.Add(new SelectOption
                    {
                        value = p.DictionaryItemCode,
                        text = p.DictionaryItemText
                    }); ;
                });

                return newlist;               
            }
        }

        #endregion

        #region 私有成员

        #endregion
    }
}