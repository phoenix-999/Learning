using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControllers.Models
{
    public class MemoryRepository : IRepository
    {
        ConcurrentDictionary<int, Reservation> items;

        public MemoryRepository()
        {
            items = new ConcurrentDictionary<int, Reservation>();

            new List<Reservation>
            {
                new Reservation{ ClientName = "Alice", Location = "Board Room"},
                new Reservation{ ClientName = "Bob", Location = "Lecture Hall"},
                new Reservation{ ClientName = "Joe", Location = "Meeting Room"}
            }.ForEach(r => AddOrUpdateReservation(r));
        }

        public IEnumerable<Reservation> Reservations => items.Values;

        public Reservation this[int id] => items[id];

        public Reservation AddOrUpdateReservation(Reservation reservation)
        {
            bool hasObject = false;
            if (reservation?.ReservationId == 0)
            {
                int? id = items.Values?.Max(r => r?.ReservationId);
                reservation.ReservationId = (int)(id != null ? ++id : 1);
                hasObject = items.TryAdd(reservation.ReservationId, reservation);
            }
            else
            {
                items[reservation.ReservationId] = reservation;
                hasObject = true;
            }
            if (!hasObject)
                throw new InvalidOperationException($"The instance {reservation.ToString()} can not be added.");

            return reservation;
        }

        public void RemoveReservation(Reservation reservation)
        {
            items.TryRemove(reservation.ReservationId, out reservation);
        }
    }
}
