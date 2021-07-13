using System.Collections.Generic;
using greg.Models;
using greg.Services;
using Microsoft.AspNetCore.Mvc;

namespace greg.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {
    private readonly CarsService _cs;

    public CarsController(CarsService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public List<Car> GetCars()
    {
      return _cs.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetCar(int id)
    {
      try
      {
        var car = _cs.GetCarById(id);
        if(car == null)
        {
          return BadRequest("Invalid Id");
        }
        return Ok(car);
      }
      catch (System.Exception e)
      {
        return Forbid(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Car> CreateCar([FromBody] Car carData)
    {
      try
      {
        var car = _cs.CreateCar(carData);
        return Created("api/cars/" + car.Id, car);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Car> UpdateCar([FromBody] Car carData, int id)
    {
      try
      {
        var car = _cs.UpdateCar(carData, id);
        return Created("api/cars/" + car.Id, car);
      }
      catch (System.Exception e) 
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Car> DeleteCar(int id)
    {
      try
      {
        var car = _cs.DeleteCar(id);
        return Ok(car);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
  
}