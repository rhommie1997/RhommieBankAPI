namespace RhommieBank.Services.PersonAPI.ViewModel
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string created_by { get; set; }
        public DateTime created_dt { get; set; }
    }

    public class PersonAddViewModel
    {
        public string name { get; set; }
        public int age { get; set; }
    }

    public class PersonUpdateViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
    }


}
