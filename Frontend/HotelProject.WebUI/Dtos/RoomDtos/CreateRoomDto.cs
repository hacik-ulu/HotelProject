using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RoomDtos
{
    public class CreateRoomDto
    {
        [Required(ErrorMessage = "Lütfen oda numarasını giriniz")]
        public string RoomNumber { get; set; }
        public string CoverImage { get; set; }

        [Required(ErrorMessage = "Lütfen fiyat bilgisi giriniz")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Lütfen oda başlığı bilgisi giriniz")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen yatak sayısı giriniz")]
        public int BedCount { get; set; }

        [Required(ErrorMessage = "Lütfen banyo sayısını giriniz")]
        public int BathCount { get; set; }
        public string Wifi { get; set; }
        public string Description { get; set; }
    }
}
