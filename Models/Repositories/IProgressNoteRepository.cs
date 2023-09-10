using APIForBlazorApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIForBlazorApp.Controllers.Repositories
{
    public interface IProgressNoteRepository
    {
        Task<bool> AddProgressNote(ProgressNote progressNote);
        Task<bool> UpdateProgressNote(ProgressNote progressNote);
        Task<IEnumerable<ProgressNote>> GetProgressNote();
        Task<IActionResult> DeleteProgressNote(int progressNoteID);
    }
}