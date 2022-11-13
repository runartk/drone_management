using System;
using drone_management.database;
using drone_management.Models;

namespace drone_management.Services
{
    public class DroneService : IDroneService
    {
        DroneContext _db;

        public DroneService(DroneContext db)
        {
            _db = db;
        }

        public void Create(string name)
        {
            DroneModel drone = new DroneModel();
            drone.Id = Guid.NewGuid();
            drone.Name = name;
            try
            {
                _db.Drones.AddAsync(drone);
                _db.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message, e);
                throw;
            }
        }

        public List<DroneModel> GetDrones()
        {
            try
            {
                return _db.Drones.ToList();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message, e);
                throw;
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                var drone = _db.Drones.Where(d => d.Id == id).SingleOrDefault();
                if (drone != null)
                {
                    _db.Drones.Remove(drone);
                    _db.SaveChangesAsync();
                }
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message, e);
                throw;
            }
        }
    }
}