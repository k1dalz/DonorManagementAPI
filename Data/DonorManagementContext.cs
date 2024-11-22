using Microsoft.EntityFrameworkCore;
using DonorManagementAPI.Models;

namespace DonorManagementAPI.Data
{
    public class DonorManagementContext : DbContext
    {
        public DonorManagementContext(DbContextOptions<DonorManagementContext> options) : base(options) { }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<BloodBanks> BloodBanks { get; set; }
    }
}
