using API_Hospital.DataAccess.Abstracts;
using API_Hospital.DataAccess.Concretes;
using API_Hospital.Exceptions.Types;
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
        try
        {
            _patientService.Add(dto);
            return Ok("Hasta Eklendi.");
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
            return Ok(_patientService.GetById(id));

        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
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
