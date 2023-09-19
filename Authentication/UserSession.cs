public class UserSession
{
 public string UserName { get; set; }   
 public string Role { get; set; }
 public string Token { get; set; }
 public int ExpiresIn { get; set; }

 public DateTime ExpiryTimestamp{ get; set; }
}