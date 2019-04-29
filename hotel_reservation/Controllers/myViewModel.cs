using System.Linq;
using hotel_reservation.Models.EntityFramework;

namespace hotel_reservation.Controllers
{
    internal class myViewModel
    {
        public myViewModel()
        {
        }

        public IQueryable<reservation> reservations { get; set; }
        
    }
}