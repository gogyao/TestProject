using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Conrollers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CarsController : Controller
    {
        private readonly ICarRepository _cars;
        public CarsController(ICarRepository cars)
        {
            _cars = cars;
        }

        [HttpGet]
        public IActionResult Index()
        {
           var cars = _cars.GetAll();
           return View(cars);
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<Car> GetAll()
        {
            return _cars.GetAll();
        }

        [HttpGet]
        [Route("{id}", Name = "GetCarById")]
        public IActionResult GetCarById(string id)
        {
            var car = _cars.GetCar(id);
            if (car == null) 
            {
                return BadRequest();
            }

            return View(car);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            _cars.Create(car);
            return CreatedAtRoute("GetCarById", new {id = car.Id, car});
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdateCar([FromBody] Car car, string id)
        {
            if (car == null)
            {
                return BadRequest();
            }
            if (car.Weight > 1000.0 || car.Weight < 0)
            {
                throw new Exception("Wrong format of weight parameter");
            }

            var car_prev = _cars.GetCar(id);
            if (car_prev == null)
            {
                return NotFound();
            }
            _cars.UpdateCar(car);
            return new NoContentResult();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            var car = _cars.GetCar(id);
            if (car == null) throw new Exception("Car was not found");
            _cars.DeleteCar(id);
            return new NoContentResult();
        }
    }
}