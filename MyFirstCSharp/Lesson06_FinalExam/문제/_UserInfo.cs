namespace MyFirstCSharp
{
    public class User
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string MailAddress { get; set; }

        public User(string userID, string password, string userName, string mailAddress)
        {
            UserID = userID;
            Password = password;
            UserName = userName;
            MailAddress = mailAddress;
        }
    }
}
