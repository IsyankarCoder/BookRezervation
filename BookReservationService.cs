using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRezervation.Data;

namespace BookRezervation
{
    public class BookReservationService
    {

        private static DayOfWeek FirstDayofWeek=DayOfWeek.Saturday;
        private static DayOfWeek SecondDayofWeek = DayOfWeek.Sunday;

        private readonly BookRezervationContext _bookRezervationContext;


        //Startupdan inject edebilirim ama basit tutacam.
        public BookReservationService(BookRezervationContext  bookRezervationContext)
        {
            _bookRezervationContext = bookRezervationContext;
        }


        //Common service lere yazabilirizx.
        public IEnumerable<SelectListItem> PopulateCountry(Int16? selectedCountryId = null)
        {
            var CountryList = _bookRezervationContext.Country.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).ToList();

            if (selectedCountryId != null)
                CountryList.Where(c => c.Value == selectedCountryId.Value.ToString()).First().Selected = true;
         
            return CountryList;
        }
        public static int CalcuteBusinessDays(DateTime startDate,DateTime endDate,short CountryId)
        {
            SetDayOfWeekByCulture(CountryId);

            var totalDays = 0;
            for (var date = startDate; date < endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek != FirstDayofWeek && date.DayOfWeek != SecondDayofWeek)
                    totalDays++;
            }

            return totalDays;
        }

        public Tuple<decimal, string> CalculatePenalty(short CountryId, int totalDays)
        {
            decimal amount = 0;
            var currencyCode = "";


            var penalty = _bookRezervationContext.Penalty.Where(c => c.CountryId == CountryId).FirstOrDefault();
            if (penalty != null)
            {
                amount = penalty.Amout * (totalDays - 10);
                currencyCode = penalty.CurrencyCode;
            }

            return new Tuple<decimal, string>(amount, currencyCode);

        }


        private static void SetDayOfWeekByCulture(int CountryId)
        {
            //1 Türkiye
            //Cumartesi Pazar

            switch (CountryId) {
                case 1:
                    {
                        FirstDayofWeek = DayOfWeek.Saturday;
                        SecondDayofWeek = DayOfWeek.Sunday;
                        break;
                    }
                case 2:
                    {
                        FirstDayofWeek = DayOfWeek.Friday;
                        SecondDayofWeek = DayOfWeek.Saturday;
                        break;
                    }

            }
            //2 Dubai 
            //Cuma Cumartesi 
        } 

    }
}
