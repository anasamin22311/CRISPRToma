using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CRISPR.Models;

namespace CRISPR.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CRISPR.Models.Comment> Comment { get; set; }
        public DbSet<CRISPR.Models.DataSet> DataSet { get; set; }
        public DbSet<CRISPR.Models.GeneCode> GeneCode { get; set; }
        public DbSet<CRISPR.Models.Prop> Prop { get; set; }
    }
}