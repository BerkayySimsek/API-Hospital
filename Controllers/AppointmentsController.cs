using API_Hospital.Models.Dtos.Appointment;
using API_Hospital.Models.Dtos.Appointments;
using API_Hospital.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : Controller
    {
        IAppointmentService _appointmentService;
        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("add")]
        public IActionResult Add(AppointmentAddRequestDto dto)
        {
            _appointmentService.Add(dto);
            return Ok("Randevu oluşturuldu.");
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return Ok(_appointmentService.GetById(id));
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_appointmentService.GetAll());
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            _appointmentService.Delete(id);
            return Ok("Randevu başarıyla silindi.");
        }

        [HttpPut("update")]
        public IActionResult Update(AppointmentUpdateRequestDto dto)
        {
            _appointmentService.Update(dto);
            return Ok("Güncelleme başarılı");
        }
    }
}
