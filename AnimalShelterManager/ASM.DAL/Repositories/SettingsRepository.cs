using ASM.DAL.Interfaces;
using ASM.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASM.DAL.Repositories
{
    public class SettingsRepository : BaseRepository<Settings>, ISettingsRepository
    {
        public SettingsRepository(DataContext context) : base(context)
        {
        }

        public override IEnumerable<Settings> GetAll()
        {
            return this.Context.Settings;
        }

        public override IQueryable<Settings> GetAll(bool asyn = true)
        {
            throw new NotImplementedException();
        }

        public override Settings GetById(Guid id)
        {
            return this.Context.Settings                
                .FirstOrDefault(x => x.Id == id);
        }

        public override Settings ToggleActive(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
