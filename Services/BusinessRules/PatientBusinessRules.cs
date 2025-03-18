using API_Hospital.DataAccess.Abstracts;
using API_Hospital.Exceptions.Types;
using API_Hospital.Models;

namespace API_Hospital.Services.BusinessRules
{
    public class PatientBusinessRules
    {
        IPatientRepository _patientRepository;

        public PatientBusinessRules(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public void PatientNotFound(Patient? patient)
        {
            if (patient is null)
            {
                throw new NotFoundException("İlgili hasta bulunamadı");
            }
        }
    }
}
