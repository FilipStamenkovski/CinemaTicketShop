using Cinema.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Services.Interface
{
    public interface ICinemaCartService
    {
        CinemaCartDto getCinemaCartInfo(string userId);
        bool deleteTicketFromCinemaCart(string userId, Guid id);
        bool orderNow(string userId);
    }
}
