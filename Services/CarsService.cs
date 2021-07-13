using System;
using System.Collections.Generic;
using greg.Data;
using greg.Models;

namespace greg.Services
{
  public class CarsService
  {
    public List<Car> GetAll()
    {
      return FakeDb.Cars;
    }

    public Car GetCarById(int id)
    {
      return FakeDb.Cars.Find(c => c.Id == id);
    }

    public Car CreateCar(Car carData)
    {
      var r = new Random();
      carData.Id = r.Next(10000, 99999);
      FakeDb.Cars.Add(carData);
      return carData;
    }

    public Car UpdateCar(Car carData, int id)
    {
      var car = FakeDb.Cars.Find(c => c.Id == id);
      FakeDb.Cars.Remove(car);
      carData.Id = car.Id;
      car = carData;
      FakeDb.Cars.Add(car);
      return car;
    }

    public Car DeleteCar(int id) 
    {
      var car = FakeDb.Cars.Find(car => car.Id == id);
      if(car == null)
      {
        throw new Exception("Invalid Id");
      }
      FakeDb.Cars.Remove(car);
      return car;
    }
  }
}