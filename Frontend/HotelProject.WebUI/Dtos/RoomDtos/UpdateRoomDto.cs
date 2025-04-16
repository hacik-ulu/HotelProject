using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RoomDtos
{
    public class UpdateRoomDto
    {
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Lütfen oda numarasını giriniz")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "Lütfen oda görseli giriniz")]
        public string CoverImage { get; set; }

        [Required(ErrorMessage = "Lütfen fiyat bilgisi giriniz")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Lütfen oda başlığı bilgisi giriniz")]
        [StringLength(100, ErrorMessage = "Lütfen en fazla 100 karakter veri girişi yapın.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen yatak sayısı giriniz")]
        public int BedCount { get; set; }

        [Required(ErrorMessage = "Lütfen banyo sayısını giriniz")]
        public int BathCount { get; set; }
        public string Wifi { get; set; }

        [Required(ErrorMessage = "Lütfen açıklama giriniz")]
        public string Description { get; set; }
    }
}
