using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Seedwork.Repository
{
    public interface IPersistableRepository
    {
        void PersistChanges();
    }
}
