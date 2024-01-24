using AutoMapper;
using Domain.Dtos;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Mapping.Controllers
{
    // Контроллер для маппинга
    [ApiController]
    [Route("api/[controller]")] // его путь т.е. http://mapping:80/api/mapping
    public class MappingController : ControllerBase
    {
        private readonly IMapper _mapper;

        //Вндерение маппера
        public MappingController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [Route("map-dto")] // путь до метода маппинга дто, т.е. http://mapping:80/api/mapping/map-dto
        public IActionResult Map([FromBody] ProductDto dto, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(dto); // вызываем у маппера метод map(), который и преобразует dto объект в обычный, по правилам в MappingProfile(папка Mappings)

            if (product is null) // Если что то не получилось, то даем ответ 400
                return BadRequest(dto);

            return Ok(product); // Отвечаем ответом 200 с обычным объектов(уже преобразованным)
        }
    }
}
