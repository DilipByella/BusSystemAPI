using Microsoft.EntityFrameworkCore;
using BusSystem.API.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.API.Data
{
    public class BusDbContext : DbContext
    {
        public BusDbContext(DbContextOptions<BusDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Bus> buses { get; set; }
        public virtual DbSet<Quota> quotas { get; set; }
        public virtual DbSet<Booking> bookings { get; set; }
        public virtual DbSet<Tickets> tickets { get; set; }
        public virtual DbSet<User> users { get; set; }
        public virtual DbSet<Seat> seat { get; set; }
        public virtual DbSet<BankCred> bankCred { get; set; }
        public virtual DbSet<Transaction> transaction { get; set; }
        public virtual DbSet<Passenger> passenger { get; set; }
    }
}