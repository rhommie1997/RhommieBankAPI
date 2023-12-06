using RhommieBank.Web.ViewModels.Common;

namespace RhommieBank.Web.ViewModels
{
    public class SingleTransferViewModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string TransferFrom { get; set; }
        public string TransferTo { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public List<SingleTransferRekeningsViewModel> Rekenings { get; set; }
        public ResultMessage result { get; set; }
    }

    public class SingTransferSendAPIViewModel
    {
        public string username { get; set; }
        public string transferFrom { get; set; }
        public string transferTo { get; set; }
        public string transactionName { get; set; }
        public int transactionTypeID { get; set; }
        public decimal amount { get; set; }
        public string description { get; set; }
        public DateTime transferDate { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDt { get; set; }
    }

    public class SingleTransferRekeningsViewModel
    {
        public string NoRekening { get; set; }
        public string FullName { get; set; }
    }
}
