
namespace RoomBooking.Domain
{
    public class TimeSlot
    {
        public DateTime Start { get; }
        public DateTime End { get; }
        private const double MinTimeSpan = 15;
        private const double MaxTimeSpan = 480;

        public TimeSlot(DateTime start, DateTime end)
        {
            if (start >= end)
                throw new ArgumentException($"End-Date: {end} is equals or before start-Date {start} . Choose a start-Date earlier than end-Date");

            if ((end - start).TotalMinutes < MinTimeSpan || (end - start).TotalMinutes > MaxTimeSpan)
                throw new ArgumentException($"Time span of: {(end - start).TotalMinutes} minutes too short or too long. Choose a time span between {MinTimeSpan} - {MaxTimeSpan} minutes");

            Start = start;
            End = end;
        }
    }
}
