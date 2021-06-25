using System;
using System.Collections.Generic;
using System.Text;
using Cinema.Domain.DomainModels;
using Cinema.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Repository
{
    public class ApplicationDbContext : IdentityDbContext<CinemaApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<CinemaCart> CinemaCarts { get; set; }
        public virtual DbSet<TicketInCinemaCart> TicketInCinemaCarts { get; set; }
        public virtual DbSet<TicketInOrder> TicketInOrders { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Ticket>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<CinemaCart>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            //builder.Entity<TicketInCinemaCart>()
            //    .HasKey(ticc => new { ticc.TicketId, ticc.CinemaCartId });

            builder.Entity<TicketInCinemaCart>()
                .HasOne(z => z.Ticket)
                .WithMany(t => t.TicketInCarts)
                .HasForeignKey(z => z.TicketId);
            //.WithMany(z => z.TicketInCarts)
            //.HasForeignKey(z => z.CinemaCartId);

            builder.Entity<TicketInCinemaCart>()
                .HasOne(z => z.CinemaCart)
                .WithMany(t => t.TicketInCarts)
                .HasForeignKey(z => z.CinemaCartId);
            //.WithMany(z => z.TicketInCarts)
            //.HasForeignKey(z => z.TicketId);

            builder.Entity<CinemaCart>()
                .HasOne<CinemaApplicationUser>(z => z.Owner)
                .WithOne(zt => zt.UserCart)
                .HasForeignKey<CinemaCart>(bc => bc.OwnerId);

            //builder.Entity<TicketInOrder>()
            //    .HasKey(tio => new { tio.TicketId, tio.OrderId });

            builder.Entity<TicketInOrder>()
                .HasOne(z => z.SelectedTicket)
                .WithMany(t => t.TicketInOrders)
                .HasForeignKey(z => z.TicketId);

            builder.Entity<TicketInOrder>()
                .HasOne(z => z.UserOrder)
                .WithMany(t => t.TicketInOrders)
                .HasForeignKey(z => z.OrderId);
        }
    }
}
