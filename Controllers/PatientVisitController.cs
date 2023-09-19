using APIForBlazorApp.Controllers.Repositories;
using APIForBlazorApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIForBlazorApp.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientVisitController : ControllerBase
{
    private readonly ILogger<PatientsController> _logger;
    private readonly IProgressNoteRepository _progressNoteRepository;

    public PatientVisitController(ILogger<PatientsController> logger, IProgressNoteRepository progressNoteRepository)
    {
        _logger = logger;
        _progressNoteRepository = progressNoteRepository;
    }

    [HttpPost(Name = "AddProgressNote")]
    [Authorize(Roles ="Administrator")]
    public async Task<bool> Post(ProgressNote progressNote)
    {
        var isSuccess  = await _progressNoteRepository.AddProgressNote(progressNote);
        return isSuccess;
    }
}
