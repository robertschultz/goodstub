using NHibernate;
using NHibernate.Criterion;

namespace Goodstub.Data.Repository
{
    public class Repository<T> : IRepository<T>
    {
        #region IRepository<User> Members

        void IRepository<T>.Save(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        void IRepository<T>.Update(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(entity);
                    transaction.Commit();
                }
            }
        }

        void IRepository<T>.Delete(T entity)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(entity);
                    transaction.Commit();
                }
            }
        }

        T IRepository<T>.GetById(long id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.CreateCriteria(typeof(T)).Add(Restrictions.Eq(typeof(T).Name + "Id", id)).SetCacheMode(CacheMode.Normal).SetCacheable(true).UniqueResult<T>();
            }
        }

     

        #endregion
    }
}
