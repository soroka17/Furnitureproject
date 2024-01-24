using Data.Interfaces;
using Domain.Dtos;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Api.Controllers
{
    //Контроллер продуктов
    [ApiController]
    [Route("api/[controller]")] // Путь до этого контроллера т.е. http://localhost:5050/api/Product
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _products;
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        //Внедрение зависимостей
        public ProductController(IRepository<Product> products, HttpClient client, IConfiguration configuration)
        {
            _products = products;
            _client = client;
            _configuration = configuration;
        }

        //Получение всех продуктов из бд
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var products = await _products.GetAll(cancellationToken);

            return Ok(products);
        }

        //Создание продукта в бд
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto dto, CancellationToken cancellationToken)
        {
            var product = await MapDto(dto, cancellationToken); // Маппинг DTO объекта

            if (product is null)
                return BadRequest();

            var created = await _products.Create(product, cancellationToken);

            await _products.SaveChangesAsync(cancellationToken);

            return Ok(created);
        }

        //Удаление продукта из бд
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var deleted = await _products.Delete(id, cancellationToken);

            if(deleted is null) 
                return NotFound();

            await _products.SaveChangesAsync(cancellationToken);

            return Ok(deleted);
        }

        //Получение продукта по айди
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var product = await _products.GetById(id, cancellationToken);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        //Маппинг дто объекта
        private async Task<Product?> MapDto(ProductDto dto, CancellationToken cancellationToken = default)
        {
            var baseUrl = _configuration["Services:Mapping"]; // получаем url сервиса маппинга
            var json = JsonConvert.SerializeObject(dto); // сериализуем в json формат
            var content = new StringContent(json, Encoding.UTF8, "application/json"); // создаем контент для http запроса
            var response = await _client.PostAsync($"{baseUrl}/map-dto", content, cancellationToken); // посылаем на сервис маппинга и получаем ответ

            if (!response.IsSuccessStatusCode) // если статус ответа не 200 то возвращаем null
                return null;

            return JsonConvert.DeserializeObject<Product>(await response.Content.ReadAsStringAsync()); // десериализуем ответ от сервиса маппинга и возвращаем его
        }
    }
}
