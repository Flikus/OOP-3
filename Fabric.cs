class Fabric
{
    public Game CreateGame (string nameGame, int rating) {

        
        switch(nameGame)
        {
        case "standart": return new StandartGame("standart", rating);
        case "onerisk" : return new OneriskGame("onerisk", rating);
        case "training": return new TrainingGame("training");
        default        : Console.Write("\nПомилка: такого типу гри не існує\n\n"); Environment.Exit(1); return new StandartGame(null, -1);            
        }
    }
}