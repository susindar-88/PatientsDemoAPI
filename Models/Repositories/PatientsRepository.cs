using APIForBlazorApp.Models;
using APIForBlazorApp.Models.DBContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class PatientsRepository : IPatientsRepository
{
    private readonly PatientsContext _patientsContext;
    public PatientsRepository(PatientsContext patientsContext)
    {
        _patientsContext = patientsContext;
    }
    public async Task<bool> AddPatientAsync(Patient patient)
    {
        try
        {
            _patientsContext.Patients.Add(patient);
            return await _patientsContext.SaveChangesAsync() > 0;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IActionResult> DeletePatientAsync(int patientId)
    {
        try
        {
            var toRemove = _patientsContext.Patients.FirstOrDefault(s => s.ID == patientId);

            if (toRemove == null)
                return new NotFoundObjectResult(patientId);

            _patientsContext.Patients.Remove(toRemove);
            return new OkObjectResult(await _patientsContext.SaveChangesAsync() > 0);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<IEnumerable<Patient>> GetPatientsAsync()
    {
        try
        {
            var patients = await _patientsContext.Patients.ToListAsync();
            return patients;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<bool> UpdatePatientAsync(Patient patient)
    {
        try
        {
            _patientsContext.Entry(await _patientsContext.Patients.FirstOrDefaultAsync(x => x.ID == patient.ID)).CurrentValues.SetValues(patient);

            return await _patientsContext.SaveChangesAsync() > 0;
        }
        catch(Exception ex)
        {
            throw;
        }
    }
}