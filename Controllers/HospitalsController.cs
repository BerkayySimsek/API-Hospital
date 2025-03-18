using API_Hospital.DataAccess.Abstracts;
using API_Hospital.Exceptions.Types;
using API_Hospital.Models;
using API_Hospital.Models.Dtos.Hospital;
using API_Hospital.Models.Dtos.Hospitals;
using API_Hospital.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace API_Hospital.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HospitalsController : Controller
{
    IHospitalService _hospitalService;
    public HospitalsController(IHospitalService hospitalService)
    {
        _hospitalService = hospitalService;
    }
    [HttpPost("add")]
    public IActionResult Add(HospitalAddRequestDto dto)
    {
        try
        {
            _hospitalService.Add(dto);
            return Ok("Hastane Eklendi.");
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
    public IActionResult GetById(string id)
    {
        try
        {
            return Ok(_hospitalService.GetById(id));

        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        return Ok(_hospitalService.GetAll());
    }

    [HttpDelete("delete")]
    public IActionResult DeleteById(string id)
    {
        _hospitalService.Delete(id);
        return Ok("Hastane silindi.");
    }

    [HttpPut("update")]
    public IActionResult Update(HospitalUpdateRequestDto dto)
    {
        _hospitalService.Update(dto);
        return Ok("Güncelleme başarılı.");
    }
}
