using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Data.Seedwork.DbSnap;
using Infrastructure.Data.Seedwork.Scheduling;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.Loquacious;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;

namespace Infrastructure.Data.Seedwork
{
    public class DatabaseFactory
        : IDatabaseFactory
    {
        private static ISessionFactory sessionFactory;
        private static ISession session;

        public DatabaseFactory(ILoadBalanceScheduling loadBalanceScheduling)
        {
            //根据DbSnapInfo快照连接,创建ISessionFactory
            DbSnapInfo dbSnapInfo = loadBalanceScheduling.GetConnectDbSnap();
            Configuration cfg = new Configuration();
            cfg.SessionFactory().Integrate.Using<MsSql2008Dialect>().Connected.Using(dbSnapInfo.DbconnectString);
            //设置Mapping默认程序集 
            cfg.AddAssembly("Infrastructure.Data.MainBoundedContext");
            //设置proxyfactory
            cfg.SetProperty("proxyfactory.factory_class", "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle");
            //设置缓存程序
            cfg.SetProperty("cache.provider_class", "NHibernate.Cache.HashtableCacheProvider");
            //启动二级缓存
            cfg.SetProperty("cache.use_second_level_cache", "true");
            //启动查询缓存
            cfg.SetProperty("cache.use_query_cache", "true");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public ISession Current()
        {
            if (session == null)
            {
                session = sessionFactory.OpenSession();
            }
            return session;
        }

        private void BuildSchema(Configuration config)
        {
            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config).Execute(false, true, false);
        }
    }
}
