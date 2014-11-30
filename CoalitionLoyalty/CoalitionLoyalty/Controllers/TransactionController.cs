using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CL.Infrastructure.Criterias;
using CL.Infrastructure.Services;
using CoalitionLoyalty.Models;
using Domain.Entity;


namespace CoalitionLoyalty.Controllers
{
    public class TransactionController : Controller
    {
        #region Fields
        private readonly ITransactionService transactionService;
        private readonly ICardService cardService;
        private readonly IClientService clientService;
        #endregion


        #region Constructor

        public TransactionController(ITransactionService transactionService,
            ICardService cardService,
            IClientService clientService)
        {
            this.transactionService = transactionService;
            this.cardService = cardService;
            this.clientService = clientService;
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


        public JsonResult CreateTransaction(Transaction trans)
        {
            transactionService.Add(trans);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCards(Guid? clientId)
        {
            var result = cardService.Search(new CardCriteria() { ClientId = clientId })
                    .Select(t => new CardModel()
                    {
                        CardNumber = t.CardNumber,
                        Id = t.Id
                    });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetClient(string email)
        {
            var result = clientService.Search(new ClientCriteria() { Email = email })
                .Select(t => new Client()
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    SurName = t.SurName,
                    Email = t.Email,
                    LastName = t.LastName,
                    
                }).FirstOrDefault();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
