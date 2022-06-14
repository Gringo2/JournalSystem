using JournalSystem.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Journal.web.Services
{
    public interface IEditorService
    {
        Task<IEnumerable<EditorDto>> Getall();
        Task<EditorDto> GetById(object id);
        // Task<T> GetByCategory(Object categoryId);
        Task Insert(EditorDto obj);
        Task Update(EditorDto obj, object id);
        Task Delete(Guid id);
    }
}
