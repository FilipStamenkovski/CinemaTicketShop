using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Domain.DomainModels
{
    public class TicketInCinemaCart : BaseEntity
    {
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public Guid CinemaCartId { get; set; }
        public CinemaCart CinemaCart { get; set; }
        public int Quantity { get; set; }
    }
}
