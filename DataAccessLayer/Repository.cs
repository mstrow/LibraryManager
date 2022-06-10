using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{

    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext Context { get; private set; }

        public Repository(ModelContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Creates a <see cref="DbSet<library>" /> that can be used to query and save instances of <see cref="DbSet<library>" />.
        /// </summary>
        protected virtual IQueryable<T> All
        {
            get
            {
                return Context.Set<T>();
            }
        }

        /// <summary>
        /// Adds an library entity to the context and sets the library entiy state to  <see cref="EntityState.Added" />.
        /// Entities with the added stste will be inserted in the database when SaveChanges() is called.
        /// </summary>
        /// <param name="instance"></param>
        public virtual void Add(T instance)
        {
            if (instance != null)
            {
                Context.Set<T>().Add(instance);
            }
        }

        /// <summary>
        /// Gets an library
        /// </summary>
        /// <param name="id">The library ID</param>
        /// <returns></returns>
        //public virtual T Get(int id);

        /// <summary>
        /// Changes the library entiy state to <see cref="EntityState.Deleted" />.
        /// Entities with the deleted state will be update in the database when Save() is called.
        /// </summary>
        /// <param name="id">The library ID</param>
        public virtual void Delete(int id)
        {
            //Delete(Get(id));
        }

        /// <summary>
        /// Changes the library entiy state to  <see cref="EntityState.Deleted" />.
        /// Entities with the deleted state will be update in the database when Save() is called.
        /// </summary>
        /// <param name="instance"></param>
        public virtual void Delete(T instance)
        {
            if (instance != null)
            {
                Context.Entry(instance).State = EntityState.Deleted;
            }
        }

        /// <summary>
        /// Changes the library entiy state to  <see cref="EntityState.Modified" />.
        /// Entities with the modified stste will be updated in the database when Save() is called.
        /// </summary>
        /// <param name="instance"></param>

        public virtual void Update(T instance)
        {
            if (instance != null)
            {
                Context.Entry(instance).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// Lists the libraries
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> List()
        {
            return All.ToList();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
