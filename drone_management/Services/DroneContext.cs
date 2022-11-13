using System;
using System.Configuration;
using drone_management.Models;
using Microsoft.EntityFrameworkCore;

namespace drone_management.database
{
	public class DroneContext : DbContext
	{
		public DbSet<DroneModel> Drones { get; set; }
        protected readonly IConfiguration _configuration;

        public DroneContext(IConfiguration configuration)
		{
            _configuration = (IConfiguration)configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite(_configuration.GetConnectionString("DronesDatabase"));
    }
}