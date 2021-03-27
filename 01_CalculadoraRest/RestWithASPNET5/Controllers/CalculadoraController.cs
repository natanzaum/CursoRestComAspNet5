using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASPNET5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet("soma/{numero1}/{numero2}")]
        public IActionResult Soma(string numero1, string numero2)
        {
            if (IsNumeric(numero1) && IsNumeric(numero2))
            {
                var sum = ConvertToDecimal(numero1) + ConvertToDecimal(numero2);
                return Ok(sum.ToString());
            }

            return BadRequest("Parametros inválidos!");
        }

        [HttpGet("subtracao/{numero1}/{numero2}")]
        public IActionResult Subtracao(string numero1, string numero2)
        {
            if (IsNumeric(numero1) && IsNumeric(numero2))
            {
                var subtracao = ConvertToDecimal(numero1) - ConvertToDecimal(numero2);
                return Ok(subtracao.ToString());
            }

            return BadRequest("Parametros inválidos!");
        }

        [HttpGet("multiplicacao/{numero1}/{numero2}")]
        public IActionResult Multiplicacao(string numero1, string numero2)
        {
            if (IsNumeric(numero1) && IsNumeric(numero2))
            {
                var multiplicacao = ConvertToDecimal(numero1) * ConvertToDecimal(numero2);
                return Ok(multiplicacao.ToString());
            }

            return BadRequest("Parametros inválidos!");
        }

        [HttpGet("divisao/{numero1}/{numero2}")]
        public IActionResult Divisao(string numero1, string numero2)
        {
            if (IsNumeric(numero1) && IsNumeric(numero2))
            {
                try
                {
                    var divisao = ConvertToDecimal(numero1) / ConvertToDecimal(numero2);
                    return Ok(divisao.ToString());
                }
                catch
                {
                    return BadRequest("Não pode dividir por 0!");
                }
            }

            return BadRequest("Parametros inválidos!");
        }
     
        [HttpGet("media/{numero1}/{numero2}")]
        public IActionResult Media(string numero1, string numero2)
        {
            if (IsNumeric(numero1) && IsNumeric(numero2))
            {
                var media = (ConvertToDecimal(numero1) + ConvertToDecimal(numero2)) / 2;
                return Ok(media.ToString());
            }

            return BadRequest("Parametros inválidos!");
        }

        [HttpGet("raiz/{numero}")]
        public IActionResult Raiz(string numero)
        {
            if (IsNumeric(numero))
            {
                var raiz = Math.Sqrt((double)ConvertToDecimal(numero));
                return Ok(raiz.ToString());
            }

            return BadRequest("Parametros inválidos!");
        }

        private bool IsNumeric(string numeroStr)
        {
            double numero;
            bool isNumero = double.TryParse(numeroStr, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out numero);

            return isNumero;
        }

        private decimal ConvertToDecimal(string numeroStr)
        {
            if (decimal.TryParse(numeroStr,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimal valorDecimal))
            {
                return valorDecimal;
            }

            return 0;
        }
    }
}
