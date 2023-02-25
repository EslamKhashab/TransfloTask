using Microsoft.AspNetCore.Mvc;
using TransfloTask.Business.Services.DriverService;
using TransfloTask.Data.Entites;

namespace TransfloTask.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet("Get")]
        public IEnumerable<Driver> Get()
        {
            return _driverService.Get();
        }

        [HttpGet("Get/{id}")]
        public Driver Get(int id)
        {
            return _driverService.Get(id);
        }

        [HttpGet("GetAlphabetizedName/{id}")]
        public string GetAlphabetizedName(int id)
        {
            return _driverService.GetAlphabetizedName(id);
        }

        [HttpPost("Create")]
        public void Create(Driver request)
        {
            _driverService.Create(request);
        }

        [HttpPut("Update")]
        public void Update(Driver request)
        {
            _driverService.Update(request);
        }

        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            _driverService.Delete(id);
        }
    }
}