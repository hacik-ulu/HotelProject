using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.GuestDtos
{
    public class UpdateGuestDto
    {
        public int GuestId { get; set; }

        [Required(ErrorMessage = "İsim alanı boş geçilemez.")]
        [MinLength(2, ErrorMessage = "İsim en az 2 karakter olmalıdır.")]
        [MaxLength(50, ErrorMessage = "İsim en fazla 50 karakter olabilir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim alanı boş geçilemez.")]
        [MinLength(2, ErrorMessage = "Soyisim en az 2 karakter olmalıdır.")]
        [MaxLength(50, ErrorMessage = "Soyisim en fazla 50 karakter olabilir.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Şehir alanı boş geçilemez.")]
        [MinLength(3, ErrorMessage = "Şehir ismi en az 3 karakter olmalıdır.")]
        [MaxLength(100, ErrorMessage = "Şehir ismi en fazla 100 karakter olabilir.")]
        public string City { get; set; }
    }
}
