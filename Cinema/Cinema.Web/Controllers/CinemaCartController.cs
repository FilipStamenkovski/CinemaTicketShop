using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cinema.Repository;
using Cinema.Domain.DomainModels;
using Cinema.Domain.DTO;
using Cinema.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.Services.Interface;
using Stripe;

namespace Cinema.Web.Controllers
{
    [Authorize]
    public class CinemaCartController : Controller
    {
        private readonly ICinemaCartService _cinemaCartService;

        public CinemaCartController(ICinemaCartService cinemaCartService)
        {
            _cinemaCartService = cinemaCartService;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(this._cinemaCartService.getCinemaCartInfo(userId));
        }

        public IActionResult PayOrder(string stripeEmail, string stripeToken)
        {
            var customerService = new CustomerService();
            var chargeService = new ChargeService();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var order = this._cinemaCartService.getCinemaCartInfo(userId);

            var customer = customerService.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = chargeService.Create(new ChargeCreateOptions
            {
                Amount = (Convert.ToInt32(order.TotalPrice) * 100),
                Description = "Cinema Application Payment",
                Currency = "mkd",
                Customer = customer.Id
            });

            if (charge.Status == "succeeded")
            {
                var result = this.OrderNow();

                if (result)
                {
                    return RedirectToAction("Index", "CinemaCart");
                }
                else
                {
                    return RedirectToAction("Index", "CinemaCart");
                }
            }

            return RedirectToAction("Index", "CinemaCart");
        }

        public IActionResult DeleteFromCinemaCart(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._cinemaCartService.deleteTicketFromCinemaCart(userId, id);

            if (result)
            {
                return RedirectToAction("Index", "CinemaCart");
            }
            else
            {
                return RedirectToAction("Index", "CinemaCart");
            }
        }

        private Boolean OrderNow()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._cinemaCartService.orderNow(userId);

            return result;
        }
    }
}