using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using KeyboardComponentCatalog.Models;

namespace KeyboardComponentCatalog.DataStores
{
    public interface ICaseDataStore
    {
        [ItemNotNull]
        public Task<Case> GetCaseById(long id);

        [ItemNotNull]
        public Task<ICollection<Case>> GetAllCases();

        public Task RemoveCaseById(long id);
    }
}