using Microsoft.AspNetCore.Mvc;

namespace RestAspNet.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculadoraController : ControllerBase
{
   
    private readonly ILogger<CalculadoraController> _logger;

    public CalculadoraController(ILogger<CalculadoraController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Get(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
       return BadRequest("Envio invalido");
    }

    [HttpGet("subtracao/{firstNumber}/{secondNumber}")]
    public IActionResult Subtracao(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
       return BadRequest("Envio invalido");
    }

    [HttpGet("div/{firstNumber}/{secondNumber}")]
    public IActionResult Divisao(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
       return BadRequest("Envio invalido");
    }

    [HttpGet("mult/{firstNumber}/{secondNumber}")]
    public IActionResult Multiplicacao(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
       return BadRequest("Envio invalido");
    }

    [HttpGet("media/{firstNumber}/{secondNumber}")]
    public IActionResult Media(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;
            return Ok(sum.ToString());
        }
       return BadRequest("Envio invalido");
    }

    [HttpGet("raiz/{firstNumber}")]
    public IActionResult Raiz(string firstNumber)
    {
        if (IsNumeric(firstNumber))
        {
            var sum = Math.Sqrt((double)ConvertToDecimal(firstNumber));
            return Ok(sum.ToString());
        }
       return BadRequest("Envio invalido");
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
        return isNumber;
    }

    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;
        if (decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }
        return 0;   
    }

    
}
