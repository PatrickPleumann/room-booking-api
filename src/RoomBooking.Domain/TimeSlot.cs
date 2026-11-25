
namespace RoomBooking.Domain
{
    public class TimeSlot
    {
        public DateTime Start { get; }
        public DateTime End { get; }
        public TimeSlot(DateTime start, DateTime end)
        {
            if (start >= end)
                throw new ArgumentException($"End-Date: {end} is equals or before start-Date {start} . Choose a start-Date earlier than end-Date");

            Start = start;
            End = end;
        }
    }
}
