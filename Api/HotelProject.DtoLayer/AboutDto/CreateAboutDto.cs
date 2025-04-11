using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.AboutDto
{
    public class CreateAboutDto
    {
        [Required(ErrorMessage = "Başlık 1 alanı boş geçilemez.")]
        [StringLength(100, ErrorMessage = "Başlık 1 en fazla 100 karakter olabilir.")]
        public string Title1 { get; set; }

        [Required(ErrorMessage = "Başlık 2 alanı boş geçilemez.")]
        [StringLength(100, ErrorMessage = "Başlık 2 en fazla 100 karakter olabilir.")]
        public string Title2 { get; set; }

        [Required(ErrorMessage = "İçerik alanı boş geçilemez.")]
        [StringLength(1000, ErrorMessage = "İçerik en fazla 1000 karakter olabilir.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Oda sayısı boş geçilemez.")]
        [Range(0, int.MaxValue, ErrorMessage = "Geçerli bir oda sayısı giriniz.")]
        public int RoomCount { get; set; }

        [Required(ErrorMessage = "Personel sayısı boş geçilemez.")]
        [Range(0, int.MaxValue, ErrorMessage = "Geçerli bir personel sayısı giriniz.")]
        public int StaffCount { get; set; }

        [Required(ErrorMessage = "Müşteri sayısı boş geçilemez.")]
        [Range(0, int.MaxValue, ErrorMessage = "Geçerli bir müşteri sayısı giriniz.")]
        public int CustomerCount { get; set; }
    }
}
