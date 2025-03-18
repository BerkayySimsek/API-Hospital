using API_Hospital.Exceptions.Types;
using API_Hospital.Models.Dtos.Hospital;

namespace API_Hospital.Services.ValidationRules
{
    public class HospitalValidationRules
    {
        public static void HospitalAddValidator(HospitalAddRequestDto dto)
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
            if (string.IsNullOrWhiteSpace(dto.Address))
            {
                errors.Add("Adres alanı boş geçilemez");
            }
            if (dto.Address.Length < 2)
            {
                errors.Add("Adres alanı minimum 2 karakter olmalıdır");
            }
            if (string.IsNullOrWhiteSpace(dto.City))
            {
                errors.Add("Şehir alanı boş geçilemez");
            }
            if (dto.City.Length < 2)
            {
                errors.Add("Şehir alanı minimum 2 karakter olmalıdır");
            }
            if (errors.Count > 0)
            {
                throw new ValidationException(errors);
            }
        }
    }
}
