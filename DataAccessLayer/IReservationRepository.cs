using DataAccessLayer.Models;
using System.Collections;

namespace DataAccessLayer
{
    public interface IReservationRepository
    {
        void Add(Reservation instance);
        void Delete(int id);
        void Delete(Reservation instance);
        Reservation Get(int id);
        IEnumerable List();
        void Update(Reservation instance);
    }
}