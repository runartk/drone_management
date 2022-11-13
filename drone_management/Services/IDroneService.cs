using System;
using drone_management.Models;

namespace drone_management.Services
{
	public interface IDroneService
	{
		public void Create(string name);
		public List<DroneModel> GetDrones();
        public void Delete(Guid id);
	}
}

