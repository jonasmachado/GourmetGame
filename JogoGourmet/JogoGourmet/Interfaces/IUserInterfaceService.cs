namespace JogoGourmet.Interfaces
{
    public interface IUserInterfaceService
    {
        void ShowWinMessage();
        string AskForDefinition(string input, string dish);
        string AskForDish();
        bool CorrectGuess(string dish);
    }
}