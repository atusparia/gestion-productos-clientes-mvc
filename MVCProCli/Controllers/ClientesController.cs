using Microsoft.AspNetCore.Mvc;
using MVCProCli.Models.Request;
using MVCProCli.Models.Response;
using System.Text;
using System.Text.Json;

namespace MVCProCli.Controllers
{
    public class ClientesController : Controller
    {
        string url = "https://localhost:7266/api/Clientes";
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetClientes(string filtro)
        {
            HttpClient httpClient = new HttpClient();
            url = url + "/Listar?filter=" + filtro;

            //Console.WriteLine("URL construida: " + url);

            HttpResponseMessage response = await httpClient.GetAsync(url);

            List<ClienteResponseV1> model = null;

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                model = JsonSerializer.Deserialize<List<ClienteResponseV1>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                model = new List<ClienteResponseV1>();
            }

            return Json(model);
        }


        [HttpPost]        
        public async Task<JsonResult> InsertClientes(string nombre, string correo, string telefono)
        {
            try
            {
                ClienteRequestV1 request = new ClienteRequestV1
                {
                    Nombre = nombre,
                    Correo = correo,
                    Telefono = telefono,
                };
                using HttpClient client = new HttpClient();

                url = url + "/Insertar";

                string jsonRequest = JsonSerializer.Serialize(request);

                HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Respuesta: " + jsonResponse);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }

                return Json(new { message = "Cliente registrado correctamente" });

            }
            catch (Exception)
            {
                return Json(new { message = "Error, comunicarse con el Administrador" });
            }
        }


        [HttpPut]
        public async Task<IActionResult> DeleteClientes(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID de cliente inválido.");
            }

            ClienteRequestV2 request = new ClienteRequestV2
            {
                Id = id
            };
            using HttpClient httpClient = new HttpClient();

            url = url + "/Eliminar";

            string jsonRequest = JsonSerializer.Serialize(request);

            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return Ok(new { message = "Cliente eliminado correctamente." });
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Error al eliminar el producto.");
            }
        }

    }
}
