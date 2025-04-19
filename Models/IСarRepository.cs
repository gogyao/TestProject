namespace Test.Models
{
    public interface ICarRepository
    {
        void Create(Car car);
        IEnumerable<Car> GetAll();

        void UpdateCar(Car car);

        Car GetCar(string id);

        Car DeleteCar(string id);
    }
}
