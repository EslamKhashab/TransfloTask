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
            return Sort(driver.FirstName) + " " + Sort(driver.LastName);
        }
        private string Sort(string name)
        {
            char[] chars = name.ToCharArray();            
            Array.Sort(chars, StringComparer.Ordinal);
            string sortedName = new string(chars);
            return sortedName;
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
        private string GetRandomString()
        {
            var chars = "abcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}