using Hungry.Model;
using Hungry.Model.Commom;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hungry.Model
{
    public class HungryContext : DbContext
    {
        public HungryContext()
            : base("Name=HungryContext")
        {

        }

        public DbSet<DBServerUser> DBServerUsers { get; set; }
        public DbSet<LunchSuggestion> LunchSuggestions { get; set; }
        public DbSet<LunchVote> LunchVotes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<DBServerUser>().HasKey<int>(e => e.Id).ToTable("DBServerUser");

            //modelBuilder.Entity<DBServerUser>()
            //.HasMany(e => e.LunchVote)
            //.WithRequired(e => e.DBServerUser)
            //.HasForeignKey(e => e.Id)
            //.WillCascadeOnDelete(false);

            //modelBuilder.Entity<LunchSuggestion>().HasKey<int>(e => e.Id).ToTable("LunchSuggestion");

            //modelBuilder.Entity<LunchSuggestion>()
            //.Property(e => e.Description)
            //.IsFixedLength();

            //modelBuilder.Entity<LunchSuggestion>()
            //.HasMany(e => e.LunchVote)
            //.WithRequired(e => e.LunchSuggestion)
            //.WillCascadeOnDelete(false);
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is IAuditableEntity
                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in modifiedEntries)
            {
                IAuditableEntity entity = entry.Entity as IAuditableEntity;
                if (entity != null)
                {
                    string identityName = Thread.CurrentPrincipal.Identity.Name;
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedBy = identityName;
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedBy = identityName;
                    entity.UpdatedDate = now;
                }
            }

            return base.SaveChanges();
        }
    }
}
