class Program 
{	
    static void newGame(GameAccount player1, GameAccount player2, Game game)
    {
        player1.WinGame(player2.UserName, game);
        player2.LoseGame(player1.UserName, game);
    }

	static void playGame(PlayerService adminPlayer, GameService	adminGame, List<Game> games)
	{
		games.Add(adminGame.CreateGame("standart", 10));

		newGame(adminPlayer.GetAccount("User1"), adminPlayer.GetAccount("User2"), games[0]);
		newGame(adminPlayer.GetAccount("User3"), adminPlayer.GetAccount("User1"), games[0]);
		newGame(adminPlayer.GetAccount("User3"), adminPlayer.GetAccount("User1"), games[0]);
		newGame(adminPlayer.GetAccount("User1"), adminPlayer.GetAccount("User2"), games[0]);
		newGame(adminPlayer.GetAccount("User1"), adminPlayer.GetAccount("User3"), games[0]);
		newGame(adminPlayer.GetAccount("User2"), adminPlayer.GetAccount("User1"), games[0]);

		games.Add(adminGame.CreateGame("onerisk", 20));

		newGame(adminPlayer.GetAccount("User3"), adminPlayer.GetAccount("User2"), games[1]);
		newGame(adminPlayer.GetAccount("User3"), adminPlayer.GetAccount("User2"), games[1]);
		newGame(adminPlayer.GetAccount("User3"), adminPlayer.GetAccount("User1"), games[1]);
		newGame(adminPlayer.GetAccount("User2"), adminPlayer.GetAccount("User1"), games[1]);
		newGame(adminPlayer.GetAccount("User3"), adminPlayer.GetAccount("User2"), games[1]);
		newGame(adminPlayer.GetAccount("User1"), adminPlayer.GetAccount("User2"), games[1]);

		games.Add(adminGame.CreateGame("training", 30));

		newGame(adminPlayer.GetAccount("User3"), adminPlayer.GetAccount("User2"), games[2]);
		newGame(adminPlayer.GetAccount("User3"), adminPlayer.GetAccount("User2"), games[2]);
		newGame(adminPlayer.GetAccount("User3"), adminPlayer.GetAccount("User1"), games[2]);
		newGame(adminPlayer.GetAccount("User2"), adminPlayer.GetAccount("User1"), games[2]);
		newGame(adminPlayer.GetAccount("User3"), adminPlayer.GetAccount("User2"), games[2]);
		newGame(adminPlayer.GetAccount("User1"), adminPlayer.GetAccount("User2"), games[2]);	
	}

	static void Main() {
    	DbContext dbContext = new DbContext();
		List<Game> games = [];

		PlayerService adminPlayer = new PlayerService(dbContext);
		GameService	  adminGame   = new GameService(dbContext);

		adminPlayer.CreateAccont("User1", "StandartAccount");
		adminPlayer.CreateAccont("User2", "PayAccount");
		adminPlayer.CreateAccont("User3", "WinstreakAccount");

		Console.Write("Вивести данні акаунту User2: \n");
		adminPlayer.OutputAccountById("User2");

		Console.Write("Вивести данні всіх акаунтів: \n");
		adminPlayer.OutputAllAccount();
		

		playGame(adminPlayer, adminGame, games);
		
		Console.Write("Вивести данні гри game2: \n");
		adminGame.OutputGameById(games[2]);

		Console.Write("Вивести данні всіх ігор: \n");
		adminGame.OutputAllGame();	

		Console.Write("Вивести всі партії User3: \n");
		adminPlayer.OutputPlayerGamesByPlayerId("User3");
	}
}

