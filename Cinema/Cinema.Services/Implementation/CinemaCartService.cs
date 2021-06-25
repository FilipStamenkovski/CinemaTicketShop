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
    public class CinemaCartService : ICinemaCartService
    {
        private readonly IRepository<CinemaCart> _cinemaCartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<EmailMessage> _mailRepository;
        private readonly IRepository<TicketInOrder> _ticketInOrderRepository;
        private readonly IUserRepository _userRepository;
        public CinemaCartService(IRepository<CinemaCart> cinemaCartRepository, IRepository<Order> orderRepository, IRepository<EmailMessage> mailRepository, IRepository<TicketInOrder> ticketInOrderRepository, IUserRepository userRepository)
        {
            _cinemaCartRepository = cinemaCartRepository;
            _orderRepository = orderRepository;
            _mailRepository = mailRepository;
            _ticketInOrderRepository = ticketInOrderRepository;
            _userRepository = userRepository;
        }
        public bool deleteTicketFromCinemaCart(string userId, Guid id)
        {
            if (!string.IsNullOrEmpty(userId) && id != null)
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userCart = loggedInUser.UserCart;

                //var ticketToDelete = userCart.TicketInCarts.Where(z => z.TicketId == id).FirstOrDefault();

                userCart.TicketInCarts.Remove(userCart.TicketInCarts.Where(z => z.TicketId == id).FirstOrDefault());

                this._cinemaCartRepository.Update(userCart);

                return true;
            }
            return false;
        }

        public CinemaCartDto getCinemaCartInfo(string userId)
        {
            var loggedInUser = this._userRepository.Get(userId);

            var userCart = loggedInUser.UserCart;

            //var allTickets = userCart.TicketInCarts.ToList();

            var ticketPrice = userCart.TicketInCarts.Select(z => new
            {
                TicketPrice = z.Ticket.MoviePrice,
                Quantity = z.Quantity
            }).ToList();

            var totalPrice = 0.0;

            foreach (var item in ticketPrice)
            {
                totalPrice += item.Quantity * item.TicketPrice;
            }

            // Select Ticket from Users JOIN UserCart....

            //var allTickets = userCart.TicketInCarts.Select(z => z.Ticket).ToList();

            CinemaCartDto cinemaCartDtoItem = new CinemaCartDto
            {
                TicketInCinemaCarts = userCart.TicketInCarts.ToList(),
                TotalPrice = totalPrice
            };

            return cinemaCartDtoItem;
        }

        public bool orderNow(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userCart = loggedInUser.UserCart;

                EmailMessage message = new EmailMessage();
                message.MailTo = loggedInUser.Email;
                message.Subject = "Successfully created order!";
                message.Status = false;

                Order orderItem = new Order
                {
                    Id = Guid.NewGuid(),
                    User = loggedInUser,
                    UserId = userId
                };

                this._orderRepository.Insert(orderItem);
                //await _context.SaveChangesAsync();

                List<TicketInOrder> ticketInOrders = new List<TicketInOrder>();

                ticketInOrders = userCart.TicketInCarts
                    .Select(z => new TicketInOrder
                    {
                        OrderId = orderItem.Id,
                        UserOrder = orderItem,
                        SelectedTicket = z.Ticket,
                        TicketId = z.Ticket.Id,
                        Quantity = z.Quantity
                    }).ToList();

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Your order is completed. The order contains: ");

                var totalPrice = 0.0;

                for (int i = 1; i <= userCart.TicketInCarts.Count; i++)
                {
                    var item = userCart.TicketInCarts.ElementAt(i - 1);
                    totalPrice += item.Quantity * item.Ticket.MoviePrice;
                    sb.AppendLine(i.ToString() + ". " + item.Ticket.MovieName + " with ticket time: " + item.Ticket.MovieTime + ", with price of: " + item.Ticket.MoviePrice + " and quantity: " + item.Quantity);
                }

                sb.AppendLine("Total price: " + totalPrice.ToString());

                message.Content = sb.ToString();

                foreach (var item in ticketInOrders)
                {
                    this._ticketInOrderRepository.Insert(item);
                    //await _context.SaveChangesAsync();
                }

                //await _context.SaveChangesAsync();

                loggedInUser.UserCart.TicketInCarts.Clear();

                this._mailRepository.Insert(message);

                this._userRepository.Update(loggedInUser);

                return true;
            }
            return false;
        }
    }
}
