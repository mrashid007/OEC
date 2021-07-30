using OnlineExamCenter.App_Start;
using OnlineExamCenter.ModelsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineExamCenter.Controllers
{
    //[SessionExpire]
    public class FlashCardController : Controller
    {
        // GET: FlashCard
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FlashCardBoard()
        {
            return View();
        }
        public ActionResult NewFlashCard()
        {
            return View();
        }
        public PartialViewResult _FlashCardList()
        {
            List<FlashCardVM> list = new List<FlashCardVM>();
            //TicketManager tktMgr = new TicketManager();
            //int officeId = Convert.ToInt32(Session["OfficeId"]);
            //if (Session["RoleCode"].ToString() == "ADM")
            //{
            //    officeId = 0;
            //}


            //list = tktMgr.SelectTicketList("", officeId, 0, 0);
            return PartialView(list);
        }
    }
}