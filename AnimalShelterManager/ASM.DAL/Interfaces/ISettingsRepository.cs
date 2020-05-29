using ASM.Data;
using System;
using System.Collections.Generic;

namespace ASM.DAL.Interfaces
{
    public interface ISettingsRepository
    {
        IEnumerable<Settings> GetAll();
        Settings GetById(Guid id);
        Settings Update(Settings entry);

        Settings Add(Settings entry);

        void Commit();
    }
}
