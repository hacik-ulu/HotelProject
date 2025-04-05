using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.TestimonialDto
{
    public class CreateTestimonialDto
    {
        [Required(ErrorMessage = "Resim alanı boş geçilemez.")]
        [StringLength(255, ErrorMessage = "Resim URL'si 255 karakteri geçemez.")]
        public string Image { get; set; }

        [Required(ErrorMessage = "İsim alanı boş geçilemez.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "İsim 2 ile 100 karakter arasında olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ünvan alanı boş geçilemez.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ünvan 2 ile 50 karakter arasında olmalıdır.")]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
