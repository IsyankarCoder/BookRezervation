using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookRezervation.ViewModel
{
    public class BookReservationViewModel
    {
        public DateTime CheckOutDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Int16 CountryId { get; set; }

        public int BusinessDay { get; set; } = 0;
        public Decimal PenaltyAmount { get; set; } = 0;
        public string CurrencyCode { get; set; }
    }
}
