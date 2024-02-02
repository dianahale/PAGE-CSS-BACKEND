using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PageCss.Core.Entities;

namespace PageCss.DataAccess
{
    public class PageCssContext: IdentityDbContext
    {
        public virtual DbSet<User> Users { get; set; }

        public PageCssContext(DbContextOptions<PageCssContext> options) : base(options)
        {

        }

    }
}
