using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using PowerScribble.Api.Domain.Entities;
using PowerScribble.Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PowerScribble.Api.Persistance.Data
{
    public class PowerScribbleDbContext : DbContext
    {


        #region "Properties"

        protected readonly IConfiguration Configuration;


        public DbSet<ApiConfigItem> ApiConfigItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuthorType> AuthorTypes { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Page> Pages { get; set; }

        #endregion



        public PowerScribbleDbContext(DbContextOptions<PowerScribbleDbContext> options, IConfiguration configuration)
            : base(options)
        {
            this.Configuration = configuration;            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }


        public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        {
            OnBeforeSaving();
            return base.Add(entity);
        }

        public override EntityEntry Add(object entity)
        {
            OnBeforeSaving();
            return base.Add(entity);
        }

        public override ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.AddAsync(entity, cancellationToken);
        }

        public override ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.AddAsync(entity, cancellationToken);
        }

        public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
        {
            return base.Remove(entity);
        }

        public override EntityEntry Remove(object entity)
        {
            return base.Remove(entity);
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        void OnBeforeSaving()
        {

            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {

                if (entry.Entity.GetType().GetGenericTypeDefinition() == typeof(IEntity<>))
                {
                    IEntity<object> trackable = (IEntity<object>)entry.Entity;
                    switch (entry.State)
                    {
                        case EntityState.Modified:

                            trackable.ModifiedDateTime = utcNow;

                            // do not allow CreatedDateTime to be modified after the record is created
                            entry.Property("CreatedDateTime").IsModified = false;
                            break;

                        case EntityState.Added:
                            trackable.CreatedDateTime = utcNow;
                            trackable.ModifiedDateTime = utcNow;
                            break;
                    }
                }
            }
        }


    }

}
