using System;
namespace drone_management.Services
{
	public interface IDroneService
	{
		public void Create(string name);
		public void Delete(int id);
	}
}

