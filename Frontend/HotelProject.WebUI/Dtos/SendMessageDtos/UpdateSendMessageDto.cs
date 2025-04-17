using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.SendMessageDtos
{
    public class UpdateSendMessageDto
    {
        public int SendMessageId { get; set; }
        [Required(ErrorMessage = "Alıcı adı boş bırakılamaz.")]
        [MaxLength(50, ErrorMessage = "Alıcı adı en fazla 50 karakter olabilir.")]
        public string ReceiverName { get; set; }

        [Required(ErrorMessage = "Alıcı e-posta adresi boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string ReceiverEmail { get; set; }

        [Required(ErrorMessage = "Gönderen adı boş bırakılamaz.")]
        [MaxLength(50, ErrorMessage = "Gönderen adı en fazla 50 karakter olabilir.")]
        public string SenderName { get; set; }

        [Required(ErrorMessage = "Gönderen e-posta adresi boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string SenderEmail { get; set; }

        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        [MaxLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "İçerik boş bırakılamaz.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Tarih bilgisi boş bırakılamaz.")]
        public DateTime Date { get; set; }
    }
}
