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
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        public ReservationRepository(ModelContext context) : base(context)
        {
        }

        protected virtual IQueryable<Reservation> All
        {
            get
            {
                return Context.Set<Reservation>().Include(a => a.Customer)
                .Include(a => a.Book);
            }
        }


        public virtual void Add(Reservation instance)
        {
            if (instance != null)
            {
                Context.Set<Reservation>().Add(instance);
            }
        }

        public virtual Reservation Get(int id)
        {
            return All.FirstOrDefault(a => a.ID == id);
        }

        public virtual void Delete(int id)
        {
            Delete(Get(id));
        }


        public virtual void Delete(Reservation instance)
        {
            if (instance != null)
            {
                Context.Entry(instance).State = EntityState.Deleted;
            }
        }


        public virtual void Update(Reservation instance)
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
