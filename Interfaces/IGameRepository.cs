interface IGameRepository {
    public Game CreateGame(string typeGame, int rating);  // Додати кімнату для гри до бази даних
    int ReadGame(int value);                              // Отримати загальну кількість кімнат(ігор)
    int ReadGame(Game room);                              // Отримати індекс кімнати(гри) 
    Game ReadRoom(int index);                             // Отримати кімнату(гру) по індексу 
    void DeleteGame(Game room);                           // Видалити кімнату(гру) з бази даних
}