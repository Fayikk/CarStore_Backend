using CarStore.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private static readonly List<Car> cars= new List<Car>() { new Car { Brand="Audi",Model="A5",Price=50000 } } ;

        [HttpGet]
        public ActionResult<List<Car>> GetAllCars()
        {
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCarById(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public ActionResult<Car> AddCar([FromBody] Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            car.Id = cars.Count > 0 ? cars.Max(c => c.Id) + 1 : 1; 
            cars.Add(car);
            return CreatedAtAction(nameof(GetCarById), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public ActionResult<Car> UpdateCar(int id, [FromBody] Car updatedCar)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            car.Brand = updatedCar.Brand;
            car.Model = updatedCar.Model;
            car.Price = updatedCar.Price;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCar(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            cars.Remove(car);
            return NoContent();
        }



    }
}
