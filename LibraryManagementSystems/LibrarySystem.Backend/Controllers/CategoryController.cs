
using LibrarySystem.Backend.Repositories.Interface;
using LibrarySystem.Shared.DTOs;
using LibrarySystem.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
          
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<IActionResult> GetList()
        {
            //ResponseDTO<List<CategoryDTO>> _ResponseDTO = new ResponseDTO<List<CategoryDTO>>();

            ResponseDTO<List<Category>> _ResponseDTO = new ResponseDTO<List<Category>>();

            try
            {
                var categorias = await _categoryRepository.GetListAsync();
                //List<CategoryDTO> listaCategorias = _mapper.Map<List<CategoryDTO>>(categorias);

                //List<CategoryDTO> listaCategorias = _mapper.Map<List<CategoryDTO>>(categorias);

                _ResponseDTO = new ResponseDTO<List<Category>>()
                {
                    status = true,
                    msg = "ok",
                    value = categorias
                };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<Category>>()
                {
                    status = false,
                    msg = ex.Message,
                    value = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }
    }
}