using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JPSBillPayment.Data;
using JPSBillPayment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ScotiaServiceReference;
using NCBServiceReference;
using System.Linq.Expressions;
using JPSBillPayment.ViewModels;

namespace JPSBillPayment.Controllers
{
    
    public class PaymentController : Controller
    {
        FirstWebServiceClient client = new FirstWebServiceClient();
        SecondServiceClient client2 = new SecondServiceClient();
        private readonly BillContext _context;
        private readonly UserManager<Customer> userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PaymentContext _context2;

        public PaymentController(BillContext context, UserManager<Customer> userManager, IHttpContextAccessor httpContextAccessor
            ,PaymentContext context2)
        {
            _context = context;
            this.userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _context2 = context2;
        }
        public IActionResult Make()
        {
            string userid = userManager.GetUserId(HttpContext.User);
            Customer cus = userManager.FindByIdAsync(userid).Result;
           
            ViewBag.Fname = cus.Fname;
            ViewBag.Lname = cus.Lname;
            ViewBag.userid = cus.Id;
            ViewBag.Prem = cus.premisesNumber;
            decimal sum = 0.0m;
            var q =
                        from u in _context.Bill
                        where u.premisesNumber == cus.premisesNumber
                        select u;
            foreach (Bill u in q)
            {
                sum += u.amountDue;
                // p.Balance = p.Balance + scotiaTransaction.Amount;
            }
            ViewBag.Sum = sum;
            
            return View();
        }

        [HttpPost]
        public IActionResult Make(IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                string userid = userManager.GetUserId(HttpContext.User);
                Customer cus = userManager.FindByIdAsync(userid).Result;

                ViewBag.Fname = cus.Fname;
                ViewBag.Lname = cus.Lname;
                ViewBag.userid = cus.Id;
                ViewBag.Prem = cus.premisesNumber;
                int p = Convert.ToInt32(form["prem"]);
                decimal sum = 0.0m;
                var q =
                            from u in _context.Bill
                            where u.premisesNumber == p    //cus.premisesNumber
                            select u;
                int cnt = 0;
                foreach (Bill u in q)
                {
                    sum += u.amountDue;
                    cnt += 1;
                    // p.Balance = p.Balance + scotiaTransaction.Amount;
                }
                ViewBag.Sum = sum;
                if(cnt < 1)
                {
                    ViewBag.Test4 = "Premises Number is not registered";
                }
             
                string cardchk = form["CardNumb"];
                if(cardchk == ""|| form["holder"] == "" || form["prem"] == "")
                {
                    ViewBag.Test3 = "All Fields are Required";
                }
                if (cardchk.StartsWith("9505") == true)
                {
                    bool result = client2.Verify(form["holder"], form["CardNumb"]);
                    if (result == true)
                    {
                        ViewBag.Test = "True";
                        string hol = form["Due"];
                        bool result2 = client2.VerifyFunds(Convert.ToDecimal(form["Due"]), form["CardNumb"]);
                        if (result2 == true)
                        {
                            int cardnum = 0;
                            ViewBag.Test2 = "True a lie";
                            double result3 = client2.CusFunds(form["CardNumb"], Convert.ToDouble(form["Due"]));
                            Create(cus.Fname, Convert.ToDecimal(form["Due"]),cardnum , cus.premisesNumber, cus.Id);
                            var query =
                                from x in _context.Bill
                                where x.premisesNumber == cus.premisesNumber
                                select x;
                            foreach (Bill x in query)
                            {
                                x.amountDue -= Convert.ToDecimal(form["Due"]);
                                // p.Balance = p.Balance + scotiaTransaction.Amount;
                            }

                            _context.SaveChanges();

                            return RedirectToAction("CusPayments", "Payment");
                        }
                        else
                        {
                            ViewBag.Test2 = "Insufficient Funds";
                        }
                    }
                    else
                    {
                        ViewBag.Test = "Invalid Details";
                    }
                }
                else if (cardchk.StartsWith("4001") == true)
                {
                    //Scotia Part
                    bool res = client.Verify(form["holder"], form["CardNumb"]);
                    if (res == true)
                    {
                        ViewBag.Test = "True";
                        string hol = form["Due"];
                        bool res2 = client.VerifyFunds(Convert.ToDecimal(form["Due"]), form["CardNumb"]);
                        if (res2 == true)
                        {
                            //ViewBag.Test2 = "True a lie";
                            //int cardn = Convert.ToInt32.Parse
                            double res3 = client.CusFunds(form["CardNumb"], Convert.ToDouble(form["Due"]));
                            Create(cus.Fname, Convert.ToDecimal(form["Due"]), Convert.ToInt32(form["CardNum"]), cus.premisesNumber, cus.Id);
                            var query =
                                from x in _context.Bill
                                where x.premisesNumber == p
                                select x;
                            foreach (Bill x in query)
                            {
                                x.amountDue -= Convert.ToDecimal(form["Due"]);
                                // p.Balance = p.Balance + scotiaTransaction.Amount;
                            }

                            _context.SaveChanges();

                            return RedirectToAction("CusPayments", "Payment");
                        }
                        else
                        {
                            ViewBag.Test2 = "Insufficient Funds";
                        }
                    }
                    else
                    {
                        ViewBag.Test = "Invalid Details";
                    }
                }
                else
                {
                    ViewBag.Test = "NCB and Scotia Cards only accepted";
                }
            }

            return View(); 
        }

       
        public void Create(string fname, decimal amnt, int cnum,int pnum,string cid)
        {
            
                Payment payment1 = new Payment 
                { 
                    Fname = fname,
                    amountPaid = amnt,
                    cardNumber = cnum,
                    premisesNum = pnum,
                    customerId =cid

                };
                _context2.Add(payment1);
                 _context2.SaveChanges();
              
           
        }

       

        public async Task<IActionResult> CusPayments()
        {
            
            string userid = userManager.GetUserId(HttpContext.User);
            Customer cus = userManager.FindByIdAsync(userid).Result;
            var items = await _context2.Payment.Where(x => x.premisesNum == cus.premisesNumber ).ToListAsync();
          
            

            return View(items);
        }

        

        [HttpGet]
        public async Task<IActionResult> Pending()
        {
            //Customer user = await userManager.GetUserAsync(User);
            string userid = userManager.GetUserId(HttpContext.User);
            Customer cus = userManager.FindByIdAsync(userid).Result;
            //string ID = user.Id;
            
            // ViewBag.userid = ID;
            //string userid = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var items = await _context.Bill.Where(x => x.amountDue > 0 && x.premisesNumber == cus.premisesNumber).ToListAsync();
            /*
             .Select(x => new
             {
                 P1 = table.Prop1,
                 P2 = table.Prop2
             });*/

            return View(items);
        }
    }
}