using RoomBooking.Domain;

namespace RoomBooking.Tests
{
    public class TimeSlotTests
    {
        [Fact]
        public void Ctor_EndBeforeStart_ThrowsArgumentException()
        {
            //arrange
            var dateOnly = new DateOnly(2026, 11, 25);

            var endTime = new TimeOnly(10, 0);
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

        [Theory]
        [InlineData(14)]
        [InlineData(481)]

        public void Ctor_DurationTooShortOrTooLong_ThrowsArgumentException(int duration)
        {
            //arrange
            var dateOnly = new DateOnly(2026, 11, 25);
            var dateTimeStart = new DateTime(dateOnly, new TimeOnly(8, 0));
            var dateTimeEnd = dateTimeStart.AddMinutes(duration);

            //act && assert
            Assert.Throws<ArgumentException>(() => new TimeSlot(dateTimeStart, dateTimeEnd));
        }

        [Theory]
        [InlineData(15)]
        [InlineData(480)]

        public void Ctor_ValidDuration_AssignsValues(int duration)
        {
            //arrange
            var dateOnly = new DateOnly(2026, 11, 25);
            var dateTimeStart = new DateTime(dateOnly, new TimeOnly(8, 0));
            var dateTimeEnd = dateTimeStart.AddMinutes(duration);

            //act
            var timeSlot = new TimeSlot(dateTimeStart, dateTimeEnd);

            //assert
            Assert.Equal(dateTimeStart, timeSlot.Start);
            Assert.Equal(dateTimeEnd, timeSlot.End);
        }


        [Theory] // hrs  min  hrs  min
        [InlineData(9,   0,   11,  0,  true)]
        [InlineData(11,  0,   13,  0,  true)]
        [InlineData(10,  30,  11,  30, true)]
        [InlineData(9,   0,   13,  0,  true)]
        [InlineData(9,   0,   10,  0,  false)]
        [InlineData(12,  0,   13,  0,  false)]
        [InlineData(8,   0,   9,   0,  false)]
        [InlineData(13,  0,   14,  0,  false)]
        public void Overlaps_OtherSlotInVariousPositions_ReturnsTrueOnlyOnOverlap(int otherStartHour, int otherStartMinute, int otherEndHour, int otherEndMinute, bool isColliding)
        {
            //arrange
            var dateOnly = new DateOnly(2026, 11, 25);
            var dateTimeStart = new DateTime(dateOnly, new TimeOnly(10, 0));
            var dateTimeEnd = new DateTime(dateOnly, new TimeOnly(12, 0));

            var timeSlot = new TimeSlot(dateTimeStart, dateTimeEnd);

            var otherTimeSlot = new TimeSlot(
                new DateTime(dateOnly, new TimeOnly(otherStartHour, otherStartMinute)),
                new DateTime(dateOnly, new TimeOnly(otherEndHour, otherEndMinute)));

            //act
            var collision = timeSlot.Overlaps(otherTimeSlot);

            //assert
            Assert.Equal(isColliding, collision);
        }
    }
}
