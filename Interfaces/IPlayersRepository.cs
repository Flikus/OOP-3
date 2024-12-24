interface IPlayerRepository
{
    void CreatePlayer(string username, string typeAccount); // Додати гравця до бази даних
    int ReadPlayer(int value);                              // Отримати загальну кількість гравців
    int ReadPlayer(string userName);                        // Отримати індекс гравця за іменем
    GameAccount ReadAccount(string userName);               // Отримати гравця за ім'ям
    public GameAccount ReadAccount(int ind);                // Отримати гравця за індексом
    void ReadPlayerGamesByPlayerId(string userName);        // Вивід списку ігор конкретного гравця.
    void DeletePlayer(string userName);                     // Видалити гравця з бази даних
}