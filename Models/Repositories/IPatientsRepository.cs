using APIForBlazorApp.Models;
using Microsoft.AspNetCore.Mvc;

public interface IPatientsRepository
{
    Task<IEnumerable<Patient>> GetPatientsAsync();

    Task<bool> AddPatientAsync(Patient patient);

    Task<bool> UpdatePatientAsync(Patient patient);

    Task<IActionResult> DeletePatientAsync(int patientId);
}