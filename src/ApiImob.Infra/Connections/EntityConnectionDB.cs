using ApiImob.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ApiImob.Infra.Connections
{
    public class EntityConnectionDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(config.GetConnectionString("ConectaDB"));
            }
        }

        #region DbSets
        public DbSet<ImoveisModel> ImoveisDbSet { get; set; }
        public DbSet<CidadesModel> CidadesDbSet { get; set; }
        #endregion
    }
}
