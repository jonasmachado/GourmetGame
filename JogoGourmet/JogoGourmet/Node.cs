namespace JogoGourmet
{
    internal class Node
    {
        public required string Dish { get; set; }

        public Node? Parent { get; set; }

        public Node? YesAnswerNode { get; set; }

        public Node? NoAnswerNode { get; set; }

        private string GuessMessage => $"O prato que você pensou é {Dish}?";
        private bool LastNode => YesAnswerNode is null && NoAnswerNode is null;
        private string DishDefinitionMessage(string input) => $"{input} é ____ mas {Dish} não.";

        public string? Find()
        {
            if (CorrectGuess())
            {
                if (YesAnswerNode is null)
                {
                    MessageBox.Show("Acertei de novo!");
                    return Dish;
                }

                return YesAnswerNode.Find();
            }

            if (LastNode)
            {
                var dish = AskForDish();
                var definition = AskForDefinition(dish);

                var dishNode = new Node { Dish = dish };
                var definitionNode = new Node { Dish = definition, YesAnswerNode = dishNode, NoAnswerNode = this };

                dishNode.Parent = definitionNode;
                definitionNode.Parent = this.Parent;

                if (Parent != null)
                {
                    if (Parent.YesAnswerNode == this)
                    {
                        Parent.YesAnswerNode = definitionNode;
                    }
                    else if (Parent.NoAnswerNode == this)
                    {
                        Parent.NoAnswerNode = definitionNode;
                    }
                }

                Parent = definitionNode;

                return null;
            }

            return NoAnswerNode!.Find();
        }

        private bool CorrectGuess()
        {
            var result = MessageBox.Show(GuessMessage, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result is DialogResult.Yes;
        }

        private string AskForDefinition(string input)
        {
            return GetUserInput(DishDefinitionMessage(input));
        }

        private static string AskForDish()
        {
            return GetUserInput("Que prato você pensou?");
        }

        private static string GetUserInput(string message)
        {
            InputDialog inputDialog = new(message);
            inputDialog.ShowDialog();

            return inputDialog.Input;
        }
    }
}
