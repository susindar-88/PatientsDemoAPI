public class UserAccountService
{
    private List<UserAccount> _userAccountList;
    public UserAccountService()
    {
        _userAccountList = new List<UserAccount> {
            new UserAccount{ UserName="admin",Password="password@123",Role="Administrator"},
            new UserAccount{ UserName="Susindar",Password="Susindar@123",Role="User"},
            new UserAccount{ UserName="Saminathan",Password="Saminathan@123",Role="User"},
        };
    }

    public UserAccount? GetUserAccountByUserName(string userName)
    {
        return _userAccountList.FirstOrDefault(s => s.UserName == userName);
    }
}