using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.SubscribeDto
{
    public class UpdateSubscribeDto
    {
        [Required(ErrorMessage = "Abonelik Id boş olamaz.")]
        public int SubscribeId { get; set; }

        [Required(ErrorMessage = "E-posta alanı boş geçilemez.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }
    }
}