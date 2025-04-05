using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.StaffDto
{
    public class CreateStaffDto
    {
        [Required(ErrorMessage = "İsim alanı boş geçilemez.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "İsim 2 ile 50 karakter arasında olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Ünvan alanı boş geçilemez.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ünvan 2 ile 50 karakter arasında olmalıdır.")]
        public string Title { get; set; }

        [StringLength(150, ErrorMessage = "Sosyal medya ikonu en fazla 150 karakter olabilir.")]
        public string? SocialMediaIcon1 { get; set; }

        [StringLength(150, ErrorMessage = "Sosyal medya ikonu en fazla 150 karakter olabilir.")]
        public string? SocialMediaIcon2 { get; set; }

        [StringLength(150, ErrorMessage = "Sosyal medya ikonu en fazla 150 karakter olabilir.")]
        public string? SocialMediaIcon3 { get; set; }
    }
}
