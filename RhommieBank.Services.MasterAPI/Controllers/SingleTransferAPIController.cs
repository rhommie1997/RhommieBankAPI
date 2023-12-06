using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RhommieBank.Services.MasterAPI.Data;
using RhommieBank.Services.MasterAPI.Models;
using RhommieBank.Services.MasterAPI.Models.Dto;
using RhommieBank.Services.MasterAPI.ViewModel;

namespace RhommieBank.Services.MasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingleTransferAPIController : ControllerBase
    {
        private readonly RhommieBankDbContext dbContext;
        private ResponseDto _res;

        public SingleTransferAPIController(RhommieBankDbContext db, IMapper mapper)
        {
            dbContext = db;
            _res = new ResponseDto();
        }

        [HttpPost]
        public ResponseDto SingleTransfer([FromBody] SingleTransferViewModel svm)
        {
            try
            {
                //Update Transfer From
                var charge = dbContext.TransactionTypes.Where(x => x.id == svm.TransactionTypeID).Select(x => x.Charges).FirstOrDefault();
                var total = svm.Amount + charge;

                var isNormal = true;

                //Step 1
                var rekFrom = dbContext.Rekenings.FirstOrDefault(x => x.no_rekening == svm.TransferFrom);
                if(rekFrom != null)
                {
                    rekFrom.saldo -= total;
                    dbContext.Rekenings.Update(rekFrom);
                }
                else
                {
                    isNormal = false;
                }

                //Step 2
                var rekTo = dbContext.Rekenings.FirstOrDefault(x => x.no_rekening == svm.TransferTo);
                if (rekTo != null)
                {
                    rekTo.saldo += svm.Amount;
                    dbContext.Rekenings.Update(rekTo);
                }
                else
                {
                    isNormal = false;
                }

                //Step 3
                if (isNormal)
                {
                    var trNote = new TransactionNote() {
                        username = svm.Username ?? "",
                        rekeningTransferFrom = svm.TransferFrom ?? "",
                        rekeningTransferTo = svm.TransferTo ?? "",
                        transactionName = "Single Transfer Inhouse",
                        transactionTypeID = 1,
                        amount = svm.Amount,
                        description = svm.Description ?? "",
                        TransferDate = DateTime.UtcNow,
                        created_by = svm.CreatedBy,
                        created_dt = DateTime.UtcNow,
                        totalAmount = total
                    };

                    dbContext.TransactionNotes.Add(trNote);

                    dbContext.SaveChanges();
                }



            }
            catch (Exception e)
            {
                _res.IsSuccess = false;
                _res.Message = e.Message;
            }

            return _res;
        }



    }
}
