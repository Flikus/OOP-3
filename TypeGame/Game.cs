abstract class Game
{    
    protected static Random rnd = new Random();
    public string TypeGame { get; private set; }
    public int 	  Rating   { get; private set; }

    public Game (string typeGame, int rating) {
        if(rating < 0) {
            Console.WriteLine("Помилка: Рейтинг не може бути від'ємним");
            Environment.Exit(0);
        }
        TypeGame = typeGame;
        Rating = rating;
    }

    public abstract int WinCalculate();
    public abstract int LoseCalculate();
}