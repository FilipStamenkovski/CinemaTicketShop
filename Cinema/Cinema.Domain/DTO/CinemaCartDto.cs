using Cinema.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Domain.DTO
{
    public class CinemaCartDto
    {
        public List<TicketInCinemaCart> TicketInCinemaCarts { get; set; }
        public double TotalPrice { get; set; }
    }
}
