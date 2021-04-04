using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookRezervation.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace BookRezervation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        
        public List<SelectListItem> CountryList { get; set; }
        [BindProperty]
        public BookReservationViewModel  BookReservationViewModel { get; set; }

        private Data.BookRezervationContext _bookRezervationContext { get; set; }

        //Startup a injection yapılabilir.
        private  readonly BookReservationService bookReservationService;

        public IndexModel(ILogger<IndexModel> logger, Data.BookRezervationContext bookRezervationContext)
        {
            _logger = logger;
            _bookRezervationContext = bookRezervationContext;
            bookReservationService = new BookReservationService(bookRezervationContext);
        }

       

        public void OnGet()        
        {
            CountryList = bookReservationService.PopulateCountry().ToList();
        }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                var calculatedDays = BookReservationService.CalcuteBusinessDays(BookReservationViewModel.CheckOutDate, BookReservationViewModel.ReturnDate, BookReservationViewModel.CountryId);
                BookReservationViewModel.BusinessDay = calculatedDays;
                if (calculatedDays > 10)
                {
                    var result = bookReservationService.CalculatePenalty(BookReservationViewModel.CountryId, calculatedDays);
                    BookReservationViewModel.PenaltyAmount = result.Item1;
                    BookReservationViewModel.CurrencyCode = result.Item2;

                }
            }

            CountryList = bookReservationService.PopulateCountry(BookReservationViewModel.CountryId).ToList();
        }


        private void CalculateBusinessDay()
        {
         

            
        }
        
        public void hesapla_click(object sender)
        {
              

        }

        public override BadRequestResult BadRequest()
        {
            return base.BadRequest();
        }
    }
}
