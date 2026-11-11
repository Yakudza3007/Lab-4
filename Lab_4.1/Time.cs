using System;

namespace ConsoleApp1
{
    public class Time
    {
        private byte _hours;
        private byte _minutes;

        public Time(byte hours, byte minutes)
        {
            if (hours > 23)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(hours), "Часы: от 0 до 23.");
            }

            if (minutes > 59)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(minutes), "Минуты: от 0 до 59.");
            }

            _hours = hours;
            _minutes = minutes;
        }

        public byte Hours
        {
            get { return _hours; }
        }

        public byte Minutes
        {
            get { return _minutes; }
        }

        private int TotalMinutes
        {
            get { return _hours * 60 + _minutes; }
        }

        public Time AddMinutes(uint minutes)
        {
            int total = (TotalMinutes + 
                (int)(minutes % 1440)) % 1440;

            return new Time((byte)(total / 60), 
                            (byte)(total % 60));
        }

        public Time Subtract(Time other)
        {
            int total = (TotalMinutes - 
                other.TotalMinutes + 1440) % 1440;

            return new Time((byte)(total / 60), 
                            (byte)(total % 60));
        }

        public static Time operator -(Time first, 
            Time second)
        {
            return first.Subtract(second);
        }

        public static Time operator --(Time time)
        {
            int total = (time.TotalMinutes - 1 + 1440) 
                        % 1440;

            return new Time((byte)(total / 60), 
                            (byte)(total % 60));
        }

        public static explicit operator byte(Time time)
        {
            return time._hours;
        }

        public static implicit operator bool(Time time)
        {
            bool result = false;
            result = (time._hours != 0 || time._minutes != 0);
            return result;
        }

        public static Time operator +(Time time, 
            uint minutes)
        {
            return time.AddMinutes(minutes);
        }

        public static Time operator +(uint minutes, 
            Time time)
        {
            return time.AddMinutes(minutes);
        }

        public static Time operator +(Time first, 
            Time second)
        {
            int total = first.TotalMinutes + 
                        second.TotalMinutes;
            total %= 1440;

            return new Time((byte)(total / 60), 
                            (byte)(total % 60));
        }

        public override string ToString()
        {
            return $"{_hours:D2}:{_minutes:D2}";
        }
    }
}