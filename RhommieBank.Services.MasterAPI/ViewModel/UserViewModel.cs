namespace RhommieBank.Services.MasterAPI.ViewModel
{
    public class UserViewModel
    {
        public string? username { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public string? nickname { get; set; }
        public bool isAdmin { get; set; }
        public string? imagePath { get; set; }
        public string? Token { get; set; }
        public int PersonID { get; set; }
    }

    public class UserLoginViewModel
    {
        public string? username { get; set; }
        public string? password { get; set; }
    }
}
