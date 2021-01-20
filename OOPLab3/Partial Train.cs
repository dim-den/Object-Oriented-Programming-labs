using System;

namespace OOPLab3
{
    public partial class Train
    {
        public override string ToString()
        {
            return ($"Train number: {train_number}, destiny: {destiny}, arrive: {hour}:{minute}, seats: {seats_count()}");
        }
        public override bool Equals(object tr2)
        {
            if (tr2 == null) return false;
            Train t = tr2 as Train; 
            if (t as Train == null) return false;
            return t.destiny == destiny && t.train_number == train_number && t.hour == hour && t.minute == minute
                && t.seats.common == seats.common && t.seats.kype == seats.kype && t.seats.plackart == seats.plackart && t.seats.lux == seats.lux;
        }

        public override int GetHashCode()
        {
            if (destiny == null) return seats.GetHashCode() * 22  + 44 * hour + 31 * minute + 5 * train_number;
            return seats.GetHashCode() * 13 + 4*destiny.GetHashCode() + 44 * hour + 31 * minute + 5 * train_number;
        }
    }
}
