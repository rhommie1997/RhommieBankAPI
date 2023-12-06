namespace RhommieBank.Services.MasterAPI.ViewModel
{
    public class SingleTransferViewModel
    {
        public string? Username { get; set; }
        public string? TransferFrom { get; set; }
        public string? TransferTo { get; set; }
        public string? TransactionName { get; set; }
        public int TransactionTypeID { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime TransferDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }

    }
}
