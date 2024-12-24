class PlayerService : IPlayersService
{   
    PlayerRepository playerRepository;
    public PlayerService(DbContext dbContextObj)
    {
        playerRepository = new PlayerRepository(dbContextObj);
    } 


    public void CreateAccont(string userName, string TypeAccount)
    {
        playerRepository.CreatePlayer(userName, TypeAccount);
    }



    //вивід інформації програвця
    private void OutputPlayerById(int index)
    {	
        GameAccount account = playerRepository.ReadAccount(index);
        if(account.UserName == null)
            Console.Write("Користувача не знайдено\n");

        else{
            Console.Write("|{0,7:d3} |", index);
            Console.Write("{0, 8} |" , account.UserName);		
            Console.Write("{0,11} |" , account.TypeAccount);			
            Console.Write("{0, 8} |" , account.CurrentRating);
            Console.Write("{0, 15} |", account.GamesCount);
            Console.Write("\n");            
        }
    }

    //вивід гравця за ід
    public void OutputAccountById(string userName)
    {
        int index = playerRepository.ReadPlayer(userName);
        if(index >= 0) {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("| індекс | гравець | тип акунта | рейтинг | Кількість ігор |");

            OutputPlayerById(index);

            Console.WriteLine("------------------------------------------------------------");
            Console.Write("\n");
        }
    }

    //вивести всі акаунти
    public void OutputAllAccount()
    {   
        Console.WriteLine("------------------------------------------------------------");
		Console.WriteLine("| індекс | гравець | тип акунта | рейтинг | Кількість ігор |");

        for(int i = 0; i < playerRepository.ReadPlayer(1); i++)
            OutputPlayerById(i);

        Console.WriteLine("------------------------------------------------------------");
        Console.Write("\n");
    }


    public void OutputPlayerGamesByPlayerId(string userName)
    {
        playerRepository.ReadPlayerGamesByPlayerId(userName);
    }




    public GameAccount GetAccount(string userName)
    {
        return playerRepository.ReadAccount(userName);
    }
}