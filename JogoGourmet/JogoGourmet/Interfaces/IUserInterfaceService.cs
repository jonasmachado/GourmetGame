namespace JogoGourmet.Interfaces
{
    internal interface IUserInterfaceService
    {
        string AskForDefinition(string input, string dish);
        string AskForDish();
        bool CorrectGuess(string dish);
    }
}