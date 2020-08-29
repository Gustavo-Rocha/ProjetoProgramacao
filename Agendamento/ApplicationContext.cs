using Agendamento.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Repositorio
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agenda> Agendamentos { get; set; }



        public ApplicationContext(DbContextOptions<ApplicationContext> options)   : base(options)
        {

        }

        public ApplicationContext()
        {
        }

        //public BaseContext()
        //{

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().HasKey(p => p.cpf);
            modelBuilder.Entity<Agenda>().HasKey(c => c.Data);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AgendamentoDB;Trusted_Connection=true;");
        }

    }
}
