using API_Hospital.Exceptions.Types;
using API_Hospital.Models.Dtos.Doctors;
using API_Hospital.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : Controller
    {
        IDoctorService _doctorService;
        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost("add")]
        public IActionResult Add(DoctorAddRequestDto dto)
        {
            try
            {
                _doctorService.Add(dto);
                return Ok("Doktor eklendi.");
            }
            catch (BusinessException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_doctorService.GetById(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_doctorService.GetAll());
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            _doctorService.Delete(id);
            return Ok("Doktor silindi.");
        }

        [HttpPut("update")]
        public IActionResult Update(DoctorUpdateRequestDto dto)
        {
            _doctorService.Update(dto);
            return Ok("Güncelleme Başarılı.");
        }
    }
}
