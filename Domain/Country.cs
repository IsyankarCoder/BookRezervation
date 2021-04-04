using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookRezervation.Domain
{
    public class Country
    {

        [Key]
        public Int16 Id { get; set; }
        

        [DataType("nvarchar(20)")]
        public string Name { get; set; }  

        public virtual ICollection<Penalty> Penalties { get; set; }

    }
}
