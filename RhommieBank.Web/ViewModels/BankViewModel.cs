namespace RhommieBank.Web.ViewModels
{
    public class BankViewModel
    {
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string CurrencyCode { get; set; }
        public List<CurrencyViewModel> currencyList { get; set; }
    }

    public class BankSaveViewModel
    {
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string CurrencyCode { get; set; }
    }

    public class BankCurrencyListViewModel
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string Country { get; set; }
    }
}
