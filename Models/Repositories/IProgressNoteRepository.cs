using APIForBlazorApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIForBlazorApp.Controllers.Repositories
{
    public interface IProgressNoteRepository
    {
        Task<bool> AddProgressNote(ProgressNote progressNote);
    }
}