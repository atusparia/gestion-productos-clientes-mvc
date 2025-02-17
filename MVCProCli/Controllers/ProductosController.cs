using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using MVCProCli.Models.Request;
using MVCProCli.Models.Response;
using System.Security.Policy;
using System.Text;
using System.Text.Json;

namespace MVCProCli.Controllers
{
    public class ProductosController : Controller
    {
        string url = "https://localhost:7266/api/Productos";
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetProductos(string filtro)        
        {
            HttpClient httpClient = new HttpClient();
            url = url + "/Listar?filter=" + filtro;

            //Console.WriteLine("URL construida: " + url);

            HttpResponseMessage response = await httpClient.GetAsync(url);

            List<ProductoResponseV1> model = null;

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                model = JsonSerializer.Deserialize<List<ProductoResponseV1>>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                model = new List<ProductoResponseV1>();
            }

            return Json(model);
        }

        [HttpPost]
        //public async Task<JsonResult> InsertProductos(ProductoRequestV1 request)
        public async Task<JsonResult> InsertProductos(string nombre, decimal precio, int stock)
        {
            try
            {
                ProductoRequestV1 request = new ProductoRequestV1 
                { 
                    Nombre = nombre,  
                    Precio = precio,
                    Stock = stock,
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

                return Json(new { message = "Producto registrado correctamente" });

            }
            catch (Exception)
            { 
                return Json(new { message = "Error, comunicarse con el Administrador" });
            }           
        }


        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID de producto inválido.");
            }

            using HttpClient httpClient = new HttpClient();
            string requestUrl = url + "/Eliminar/" + id;

            HttpResponseMessage response = await httpClient.DeleteAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                return Ok(new { message = "Producto eliminado correctamente." });
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Error al eliminar el producto.");
            }
        }
    }
}
