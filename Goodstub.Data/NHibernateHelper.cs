using FluentNHibernate.Cfg;
using Goodstub.Data.Entity;
using NHibernate;

namespace Goodstub.Data
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {

            //.Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("Mongrala")).Cache(c => c.UseQueryCache().ProviderClass(typeof(NHibernate.Caches.Velocity.VelocityProvider).AssemblyQualifiedName)))
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("Mongrala")))
                        .ExposeConfiguration(cfg =>
                        {
                            //cfg.SetProperty("hibernate.cache.use_second_level_cache", "true");
                            //new SchemaExport(cfg).Create(true, true);
                        })
                        .Mappings(m =>
                        {
                            m.FluentMappings.AddFromAssemblyOf<User>();
                            //m.AutoMappings.Add(
                            //    AutoMap.AssemblyOf<User>(new AutoMappingConfiguration()).UseOverridesFromAssemblyOf<UserOverride>()
                            //);
                        })
                        .BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
