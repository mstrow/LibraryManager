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
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ModelContext context) : base(context)
        {
        }

        protected virtual IQueryable<Customer> All
        {
            get
            {
                return Context.Set<Customer>().Include(a => a.Reservations);
            }
        }


        public virtual void Add(Customer instance)
        {
            if (instance != null)
            {
                Context.Set<Customer>().Add(instance);
            }
        }

        public virtual Customer Get(int id)
        {
            return All.FirstOrDefault(a => a.ID == id);
        }

        public virtual void Delete(int id)
        {
            Delete(Get(id));
        }


        public virtual void Delete(Customer instance)
        {
            if (instance != null)
            {
                Context.Entry(instance).State = EntityState.Deleted;
            }
        }


        public virtual void Update(Customer instance)
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
