class GameRepository : IGameRepository
{
    DbContext dbContext;
    static Fabric fabric = new Fabric();

    public GameRepository(DbContext dbContextObj)
    {
        dbContext = dbContextObj;
    }



    // Додати кімнату для гри до бази даних
    public Game CreateGame(string typeGame, int rating)
    {          
        if(dbContext.Games.FindIndex(g => (g.TypeGame == typeGame) && (g.Rating == rating)) >= 0) {
            Console.Write("Така гра вже існує"); 
            Environment.Exit(1);
        }

        Game game = fabric.CreateGame(typeGame, rating);
        dbContext.Games.Add(game);
        return game;
    }


    // Отримати загальну кількість кімнат(ігор)
    public int ReadGame(int value)
    {
        if(value == 1)
            return dbContext.Games.Count();
        return -1;
    }

    // Отримати індекс кімнати(гри)
    public int ReadGame(Game room)
    {   
        int index = dbContext.Games.IndexOf(room);
        if(index < 0) 
            Console.Write("Такої гри не існує\n"); 

       return index;
    }

    // Отримати індекс кімнати(гри)
    public int ReadGame(string typeGame, int rating)
    {   
        int index = dbContext.Games.FindIndex(g => (g.TypeGame == typeGame) && (g.Rating == rating));
        if(index <= 0) 
            Console.Write("Такої гри не існує\n"); 
        return index;
    }    
 

   // Отримати кімнату(гру)
    public Game ReadRoom(int index)
    {
        if(index < 0 || index > ReadGame(1)) {
            Console.Write("Такої гри не існує\n"); 
            return new StandartGame(null, -1);
        }
        return dbContext.Games[index];
    }


    // Видалити кімнату(гру) з бази даних
    public void DeleteGame(Game room)
    {   
        int index = dbContext.Games.IndexOf(room);
        if(index < 0) 
            Console.Write("Гру з таким параметрами не знайдено"); 
        else
            dbContext.Games.Remove(dbContext.Games[index]);
    }
}