namespace CheckInAPI.Models
{
    public class Checkin
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Email { get; set; }
        public DateTime DataCheckin { get; set; }
    }
}