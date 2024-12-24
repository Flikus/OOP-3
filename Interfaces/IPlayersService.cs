interface IPlayersService 
{
    void CreateAccont(string userName, string TypeAccount);
    void OutputAccountById(string userName);    
    void OutputAllAccount();
    void OutputPlayerGamesByPlayerId(string userName);
    GameAccount GetAccount(string userName);
}