namespace HotelProject.WebUI.Models.Reservation
{
    public class MyReservationViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public string AdultCount { get; set; }
        public string ChildCount { get; set; }

        public string SpecialRequest { get; set; }
        public string Status { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

}
