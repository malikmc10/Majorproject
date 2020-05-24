using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JPSBillPayment.Data;
using JPSBillPayment.Models;
using ScotiaServiceReference;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace JPSBillPayment.Controllers
{
   
    public class JPSPaymentsController : Controller
    {
        private readonly PaymentContext _context2;
        FirstWebServiceClient client = new FirstWebServiceClient();
        ScotiaServiceReference.IFirstWebService obj = new FirstWebServiceClient();
        private readonly BillContext _context;
        private readonly UserManager<Customer> userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JPSPaymentsController(BillContext context, UserManager<Customer> userManager, IHttpContextAccessor httpContextAccessor
            , PaymentContext context2)
        {
            _context = context;
            this.userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _context2 = context2;
        }


        // GET: JPSPayments
        public async Task<IActionResult> Index()
        {
            return View(await _context2.Payment.ToListAsync());
        }

        // GET: JPSPayments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context2.Payment
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: JPSPayments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JPSPayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,amountPaid,customerId,Fname,premisesNum,cardNumber")] Payment payment,IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(payment);
        }

        // GET: JPSPayments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context2.Payment.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        // POST: JPSPayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentId,amountPaid,customerId,Fname,premisesNum,cardNumber")] Payment payment)
        {
            if (id != payment.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.PaymentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(payment);
        }

        // GET: JPSPayments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _context2.Payment
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: JPSPayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payment = await _context2.Payment.FindAsync(id);
            _context2.Payment.Remove(payment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
            return _context2.Payment.Any(e => e.PaymentId == id);
        }
    }
}
