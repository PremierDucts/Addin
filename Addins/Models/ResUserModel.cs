namespace AddinsPremierducts
{
    public class ResUserModel
    {
        public int id { get; set; }
        public string email { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
}