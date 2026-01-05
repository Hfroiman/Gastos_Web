using Microsoft.EntityFrameworkCore;
using Web_Gastos.Models;

namespace Web_Gastos.Data
{
    public class SpendSmartDbContext:DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        public SpendSmartDbContext(DbContextOptions<SpendSmartDbContext> option):base(option) 
        {

        }
    }
}
