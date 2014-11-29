using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL.Infrastructure.Criterias;
using CL.Infrastructure.Services;

namespace CoalitionLoyalty.Controllers
{
    public class TransactionController : Controller
    {
        #region Fields
        private readonly ITransactionService transactionService;
        private readonly ICardService cardService;
        #endregion


        #region Constructor

        public TransactionController(ITransactionService transactionService,
            ICardService cardService)
        {
            this.transactionService = transactionService;
            this.cardService = cardService;
        }

        #endregion

        #region Views
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return PartialView();
        }

        public ActionResult Add()
        {
            return PartialView();
        }

        public ActionResult Edit()
        {
            return PartialView();
        }

        public ActionResult Update()
        {
            return PartialView();
        }

        #endregion

        #region Actions
        public JsonResult GetCards()
        {
            var result = cardService.Search(new CardCriteria() { });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
