using APIForBlazorApp.Controllers.Repositories;
using APIForBlazorApp.Models;
using APIForBlazorApp.Models.DBContexts;

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
            _patientsContext.Patients.Attach(progressNote.Patient);
            return await _patientsContext.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}