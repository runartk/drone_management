using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using drone_management.Models;
using drone_management.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace drone_management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DroneController : ControllerBase
    {
        private readonly ILogger<DroneController> _logger;
        private IDroneService _droneService;

        public DroneController(ILogger<DroneController> logger, IDroneService droneService)
        {
            _logger = logger;
            _droneService = droneService;
        }

        // GET: /<controller>/
        [HttpPost("create/{name}")]
        public async Task<string> Create(string name)
        {
            try
            {
                _droneService.Create(name);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message.ToString());
                throw;
            }

            return "Successfully created new drone with name: " + name;
        }

        [HttpGet("drones")]
        public List<DroneModel> GetDrones()
        {
            List<DroneModel> drones;
            try
            {
                drones = _droneService.GetDrones();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message.ToString());
                throw;
            }

            return drones;
        }

        [HttpDelete("delete/{id}")]
        public async void Delete(Guid id)
        {
            try
            {
                _droneService.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message.ToString());
                throw;
            }
        }
    }
}