using TransfloTask.Data.Entites;

namespace TransfloTask.Data.Repositories
{
    public interface IDriverRepository
    {
        IEnumerable<Driver> GetAllDrivers();
        Driver GetDriverById(int id);
        void InsertDriver(Driver driver);
        void UpdateDriver(Driver driver);
        void DeleteDriver(int id);
    }
}