using TransfloTask.Data.Entites;
using TransfloTask.Data.Repositories;

namespace TransfloTask.Business.Services.DriverService
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _repository;
        public DriverService(IDriverRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Driver> Get()
        {
            return _repository.GetAllDrivers();
        }
        public Driver Get(int id)
        {
            return _repository.GetDriverById(id);
        }
        public string GetAlphabetizedName(int id)
        {
            var driver = _repository.GetDriverById(id);
            string firstName = new string(driver.FirstName.OrderBy(c => c.ToString(), StringComparer.OrdinalIgnoreCase).ToArray());
            string lastName = new string(driver.LastName.OrderBy(c => c.ToString(), StringComparer.OrdinalIgnoreCase).ToArray());
            return firstName + " " + lastName;
        }

        public void Create(Driver driver)
        {
            _repository.InsertDriver(driver);
        }

        public void Update(Driver driver)
        {
            _repository.UpdateDriver(driver);
        }

        public void Delete(int id)
        {
            _repository.DeleteDriver(id);
        }
    }
}