using API_Hospital.DataAccess.Abstracts;
using API_Hospital.Exceptions.Types;
using API_Hospital.Models;

namespace API_Hospital.Services.BusinessRules
{
    public class HospitalBusinessRules
    {
        IHospitalRepository _repository;

        public HospitalBusinessRules(IHospitalRepository repository)
        {
            _repository = repository;
        }
        public void HospitalNotFound(Hospital? hospital)
        {
            if (hospital is null)
            {
                throw new NotFoundException("İlgili hastane bulunamadı");
            }
        }
    }
}
