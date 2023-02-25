using TransfloTask.Data.Entites;

namespace TransfloTask.Business.Services.DriverService
{
    public interface IDriverService
    {
        IEnumerable<Driver> Get();
        Driver Get(int id);
        string GetAlphabetizedName(int id);
        void Create(Driver driver);
        void Update(Driver driver);
        void Delete(int id);
    }
}
