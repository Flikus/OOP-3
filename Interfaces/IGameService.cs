interface IGameService
{
    Game CreateGame(string typeGame, int rating);
    void OutputGameById(Game room);
    void OutputAllGame();
}