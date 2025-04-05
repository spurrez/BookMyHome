namespace BookMyHome.BlazorWebApp.Client.DTO
{
    public class BookingDTO
    {
		public int BookingId { get; set; }
		public DateTime CheckIn { get; set; }
		public DateTime CheckOut { get; set; }
        public int GuestAmount { get; set; }
        public string? SpecialRequests { get; set; }
		public BookingStatus Status { get; set; } = BookingStatus.Pending;

		public int AccommodationId { get; set; }
		public int GuestId { get; set; }

		public enum BookingStatus
		{
			Pending,    // Awaiting host approval
			Confirmed,  // Approved by host or auto-confirmed
			Declined,   // Rejected by host
			Cancelled,  // Cancelled by guest or host
			Completed   // Stay completed
		}

	}
}
