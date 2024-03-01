using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ValidadorSenhaUI.Models;
using System.Text.Json;


namespace ValidadorSenhaUI.Controllers
{
    public class FrattinaHomeController : Controller
    {
        
        private readonly HttpClient _httpClient;

        public FrattinaHomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7147");
        }

        [HttpPost]
        public async Task<IActionResult> VerificarSenha(SenhaModel model)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/api/ValidadorSenhaAPI/", model);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {

                    SenhaModel? senhaModel = responseContent != null ? JsonSerializer.Deserialize<SenhaModel>(responseContent) : null;
                    
                    if (senhaModel != null)
                        senhaModel.JsonRecebidoPelaAPI = responseContent;

                    return View("Index", senhaModel);
                }
                else
                {
                    SenhaModel modelErro = new SenhaModel();

                    ModelState.AddModelError(string.Empty, "Erro ao chamar a API.");

                    List<string> errosList = new List<string>();

                    if (modelErro.Erros != null)
                    {
                        errosList.AddRange(modelErro.Erros);
                    }

                    if (responseContent != null)
                    {
                        errosList.Add(responseContent);
                        
                    }

                    modelErro.Erros = errosList.ToArray();

                    return View("Index", modelErro);
                }
            }
            else
            {
                return View("Index", model);
            }
        }

        public ActionResult Index()
        {
            SenhaModel senhaModel = new SenhaModel();

            return View(senhaModel);
        }
    }
    

}