using Journal.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public interface IArticleTemplateService
    {
        Task<IEnumerable<ArticleTemplateDto>> Getall();
        Task<ArticleTemplateDto> GetById(object id);
        // Task<T> GetByCategory(Object categoryId);
        Task Insert(ArticleTemplateDto obj);
        Task Update(ArticleTemplateDto obj, object id);
        Task Delete(Guid id);
    }
}
