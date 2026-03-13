namespace Entities
{
    public class Bookings
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PitchId { get; set; }
        public int BookerId { get; set; }
        public override string ToString()
        {
            return $"Id: {Id} Arrival: {StartDate} Leave: {EndDate} PitchId: {PitchId} BookerId: {BookerId} -";
        }
    }
}
