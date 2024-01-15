using Microsoft.AspNetCore.Mvc;
using apifromscratch.Models;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CarController: ControllerBase{
    //get Database context that allows us to update the database
    private readonly CarsDBContext _context;
    public CarController(CarsDBContext context){
        _context = context;
    }


    //Get every single Car in the database
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CarsModel>>> GetAllCars(){
        if(_context.GetCars == null){
            return NotFound();
        }
        return await _context.GetCars.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CarsModel>> GetCarById(long id){
        if(_context.GetCars == null){
            return NotFound();
        }
        var targetCar = await _context.GetCars.FindAsync(id);
        if(targetCar == null){
            return NotFound();
        }

        return targetCar;
    }

    [HttpPost]
    public async Task<ActionResult<CarsModel>> PostCar(CarsModel car){
        _context.GetCars.Add(car);
        await _context.SaveChangesAsync();  
        return CreatedAtAction(nameof(GetCarById), new {id = car.Id}, car); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCarById(long id){
        if(_context.GetCars == null){
            return NotFound();
        }
        var targetCar = await _context.GetCars.FindAsync(id);
        if(targetCar == null){
            return NotFound();
        }

        _context.GetCars.Remove(targetCar);
        await _context.SaveChangesAsync();

        return NoContent();
    }



}