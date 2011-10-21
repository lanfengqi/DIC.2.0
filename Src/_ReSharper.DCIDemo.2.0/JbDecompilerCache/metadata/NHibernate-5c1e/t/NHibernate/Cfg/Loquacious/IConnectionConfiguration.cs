// Type: NHibernate.Cfg.Loquacious.IConnectionConfiguration
// Assembly: NHibernate, Version=3.2.0.4000, Culture=neutral, PublicKeyToken=aa95f207798dfdb4
// Assembly location: E:\030.GitHub\020.DCI.2.0\Src\packages\NHibernate.3.2.0.4000\lib\Net35\NHibernate.dll

using NHibernate;
using NHibernate.Connection;
using NHibernate.Driver;
using System.Data;
using System.Data.Common;

namespace NHibernate.Cfg.Loquacious
{
    public interface IConnectionConfiguration
    {
        IConnectionConfiguration Through<TProvider>() where TProvider : IConnectionProvider;
        IConnectionConfiguration By<TDriver>() where TDriver : IDriver;
        IConnectionConfiguration With(IsolationLevel level);
        IConnectionConfiguration Releasing(ConnectionReleaseMode releaseMode);
        IDbIntegrationConfiguration Using(string connectionString);
        IDbIntegrationConfiguration Using(DbConnectionStringBuilder connectionStringBuilder);
        IDbIntegrationConfiguration ByAppConfing(string connectionStringName);
    }
}
