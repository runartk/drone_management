using System;
namespace drone_management.Services
{
	public class DroneService : IDroneService
	{
        ILogger<DroneService> _logger;

		public DroneService(Logger<DroneService> logger)
		{
            _logger = logger;
		}

        public void Create(string name)
        {

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

