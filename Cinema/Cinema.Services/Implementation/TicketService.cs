using Cinema.Domain.DomainModels;
using Cinema.Domain.DTO;
using Cinema.Repository.Interface;
using Cinema.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cinema.Services.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<TicketInCinemaCart> _ticketInCinemaCartRepository;
        private readonly IUserRepository _userRepository;
        public TicketService(IRepository<Ticket> ticketRepository, IRepository<TicketInCinemaCart> ticketInCinemaCartRepository, IUserRepository userRepository)
        {
            _ticketRepository = ticketRepository;
            _ticketInCinemaCartRepository = ticketInCinemaCartRepository;
            _userRepository = userRepository;
        }
        public bool AddToCinemaCart(AddToCinemaCartDto item, string userID)
        {
            var user = this._userRepository.Get(userID);

            var userCart = user.UserCart;

            if (item.TicketId != null && userCart != null)
            {
                var ticket = this.GetDetailsForTicket(item.TicketId);

                if (ticket != null)
                {
                    TicketInCinemaCart itemToAdd = new TicketInCinemaCart
                    {
                        TicketId = ticket.Id,
                        Ticket = ticket,
                        CinemaCartId = userCart.Id,
                        CinemaCart = userCart,
                        Quantity = item.Quantity,
                    };

                    this._ticketInCinemaCartRepository.Insert(itemToAdd);
                    return true;
                }
                return false;
            }
            return false;
        }

        public void CreateNewTicket(Ticket t)
        {
            this._ticketRepository.Insert(t); //t.Id = Guid.NewGuid();
        }

        public void DeleteTicket(Guid id)
        {
            var ticket = this.GetDetailsForTicket(id);
            this._ticketRepository.Delete(ticket);
        }

        public List<Ticket> GetAllTickets()
        {
            return this._ticketRepository.GetAll().ToList();
        }

        public List<Ticket> GetAllTicketsByGenre(string genre)
        {
            return GetAllTickets().Where(z => z.MovieGenre.Equals(genre)).ToList();
        }

        public AddToCinemaCartDto GetCinemaCartInfo(Guid? id)
        {
            var ticket = this.GetDetailsForTicket(id);
            AddToCinemaCartDto model = new AddToCinemaCartDto
            {
                SelectedTicket = ticket,
                TicketId = ticket.Id,
                Quantity = 1
            };
            return model;
        }

        public Ticket GetDetailsForTicket(Guid? id)
        {
            return this._ticketRepository.Get(id);
        }

        public void UpdeteExistingTicket(Ticket t)
        {
            this._ticketRepository.Update(t);
        }
    }
}
