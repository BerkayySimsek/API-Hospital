using API_Hospital.Exceptions.Types;
using API_Hospital.Models.Dtos.Doctors;

namespace API_Hospital.Services.ValidationRules
{
    public class DoctorValidationRules
    {
        public static void DoctorAddValidator(DoctorAddRequestDto dto)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                errors.Add("Ad alanı boş geçilemez");
            }
            if (dto.Name.Length < 2)
            {
                errors.Add("Ad alanı minimum 2 karakter olmalıdır");
            }
            if (string.IsNullOrWhiteSpace(dto.Surname))
            {
                errors.Add("Soyad alanı boş geçilemez");
            }
            if (dto.Surname.Length < 2)
            {
                errors.Add("Soyad alanı minimum 2 karakter olmalıdır");
            }
            if (string.IsNullOrWhiteSpace(dto.Branch))
            {
                errors.Add("Branş alanı boş geçilemez");
            }
            if (dto.Branch.Length < 2)
            {
                errors.Add("Branş alanı minimum 2 karakter olmalıdır");
            }
            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }
        }
    }
}
