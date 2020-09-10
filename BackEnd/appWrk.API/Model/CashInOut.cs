using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace appWrk.API.Model
{
    public class CashInOut
    {
        [Key]
        public int idx { get; set; }
        public int transacionType { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public decimal RunningBalance { get; set; }
        public DateTime dtCreated { get; set; }

    }
}
