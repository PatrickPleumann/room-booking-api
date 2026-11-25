using RoomBooking.Domain;

namespace RoomBooking.Tests
{
    public class TimeSlotTests
    {
        [Fact]
        public void Ctor_EndBeforeStart_ThrowsArgumentException()
        {
            //arrange
            var dateOnly = new DateOnly(2026,11,25);

            var endTime = new TimeOnly(10,0); 
            var endDateTime = new DateTime(dateOnly, endTime);

            var startTime = new TimeOnly(14, 15);
            var startDateTime = new DateTime(dateOnly, startTime);


            //act & assert
            Assert.Throws<ArgumentException>(() => new TimeSlot(startDateTime, endDateTime));
        }

        [Fact]
        public void Ctor_EndEqualsStart_ThrowsArgumentException()
        {
            //arrange
            var dateOnly = new DateOnly(2026, 11, 25);

            var time = new TimeOnly(10, 0);

            var dateTime = new DateTime(dateOnly, time);

            //act & assert
            Assert.Throws<ArgumentException>(() => new TimeSlot(dateTime, dateTime));
        }

        [Fact]
        public void Ctor_ValidInput_AssignsValues()
        {
            //arrange
            var dateOnly = new DateOnly(2026, 11, 25);

            var startTime = new TimeOnly(10, 0);
            var startDateTime = new DateTime(dateOnly, startTime);

            var endTime = new TimeOnly(14, 15);
            var endDateTime = new DateTime(dateOnly, endTime);

            //act 
            var timeSlot = new TimeSlot(startDateTime, endDateTime);

            //assert
            Assert.Equal(startDateTime, timeSlot.Start);
            Assert.Equal(endDateTime, timeSlot.End);
        }
    }
}
