using API_Hospital.DataAccess.Abstracts;
using API_Hospital.Exceptions.Types;
using API_Hospital.Models;

namespace API_Hospital.Services.BusinessRules
{
    public class DoctorBusinessRules
    {
        private IDoctorRepository _repository;

        public DoctorBusinessRules(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public void DoctorNotFound(Doctor? doctor)
        {
            if (doctor is null)
            {
                throw new NotFoundException("İlgili doktor bulunamadı");
            }
        }
    }
}
