using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using appWrk.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace appWrk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        AppDb db = null;
        public TransactionController(AppDb db)
        {
            this.db = db;
        }
        // GET: api/Transaction
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var result = (from n in db.CashInOut
                              orderby n.idx descending
                              select new
                              {
                                  n.Amount,
                                  n.Description,
                                  dtCreated = n.dtCreated.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                                  n.transacionType,
                                  n.RunningBalance
                              }).ToList();
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
        // POST: api/Transaction
        [HttpPost]
        public ActionResult Post([FromBody] CashInOut cash)
        {
            try
            {
                var credit = db.CashInOut.Where(x => x.transacionType == 2).Sum(x => x.Amount);

                var debit = db.CashInOut.Where(x => x.transacionType == 1).Sum(x => x.Amount);
                if (cash.transacionType == 1)
                    debit += cash.Amount;
                else
                    credit += cash.Amount;

                cash.RunningBalance = credit - debit;
                cash.dtCreated = DateTime.Now;
                db.Add(cash);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
