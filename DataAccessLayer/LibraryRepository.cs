using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class LibraryRepository : Repository<Library>, ILibraryRepository
    {
        public LibraryRepository(ModelContext context) : base(context)
        {
        }

        protected virtual IQueryable<Library> All
        {
            get
            {
                return Context.Set<Library>();
            }
        }


        public virtual void Add(Library instance)
        {
            if (instance != null)
            {
                Context.Set<Library>().Add(instance);
            }
        }

        public virtual Library Get(int id)
        {
            return All.Include(a => a.Books).FirstOrDefault(a => a.ID == id);
        }

        public virtual void Delete(int id)
        {
            Delete(Get(id));
        }


        public virtual void Delete(Library instance)
        {
            if (instance != null)
            {
                Context.Entry(instance).State = EntityState.Deleted;
            }
        }


        public virtual void Update(Library instance)
        {
            if (instance != null)
            {
                Context.Entry(instance).State = EntityState.Modified;
            }
        }


        public virtual IEnumerable List()
        {
            return All.ToList();
        }

    }
}
