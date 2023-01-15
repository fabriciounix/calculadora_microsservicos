using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace RestAspNet.Controllers;

[ApiController]
[Route("[controller]")]
public class CarroController : ControllerBase
{
   
    private readonly ILogger<CarroController> _logger;

    public CarroController(ILogger<CarroController> logger)
    {
        _logger = logger;
    }

    public class Auto
    {
        public string Tipo { get; set; }
        public string Modelo { get; set; }

        public string Marca { get; set; }
    }

    [HttpGet("lista")]
    public IActionResult Get()
    {
        List <Auto> modelos = new List<Auto>();
        modelos.Add(new Auto() {Tipo = "Carro", Modelo = "Gol", Marca = "Volks Wagen"});
        modelos.Add(new Auto() {Tipo = "Carro", Modelo = "Celta", Marca = "Chevrolet"});
        modelos.Add(new Auto() {Tipo = "Carro", Modelo = "Palio", Marca = "FIAT"});
        modelos.Add(new Auto() {Tipo = "Carro", Modelo = "Polo", Marca = "Volks Wagen"});

        string json = JsonSerializer.Serialize(modelos);

        return Ok(json);
    }

   

    
}
