using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Domain.DomainModels
{
    public class Ticket : BaseEntity
    {
        public string MovieName { get; set; }
        public string MovieImage { get; set; }
        public string MovieGenre { get; set; }
        public double MoviePrice { get; set; }
        //[DataType(DataType.Date)]
        public DateTime? MovieTime { get; set; }
        public virtual ICollection<TicketInCinemaCart> TicketInCarts { get; set; }
        public virtual ICollection<TicketInOrder> TicketInOrders { get; set; }
        public Ticket() { }
    }
}
