using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCount.Contracts;
using TravelCount.Logic.Entities;
using TravelCount.Logic.Entities.Persistence;

namespace TravelCount.Logic.DataContext.Db
{
    internal class DbTravelCountContext : DbContext, IContext, ITravelCountContext
    {
        private static string ConnectionString { get; set; } = "Data Source=(localdb)\\MSSQLLocalDb;Database=TravelCountDb;Integrated Security=True;";

        public IEnumerable<Travel> Travels => TravelSet;
        public IEnumerable<Expense> Expenses => ExpenseSet;
        public DbSet<Travel> TravelSet { get; set; }
        public DbSet<Expense> ExpenseSet { get; set; }

        public Task<int> CountAsync<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, I
        {
            return Set<E>().CountAsync();
        }
        public Task<E> CreateAsync<I, E>()
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
            return Task.Run(() => new E());
        }

        public Task<E> InsertAsync<I, E>(E entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
            return Task.Run(() =>
            {
                Set<E>().Add(entity);
                return entity;
            });
        }
        public Task<E> UpdateAsync<I, E>(E entity)
            where I : IIdentifiable
            where E : IdentityObject, ICopyable<I>, I, new()
        {
            return Task.Run(() =>
            {
                Set<E>().Update(entity);
                return entity;
            });
        }
        public Task<E> DeleteAsync<I, E>(int id)
            where I : IIdentifiable
            where E : IdentityObject, I
        {
            return Task.Run(() =>
            {
                E result = Set<E>().SingleOrDefault(i => i.Id == id);

                if (result != null)
                {
                    Set<E>().Remove(result);
                }
                return result;
            });
        }

        public Task SaveAsync()
        {
            return SaveChangesAsync();
        }

        #region Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Travel>()
                .ToTable(nameof(Travel))
                .HasKey(p => p.Id);
            modelBuilder.Entity<Travel>()
                .HasIndex(p => p.Designation)
                .IsUnique();
            modelBuilder.Entity<Travel>()
                .Property(p => p.Designation)
                .IsRequired()
                .HasMaxLength(256);
            modelBuilder.Entity<Travel>()
                .Property(p => p.Description)
                .HasMaxLength(256);
            modelBuilder.Entity<Travel>()
                .Property(p => p.Currency)
                .IsRequired()
                .HasMaxLength(10);
            modelBuilder.Entity<Travel>()
                .Property(p => p.Friends)
                .IsRequired()
                .HasMaxLength(1024);
            modelBuilder.Entity<Travel>()
                .Property(p => p.Category)
                .IsRequired()
                .HasMaxLength(64);

            modelBuilder.Entity<Expense>()
                .ToTable(nameof(Expense))
                .HasKey(p => p.Id);
            modelBuilder.Entity<Expense>()
                .Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(128);
            modelBuilder.Entity<Expense>()
                .Property(p => p.Friend)
                .IsRequired()
                .HasMaxLength(25);
        }
        #endregion Configuration
    }
}
