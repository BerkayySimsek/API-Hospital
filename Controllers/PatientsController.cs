using API_Hospital.DataAccess.Abstracts;
using API_Hospital.DataAccess.Concretes;
using API_Hospital.Models.Dtos.Patient;
using API_Hospital.Models.Dtos.Patients;
using API_Hospital.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace API_Hospital.Controllers;

[Route("api/[controller]")]
[ApiController]

public class PatientsController : Controller
{
    IPatientService _patientService;
    public PatientsController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpPost("add")]
    public IActionResult Add(PatientAddRequestDto dto)
    {
        _patientService.Add(dto);
        return Ok("Hasta Eklendi.");
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        return Ok(_patientService.GetById(id));
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        return Ok(_patientService.GetAll());
    }

    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
        _patientService.Delete(id);
        return Ok("Hasta Silindi.");
    }

    [HttpPut("update")]
    public IActionResult Update(PatientUpdateRequestDto dto)
    {
        _patientService.Update(dto);
        return Ok("Güncelleme Başarılı.");
    }
}
