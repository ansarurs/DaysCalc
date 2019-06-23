
using DaysCalculator;
using System;
using System.Web.Mvc;

namespace DaysCalc.Controllers
{
    public class DaysCalcController : Controller
    {
        // GET: DaysCalc
        public ActionResult Index(FormCollection formCollection)
        {


            //if (DateFrom !=null && DateTo !=null)
            //{
            //    ViewData["NumberofDays"] = CalculateDays(DateFrom, DateTo);
            //}

            ViewData["NumberofDays"] = 0;
            if (formCollection != null && formCollection.Keys.Count > 0)
            {
                DateFormat dt1 = new DateFormat();
                ViewData["NumberofDays"] = 0;

                String datePart = formCollection[0];
                if ((!string.IsNullOrEmpty(formCollection[0])) && (!string.IsNullOrEmpty(formCollection[1])))
                {
                    String[] dateParts = datePart.Split('-');
                    dt1.Year = Convert.ToInt32(dateParts[0]);
                    dt1.month = Convert.ToInt32(dateParts[1]);
                    dt1.days = Convert.ToInt32(dateParts[2]);

                    DateFormat dt2 = new DateFormat();

                    datePart = formCollection[1];
                    dateParts = datePart.Split('-');
                    dt2.Year = Convert.ToInt32(dateParts[0]);
                    dt2.month = Convert.ToInt32(dateParts[1]);
                    dt2.days = Convert.ToInt32(dateParts[2]);

                    ViewData["NumberofDays"] = (dt2 - dt1).days;
                }

            }


            return View();
        }
    }

        
   
}