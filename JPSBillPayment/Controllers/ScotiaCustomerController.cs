﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JPSBillPayment.Data;
using JPSBillPayment.Models;
using Microsoft.AspNetCore.Identity;

namespace JPSBillPayment.Controllers
{
    public class ScotiaCustomerController : Controller
    {
        private readonly ScotiaCustomerContext _context;
        private readonly UserManager<Customer> userManager;
        private readonly SignInManager<Customer> signInManager;

        public ScotiaCustomerController(ScotiaCustomerContext context, UserManager<Customer> userManager, SignInManager<Customer> signInManager)
        {
            _context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // GET: ScotiaCustomer
        public async Task<IActionResult> Index()
        {
            return View(await _context.ScotiaCustomer.ToListAsync());
        }

        // GET: ScotiaCustomer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scotiaCustomer = await _context.ScotiaCustomer
                .FirstOrDefaultAsync(m => m.id == id);
            if (scotiaCustomer == null)
            {
                return NotFound();
            }

            return View(scotiaCustomer);
        }

        // GET: ScotiaCustomer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScotiaCustomer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Email,Password,First,Last,Address,Balance,AccountNumber,CardNumber,AvaBalance,AccountType")] ScotiaCustomer scotiaCustomer)
        {
            if (ModelState.IsValid)
            {
                


                _context.Add(scotiaCustomer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scotiaCustomer);
        }

        // GET: ScotiaCustomer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scotiaCustomer = await _context.ScotiaCustomer.FindAsync(id);
            if (scotiaCustomer == null)
            {
                return NotFound();
            }
            return View(scotiaCustomer);
        }

        // POST: ScotiaCustomer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Email,Password,First,Last,Address,Balance,AccountNumber,CardNumber,AvaBalance,AccountType")] ScotiaCustomer scotiaCustomer)
        {
            if (id != scotiaCustomer.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scotiaCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScotiaCustomerExists(scotiaCustomer.id))
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
            return View(scotiaCustomer);
        }
       
        // GET: ScotiaCustomer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scotiaCustomer = await _context.ScotiaCustomer
                .FirstOrDefaultAsync(m => m.id == id);
            if (scotiaCustomer == null)
            {
                return NotFound();
            }

            return View(scotiaCustomer);
        }
       
        // POST: ScotiaCustomer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scotiaCustomer = await _context.ScotiaCustomer.FindAsync(id);
            _context.ScotiaCustomer.Remove(scotiaCustomer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScotiaCustomerExists(int id)
        {
            return _context.ScotiaCustomer.Any(e => e.id == id);
        }
    }
}
