using System;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;

namespace TimeOrig
{
    public class Time
    {
        private byte hours; // поле для хранения часов
        private byte minutes; // поле для хранения минут

        // свойство для управлением значением часов
        public byte Hours
        {
            get { return hours; }
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentOutOfRangeException("Часы должны быть в диапозоне от 0 до 23. ");
                }
                hours = value;
            }
        }
        // свойство для управления значением минут
        public byte Minutes
        {
            get { return minutes; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentOutOfRangeException("Минуты должны быть в диапозоне от 0 до 59. ");
                }
                minutes = value;
            }
        }
        // конструктор по умолчанию
        public Time()
        {
            hours = 0;
            minutes = 0;
        }
        // конструктор с параметрами для задания значений часов и минут
        public Time(byte hours, byte minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }
        public Time Subtract(Time other)
        {
            int TotalMinutes1 = hours * 60 + minutes;
            int TotalMinutes2 = other.hours * 60 + other.minutes;
            int resultMinutes = TotalMinutes1 - TotalMinutes2;

            // Если результат отрицательный, то добавляем одни сутки (или 1440 минут)
            if (resultMinutes < 0)
            {
                resultMinutes += 24 * 60;
            }

            byte resultHours = (byte)(resultMinutes / 60);
            byte resultMinutesOnly = (byte)(resultMinutes % 60);

            return new Time(resultHours, resultMinutesOnly);
        }

        // оператор явного приведения типа в byte - результат количество часов
        public static explicit operator byte(Time time)
        {
            return time.hours;
        }

        // оператор неявного приведения типа в bool - результатом является true, если часы и минуты не равны нулю.
        public static implicit operator bool(Time time)
        {
            return time.hours != 0 || time.minutes != 0;
        }

        public override string ToString()
        {
            return $"{hours:D2}:{minutes:D2}";
        }

        public static Time operator --(Time time)
        {
            if (time.minutes == 0)
            {
                time.minutes = 59;
                if (time.hours == 0)
                {
                    time.hours = 23;
                }
                else
                {
                    time.hours--;
                }
            }
            else
            {
                time.minutes--;
            }
            return time;
        }
        public static Time operator +(Time time, byte minutesToAdd)
        {
            int totalMinutes = time.hours * 60 + time.minutes + minutesToAdd;
            byte resultHours = (byte)(totalMinutes / 60 % 24);
            byte resultMinutes = (byte)(totalMinutes % 60);
            return new Time(resultHours, resultMinutes);
        }

        public static Time operator +(Time time1, Time time2)
        {
            int totalMinutes = time1.hours * 60 + time1.minutes + time2.hours * 60 + time2.minutes;
            byte resultHours = (byte)(totalMinutes / 60 % 24);
            byte resultMinutes = (byte)(totalMinutes % 60);
            return new Time(resultHours, resultMinutes);
        }
    }
}