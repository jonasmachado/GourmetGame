using JogoGourmet.Domain;
using JogoGourmet.Interfaces;

namespace JogoGourmet.Services
{
    internal class GameLogicService : IGameLogicService
    {
        private readonly IUserInterfaceService _userInterface;
        private readonly Node _root;

        public GameLogicService(IUserInterfaceService userInterface, Node root)
        {
            _userInterface = userInterface;
            _root = root;
        }

        public void Start()
        {
            Discover(_root);
        }

        private void Discover(Node node)
        {
            if (_userInterface.CorrectGuess(node.Dish))
            {
                if (node.PositiveBranch is null)
                {
                    MessageBox.Show("Acertei de novo!");
                    return;
                }

                Discover(node.PositiveBranch);
                return;
            }

            if (node.IsLeafNode)
            {
                var userInputDish = _userInterface.AskForDish();
                var definition = _userInterface.AskForDefinition(userInputDish, node.Dish);

                var dishNode = new Node { Dish = userInputDish };
                var definitionNode = new Node { Dish = definition, PositiveBranch = dishNode, NegativeBranch = node };

                dishNode.Parent = definitionNode;
                definitionNode.Parent = node.Parent;

                if (node.Parent != null)
                {
                    if (node.Parent.PositiveBranch == node)
                    {
                        node.Parent.PositiveBranch = definitionNode;
                    }
                    else if (node.Parent.NegativeBranch == node)
                    {
                        node.Parent.NegativeBranch = definitionNode;
                    }
                }

                node.Parent = definitionNode;
                return;
            }

            Discover(node.NegativeBranch!);
        }
    }
}
