using Cinema.Domain.DomainModels;
using Cinema.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Services.Interface
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        List<Ticket> GetAllTicketsByGenre(string genre);
        Ticket GetDetailsForTicket(Guid? id);
        void CreateNewTicket(Ticket t);
        void UpdeteExistingTicket(Ticket t);
        AddToCinemaCartDto GetCinemaCartInfo(Guid? id);
        void DeleteTicket(Guid id);
        bool AddToCinemaCart(AddToCinemaCartDto item, string userID);
    }
}
