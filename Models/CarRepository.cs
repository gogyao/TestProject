using System.Collections.Concurrent;

namespace Test.Models
{
    public class CarRepository : ICarRepository
    {
        private static ConcurrentDictionary<string, Car> _cars =
            new ConcurrentDictionary<string, Car>();
        public CarRepository()
        {
            Create(new Car { Id = "0", Mark = "Toyota", Model = "Camry", Weight = 1400, ImageUrl = "https://ekb.arendacar.ru/wp-content/uploads/sites/3/2023/12/4d958d8a5f59fa20943b09da1bc3ac2f.jpg" });
            Create(new Car { Id = "1", Mark = "Honda", Model = "Civic", Weight = 1250, ImageUrl = "https://www.livecars.ru/l/news/2019/03/10/honda_civic_type_r/picture.jpg?1552201457" });
            Create(new Car { Id = "2", Mark = "Ford", Model = "Mustang", Weight = 1650, ImageUrl = "https://s.auto.drom.ru/img4/catalog/photos/fullsize/ford/mustang/ford_mustang_120501.jpg" });
            Create(new Car { Id = "3", Mark = "Chevrolet", Model = "Impala", Weight = 1580, ImageUrl= "https://ddaudio.com.ua/assets/galleries/74354/594/77ysggsvscv.jpg" });
            Create(new Car { Id = "4", Mark = "BMW", Model = "320i", Weight = 1500, ImageUrl = "https://images.carexpert.com.au/resize/3000/-/app/uploads/2023/02/BMW-320i-Sedan-M-Sport-HERO-16x9-1.jpg" });
            Create(new Car { Id = "5", Mark = "Mercedes", Model = "C200", Weight = 1480, ImageUrl= "https://renty.ae/uploads/car/photo/l/black_mercedes-c-class_2022_5298_main_4532c2900756ffe263a3a43246d7b707.jpg" });
            Create(new Car { Id = "6", Mark = "Audi", Model = "A4", Weight = 1520, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/35/Audi_A4_B9_sedans_%28FL%29_1X7A2441.jpg/1200px-Audi_A4_B9_sedans_%28FL%29_1X7A2441.jpg" });
            Create(new Car { Id = "7", Mark = "Hyundai", Model = "Elantra", Weight = 1300, ImageUrl = "https://kz.bex-auto.com/storage/products/-5zkk5xvf.jpg" });
            Create(new Car { Id = "8", Mark = "Kia", Model = "Optima", Weight = 1350, ImageUrl = "https://avatars.mds.yandex.net/get-verba/997355/2a000001710bb3ee5298211e10994bf056c8/cattouchret" });
            Create(new Car { Id = "9", Mark = "Volkswagen", Model = "Passat", Weight = 1450, ImageUrl = "https://rg.ru/uploads/images/227/17/36/volkswagen_passat_highline_29.jpeg" });
        }
        public IEnumerable<Car> GetAll()
        {
            return _cars.Values;
        }
        public void Create(Car car)
        {
            //car.Id = Guid.NewGuid().ToString();
            _cars[car.Id] = car;
        }
        public void UpdateCar(Car car)
        {
            _cars[car.Id] = car;
        }
        public Car GetCar(string id)
        {
            Car car;
            _cars.TryGetValue(id, out car);
            return car;
        }

        public Car DeleteCar(string id)
        {
            Car car;
            _cars.TryRemove(id, out car);
            return car;
        }
    }
}
