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
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ModelContext context) : base(context)
        {
        }

        protected virtual IQueryable<Book> All
        {
            get
            {
                return Context.Set<Book>();
            }
        }

        public virtual void Add(Book instance)
        {
            if (instance != null)
            {
                Context.Set<Book>().Add(instance);
            }
        }

        public virtual Book Get(int id)
        {
            return All.FirstOrDefault(a => a.ID == id);

        }


        public virtual void Delete(int id)
        {
            Delete(Get(id));
        }


        public virtual void Delete(Book instance)
        {
            if (instance != null)
            {
                Context.Entry(instance).State = EntityState.Deleted;
            }
        }


        public virtual void Update(Book instance)
        {
            if (instance != null)
            {
                Context.Entry(instance).State = EntityState.Modified;
            }
        }

        public virtual IEnumerable List<T>()
        {
            return All.OfType<T>().ToList();
        }
        public virtual IEnumerable<T> List<T>(int artistID)
        {
            //Filter by the artist and specified type i.e. Painting
            return All.Where(a => a.ID == artistID)
                .OfType<T>()
                .ToList();
        }

    }
}
