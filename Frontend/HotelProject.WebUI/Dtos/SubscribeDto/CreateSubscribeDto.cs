using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.SubscribeDto
{
    public class CreateSubscribeDto
    {
        [Required(ErrorMessage = "E-posta alanı boş geçilemez.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }
    }
}
