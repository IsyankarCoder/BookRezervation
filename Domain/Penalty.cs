using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookRezervation.Domain
{
    public class Penalty
    {
        public Penalty()
        {
            
        }
        [Key]
        public Int16  Id { get; set; }

        [DataType("Decimal(6,2)")]
        public decimal Amout { get; set; }
       
        [DataType(DataType.Currency)]
        public string CurrencyCode { get; set; }

        public  Int16 CountryId { get; set; }
        public virtual  Country Country { get; set; } 

    }
}
