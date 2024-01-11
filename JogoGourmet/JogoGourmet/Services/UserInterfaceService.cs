using JogoGourmet.Interfaces;

namespace JogoGourmet.Services
{
    public class UserInterfaceService : IUserInterfaceService
    {
        public void ShowWinMessage()
        {
            MessageBox.Show("Acertei de novo!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool CorrectGuess(string dish)
        {
            return MessageBox.Show($"O prato que você pensou é {dish}?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                 is DialogResult.Yes;
        }

        public string AskForDefinition(string input, string dish)
        {
            return GetUserInput($"{input} é ____ mas {dish} não.");
        }

        public string AskForDish()
        {
            return GetUserInput("Que prato você pensou?");
        }

        private static string GetUserInput(string message)
        {
            InputDialog inputDialog = new(message);

            do
            {
                inputDialog.ShowDialog();
            } while (string.IsNullOrWhiteSpace(inputDialog.Input));

            return inputDialog.Input;
        }
    }
}
