using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KeyboardComponentCatalog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KeyboardComponentCatalog.DataStores
{
    public class CaseDataStore : ICaseDataStore
    {
        private readonly KeyboardComponentCatalogContext _dbContext;
        private readonly ILogger<CaseDataStore> _logger;

        public CaseDataStore(KeyboardComponentCatalogContext dbContext, ILogger<CaseDataStore> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        
        public async Task<Case> GetCaseById(long id)
        {
            var keyboardCase = await _dbContext.CaseDb.FirstOrDefaultAsync(m => m.Id == id);
            
            if (keyboardCase == null)
            {
                throw new ArgumentException($"No keyboard Case with Id {id} found.");
            }

            return keyboardCase;
        }

        public async Task<ICollection<Case>> GetAllCases()
        {
            return await _dbContext.CaseDb.AsNoTracking().ToListAsync();

        }

        public async Task RemoveCaseById(long id)
        {
            var keyboardCase = await _dbContext.CaseDb.FirstOrDefaultAsync(m => m.Id == id);
            _dbContext.CaseDb.Remove(keyboardCase);
            await _dbContext.SaveChangesAsync();
        }
    }
}