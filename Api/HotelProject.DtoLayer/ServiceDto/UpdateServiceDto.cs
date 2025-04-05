using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceId { get; set; }

        [Required(ErrorMessage = "Icon alanı boş geçilemez.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Icon alanı 2 ile 100 karakter arasında olmalıdır.")]
        public string Icon { get; set; }

        [Required(ErrorMessage = "Başlık alanı boş geçilemez.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Başlık 3 ile 50 karakter arasında olmalıdır.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama alanı boş geçilemez.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Açıklama 10 ile 500 karakter arasında olmalıdır.")]
        public string Description { get; set; }
    }
}
