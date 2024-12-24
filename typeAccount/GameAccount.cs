class GameAccount 
{	
	public string				TypeAccount {get; private set;}         //тип акаунту
  	public string 				UserName {get; private set;}    	 	//Імя користувача
  	public int 	  				CurrentRating {get; protected  set;}  	//Рейтинг користувача
	public int 	  				GamesCount {get; private set;}  		//Кількість зіграних партій
	protected List<PlayedGame> 	GameHistory; 							//істворія ігор
	
	
	public GameAccount(string userName, string typeAccount) {
		UserName = userName;
		TypeAccount = typeAccount;
		CurrentRating = 100;
		GamesCount = 0;
		GameHistory = new List<PlayedGame>();
	}

	public virtual void WinGame(string opponentName, Game game) {
		GameHistory.Add(new PlayedGame(opponentName, game.Rating, CurrentRating, "win", TypeAccount, game.TypeGame)); 
        GamesCount++;		
	}
	public virtual void LoseGame(string opponentName, Game game) {
		GameHistory.Add(new PlayedGame(opponentName, game.Rating, CurrentRating, "lose", TypeAccount, game.TypeGame));
        GamesCount++;		
	}

	public void GetStats() {
		Console.WriteLine("гравець: " + UserName);
		Console.WriteLine("Кількість зіграних партій: " + GamesCount);

		Console.WriteLine("-----------------------------------------------------------------------------------------");
		Console.WriteLine("| індекс гри | тип акунта | Рейтинг | Опонент | Зіграний рейтинг | Результат |  тип гри |");
		for(int i = 0; i < GameHistory.Count; i++){		
			Console.Write("|{0,11:d10} |",GameHistory[i].GamrId);		
			Console.Write("{0,11} |",	  GameHistory[i].TypeAccount);			
			Console.Write("{0, 8} |",	  GameHistory[i].Rating);
			Console.Write("{0, 8} |",	  GameHistory[i].OpponentName);
			Console.Write("{0,17} |",	  GameHistory[i].GameRating);
			Console.Write("{0,10} |",	  GameHistory[i].Result);	
			Console.Write("{0, 9} |",	  GameHistory[i].TypeGame);

			Console.Write("\n");
		}
		Console.WriteLine("-----------------------------------------------------------------------------------------");
	}
}