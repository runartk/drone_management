using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DroneController(ILogger<DroneController> logger)
        {
            _logger = logger;
            _droneService = new DroneService();
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
                throw e;
            }

            return "Successfully created new drone with name: " + name;
        }

        [HttpDelete("delete/{id}")]
        public async void Delete(int id)
        {
            try
            {
                _droneService.Delete(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message.ToString());
                throw e;
            }
        }
    }
}

