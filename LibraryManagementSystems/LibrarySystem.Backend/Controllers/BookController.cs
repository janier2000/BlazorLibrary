using Microsoft.AspNetCore.Mvc;
using LibrarySystem.Shared.DTOs;
using LibrarySystem.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Backend.Repositories.Interface;

namespace LibrarySystem.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] Book bookENT)
        {
            ResponseDTO<Book> _ResponseDTO = new ResponseDTO<Book>();
            try
            {

                Book bookCreated = await _bookRepository.CreateAsync(bookENT);
                if (bookCreated.Id != 0)
                {
                    _ResponseDTO = new ResponseDTO<Book>()
                    {
                        status = true,
                        msg = "ok",
                        value = bookCreated
                    };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<Book>()
                    {
                        status = false,
                        msg = "No se pudo crear el libro"
                    };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<Book>()
                {
                    status = false,
                    msg = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Editar([FromBody] Book bookENT)
        {
            ResponseDTO<Book> _ResponseDTO = new ResponseDTO<Book>();
            try
            {

                Book bookEdit = await _bookRepository.GetAsync(u => u.Id == bookENT.Id);

                if (bookEdit != null)
                {
                    bool response = await _bookRepository.UpdateAsync(bookENT);
                    if (response)
                    {
                        _ResponseDTO = new ResponseDTO<Book>()
                        {
                            status = true,
                            msg = "ok",
                            value = bookENT,
                        };
                    }

                    else
                    {
                        _ResponseDTO = new ResponseDTO<Book>()
                        {
                            status = false,
                            msg = "No se pudo editar el libro"
                        };
                    }
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<Book>()
                    {
                        status = false,
                        msg = "No se encontró el libro"
                    };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<Book>()
                {
                    status = false,
                    msg = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            ResponseDTO<string> _ResponseDTO = new ResponseDTO<string>();
            try
            {
                Book bookDelete = await _bookRepository.GetAsync(u => u.Id == id);
                if (bookDelete != null)
                {
                    bool response = await _bookRepository.DeleteAsync(bookDelete);
                    if (response)
                    {
                        _ResponseDTO = new ResponseDTO<string>()
                        {
                            status = true,
                            msg = "ok",
                            value = ""
                        };
                    }
                    else
                    {
                        _ResponseDTO = new ResponseDTO<string>()
                        {
                            status = false,
                            msg = "No se pudo eliminar el libro",
                            value = ""
                        };
                    }
                }
                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<string>()
                {
                    status = false,
                    msg = ex.Message
                };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        [Route("GetFullList")]
        public async Task<IActionResult> GetFullList()
        {
            ResponseDTO<List<Book>> _ResponseDTO = new ResponseDTO<List<Book>>();

            try
            {
                IQueryable<Book> query = await _bookRepository.CheckAsync();
                query = query.Include(r => r.Category);
                List<Book> listaLibro = query.ToList();
                _ResponseDTO = new ResponseDTO<List<Book>>() { status = true,
                    msg = "ok",
                    value = listaLibro 
                };
                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<Book>>()
                {
                    status = false,
                    msg = ex.Message,
                    value = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        [Route("Get/{Id}")]
        public async Task<IActionResult> GetAsync(int Id)
        {
            ResponseDTO<Book> _ResponseDTO = new ResponseDTO<Book>();

            try
            {
                Book BookENT = await _bookRepository.GetAsync(l => l.Id == Id);
                if (BookENT != null)
                {
                    _ResponseDTO = new ResponseDTO<Book>()
                    {
                        status = true,
                        msg = "ok",
                        value = BookENT
                    };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<Book>()
                    {
                        status = false,
                        msg = "",
                        value = null
                    };
                }
                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<Book>()
                {
                    status = false,
                    msg = ex.Message,
                    value = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        [Route("Check")]
        public async Task<IActionResult> CheckAsync(string value)
        {
            ResponseDTO<List<Book>> _ResponseDTO = new ResponseDTO<List<Book>>();

            try
            {
                List<Book> lstBook = new List<Book>();
                IQueryable<Book> query = await _bookRepository.CheckAsync
                                        (l => l.Title!.ToLower().Contains(value.ToLower()));

                query = query.Include(r => r.Category);
                if (lstBook.Count > 0)
                {
                    _ResponseDTO = new ResponseDTO<List<Book>>() {
                        status = true,
                        msg = "ok",
                        value = lstBook
                    };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<List<Book>>()
                    {
                        status = false,
                        msg = "",
                        value = null
                    };
                }
                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<Book>>() { 
                    status = false,
                    msg = ex.Message,
                    value = null
                };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

     
    }
}