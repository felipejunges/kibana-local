using elastik_kibana.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace elastik_kibana.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var teste = new
            {
                nome = "testee",
                numero = 31
            };

            _logger.LogInformation("Mensagem: {mensagem} - Usuário: {usuario} - Objeto: {objeto}", "Acessou Privacy", "Felipe Junges", teste);

            return View();
        }

        public IActionResult Aviso()
        {
            _logger.LogWarning("Aviso!");

            return Ok();
        }

        public IActionResult Erro()
        {
            try
            {
                throw new Exception("Ocorreu um erro ao carregar controller sem view.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Xi, parece ter ocorrido algum erro.");
            }

            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
