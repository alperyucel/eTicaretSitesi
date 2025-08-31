using AlisverisLab.Entity.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.DataAccess.DbContext
{
    public class AlisverisLabLOGDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AlisverisLabLOGDbContext()
        {
            
        }
        public AlisverisLabLOGDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=AlisverisLabLOGDB;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogType>().HasData(
                new LogType {Id=1,Active=true,CreatedTime=DateTime.Now,UpdatedTime=DateTime.Now,LogTypeName="Insert"
                },
                new LogType
                {
                    Id = 2,
                    Active = true,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    LogTypeName = "Update"
                },
                new LogType
                {
                    Id = 3,
                    Active = true,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    LogTypeName = "Delete"
                },
                new LogType
                {
                    Id = 4,
                    Active = true,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    LogTypeName = "Error"
                },
                new LogType
                {
                    Id = 5,
                    Active = true,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    LogTypeName = "Warning"
                },
                new LogType
                {
                    Id = 6,
                    Active = true,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    LogTypeName = "Non Validation"
                },
                 new LogType
                 {
                     Id = 7,
                     Active = true,
                     CreatedTime = DateTime.Now,
                     UpdatedTime = DateTime.Now,
                     LogTypeName = "Not Found"
                 }
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Log> Logs { get; set; }
        public DbSet<LogType> LogTypes { get; set; }
    }
}
