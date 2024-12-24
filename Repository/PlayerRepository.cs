class PlayerRepository : IPlayerRepository
{
    DbContext dbContext;

    public PlayerRepository(DbContext dbContextObj)
    {
        dbContext = dbContextObj;
    }

    // Додати гравця до бази даних
    public void CreatePlayer(string userName, string typeAccount)
    {   
        if(dbContext.Players.FindIndex(p => p.UserName == userName) >= 0){
            Console.Write("Користувач з таким іменем вже існує");           
        }
        else {
            // Створюємо користувача
            switch(typeAccount)
            {
            case "StandartAccount":  dbContext.Players.Add(new StandartAccount(userName));  break;
            case "PayAccount":       dbContext.Players.Add(new PayAccount(userName));       break;
            case "WinstreakAccount": dbContext.Players.Add(new WinstreakAccount(userName)); break;
            default: Console.Write("Неіснуючий тип акаунту"); Environment.Exit(1);          break;
            }  
        }
    }



    // Отримати загальну кількість гравців
    public int ReadPlayer(int value)
    {
        if(value == 1)
            return dbContext.Players.Count();
        return -1;
    }

    // Отримати індекс гравця за іменем
    public int ReadPlayer(string userName)
    {
        int index = dbContext.Players.FindIndex(p => p.UserName == userName);
        if(index < 0 || index > ReadPlayer(1)) {
            Console.Write("Користувача з таким іменем не знайдено"); 
            Environment.Exit(1); 
        }
       return index;
    }


    // Отримати гравця за ім'ям
    public GameAccount ReadAccount(string userName)
    {
        return dbContext.Players[ReadPlayer(userName)];
    }
    
    public void ReadPlayerGamesByPlayerId(string userName)
    {
        ReadAccount(userName).GetStats(); 
    }


    // Отримати гравця за індексом
    public GameAccount ReadAccount(int ind)
    {   
        if(ind < 0 || ind > ReadPlayer(1)) {
            Console.Write("Користувача з таким іменем не знайдено"); 
            Environment.Exit(1); 
        }
        return dbContext.Players[ind];
    }





    // Видалити гравця з бази даних
    public void DeletePlayer(string userName)
    {   
        int index = dbContext.Players.FindIndex(p => p.UserName == userName);
        if(index < 0 || index > ReadPlayer(1)) {
            Console.Write("Користувача з таким іменем не знайдено"); 
            Environment.Exit(1); 
        }

        dbContext.Players.Remove(dbContext.Players[index]);
    }
}