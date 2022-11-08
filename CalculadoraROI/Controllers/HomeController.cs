using CalculadoraROI.DataBase;
using CalculadoraROI.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CalculadoraROI.Controllers
{
    public class HomeController : Controller
    {

        private string mensagem = "";

        private readonly ILogger<HomeController> _logger;
        private readonly MySqlConnection _connection;


        public HomeController(ILogger<HomeController> logger, MySqlConnection connection)
        {
            _logger = logger;
            _connection = connection;
        }

        public async Task<IActionResult> Index(string mensagem = null, bool sucesso = true)
        {
            if(sucesso)
                TempData["sucesso"] = mensagem;
            else
                TempData["erro"] = mensagem;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] Calculadora calculadora)
        {
            try
            {

                calculadora.ResultadoRoi = "";

                if (ModelState.IsValid)
                {
                    decimal x, y;

                    x = ((calculadora.ConsultaMes * Convert.ToDecimal(0.02)) * Convert.ToDecimal(calculadora.TicketMedio)) / calculadora.ConsultaMes * 3;
                    y = ((calculadora.ConsultaMes * Convert.ToDecimal(0.03)) * Convert.ToDecimal(calculadora.TicketMedio)) / calculadora.ConsultaMes * 3;

                    calculadora.ResultadoRoi = x.ToString("C").Replace(".",",") + " e " + y.ToString("C").Replace(".", ",");

                    new CalculadoraDB(_connection).Inserir(calculadora);

                    EnviarEmail(calculadora);
                  


                    return RedirectToAction(nameof(Index), new { mensagem = "Email enviado com sucesso!", sucesso = true});

                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                TempData["erro"] = "Algum erro aconteceu! - " + ex.Message;
                return View();
            }
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
         private async Task EnviarEmail(Calculadora calculadora)
        {

            try
            {
                MailMessage mensagem = new MailMessage();
                mensagem.From = new MailAddress("noreply@acertpix.com.br");
                mensagem.To.Add(calculadora.Email);
                mensagem.Subject = "Bem-Vindo!!";
                mensagem.IsBodyHtml = true;
                mensagem.Body = EmailBoasVindas(calculadora.Nome, calculadora.ResultadoRoi);


                var smtpCliente = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("noreply@acertpix.com.br", "Acpix66%5WjgP"),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                };
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors erros)
                {
                    return true;
                };

                smtpCliente.Send(mensagem);
            }
            catch (Exception ex)
            {

                throw;
            }

            
        }

        private string EmailBoasVindas(string nome, string roi)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<p>Olá, <b>{nome}</b>! Tudo bem?</p>");
            sb.Append($"<p>Que bom ter você por aqui 😊</b></p>");
            sb.Append($"<br>");
            sb.Append($"<p>O resultado do cálculo do ROI é entre:</p>");
            sb.Append($"<p><b>{roi} reais.</b></p>");
            sb.Append($"<br>");
            sb.Append($"<p>Agrademos por utilizar a nossa ferramenta.</p>");
            sb.Append($"<br>");
            sb.Append($"<p>Caso precise de mais alguma informação, acesse:  acertpix.com.br</p>");
            sb.Append($"<p>Vamos adorar ajudar você!</p>");
            sb.Append($"<br>");
            sb.Append($"<p>Até a próxima 😉</p>");
            return sb.ToString();
        }

    }
}