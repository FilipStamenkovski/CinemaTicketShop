using Cinema.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Domain.DomainModels
{
    public class CinemaCart : BaseEntity
    {
        public string OwnerId { get; set; }
        public CinemaApplicationUser Owner { get; set; }
        public virtual ICollection<TicketInCinemaCart> TicketInCarts { get; set; }
        public CinemaCart() { }
    }
}
