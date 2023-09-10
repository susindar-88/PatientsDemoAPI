using APIForBlazorApp.Controllers.Repositories;
using APIForBlazorApp.Models;
using APIForBlazorApp.Models.DBContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ProgressNotesRepository : IProgressNoteRepository
{
    private readonly PatientsContext _patientsContext;
    public ProgressNotesRepository(PatientsContext patientsContext)
    {
        _patientsContext = patientsContext;
    }
    public async Task<bool> AddProgressNote(ProgressNote progressNote)
    {
        try
        {
            _patientsContext.ProgressNotes.Add(progressNote);
            return await _patientsContext.SaveChangesAsync() > 0;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IActionResult> DeleteProgressNote(int progressNoteID)
    {
        try
        {
            var toRemove = _patientsContext.ProgressNotes.FirstOrDefault(s => s.ID == progressNoteID);

            if (toRemove == null)
                return new NotFoundObjectResult(progressNoteID);

            _patientsContext.ProgressNotes.Remove(toRemove);
            return new OkObjectResult(await _patientsContext.SaveChangesAsync() > 0);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IEnumerable<ProgressNote>> GetProgressNote()
    {
        try
        {
            var progressNotes = await _patientsContext.ProgressNotes.ToListAsync();
            return progressNotes;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> UpdateProgressNote(ProgressNote progressNote)
    {
        try
        {
            _patientsContext.Entry(await _patientsContext.ProgressNotes.FirstOrDefaultAsync(x => x.ID == progressNote.ID)).CurrentValues.SetValues(progressNote);

            return await _patientsContext.SaveChangesAsync() > 0;
        }
        catch(Exception ex)
        {
            throw;
        }
    }
}