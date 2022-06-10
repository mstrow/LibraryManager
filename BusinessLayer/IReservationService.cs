using Models;
using System.Collections;

namespace BusinessLayer
{
    public interface IReservationService
    {
        int Add(ReservationModel reservation);
        void Delete(int id);
        ReservationModel Get(int id);
        IList<ReservationModel> List();
        IEnumerable ListNames();
        int Update(ReservationModel model);
    }
}