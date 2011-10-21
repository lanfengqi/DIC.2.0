using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace Infrastructure.Data.Seedwork
{
    public interface IDatabaseFactory
    {
        ISession Current();
    }
}
