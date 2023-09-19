using APIForBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIForBlazorApp.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientsController : ControllerBase
{
    private readonly ILogger<PatientsController> _logger;
    private readonly IPatientsRepository _patientsRepository;

    public PatientsController(ILogger<PatientsController> logger, IPatientsRepository patientsRepository)
    {
        _logger = logger;
        _patientsRepository = patientsRepository;
    }

    [HttpGet(Name = "GetPatients")]
    [Authorize(Roles ="Administrator,User")]
    public async Task<IEnumerable<Patient>> Get()
    {
        var patients  = await _patientsRepository.GetPatientsAsync();
        return patients;
    }

    [HttpPost(Name = "AddPatient")]
    [Authorize(Roles ="Administrator")]
    public async Task<bool> Post(Patient patient)
    {
        var isSuccess  = await _patientsRepository.AddPatientAsync(patient);
        return isSuccess;
    }

    [HttpPut(Name = "UpdatePatient")]
    [Authorize(Roles ="Administrator")]
    public async Task<bool> Put(Patient patient)
    {
        var isSuccess  = await _patientsRepository.UpdatePatientAsync(patient);
        return isSuccess;
    }

    [HttpDelete(Name = "DeletePatient")]
    [Authorize(Roles ="Administrator")]
    public async Task<IActionResult> Delete(int patientID)
    {
        var isSuccess  = await _patientsRepository.DeletePatientAsync(patientID);
        return isSuccess;
    }
}
