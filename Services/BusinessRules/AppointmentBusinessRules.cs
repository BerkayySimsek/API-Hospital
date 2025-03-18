using API_Hospital.DataAccess.Abstracts;
using API_Hospital.Exceptions.Types;
using API_Hospital.Models;

namespace API_Hospital.Services.BusinessRules
{
    public class AppointmentBusinessRules
    {
        IAppointmentRepository _repository;

        public AppointmentBusinessRules(IAppointmentRepository repository)
        {
            _repository = repository;
        }
        public void AppointmentNotFound(Appointment? appointment)
        {
            if (appointment is null)
            {
                throw new NotFoundException("İlgili randevu bulunamadı");
            }
        }
    }
}
