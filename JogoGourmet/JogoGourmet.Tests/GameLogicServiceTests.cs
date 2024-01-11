using JogoGourmet.Domain;
using JogoGourmet.Interfaces;
using JogoGourmet.Services;
using Moq;

namespace JogoGourmet.Tests
{
    public class GameLogicServiceTests
    {
        private readonly Mock<IUserInterfaceService> _userInterfaceMock;
        private Node? _root;
        private GameLogicService? _gameLogicService;

        public GameLogicServiceTests()
        {
            _userInterfaceMock = new Mock<IUserInterfaceService>();
        }

        [Fact]
        public void Start_ShouldCheckCorrectGuessForTwoDefaultNodes()
        {
            SetupTree();
            _gameLogicService = new GameLogicService(_userInterfaceMock.Object, _root!);

            _gameLogicService.Start();

            _userInterfaceMock.Verify(x => x.CorrectGuess(It.IsAny<string>()), Times.Exactly(2));
        }

        [Theory]
        [InlineData("Bolo de Cenoura")]
        [InlineData("Bolo de Abacaxi")]
        [InlineData("Bolo de Tomate")]
        public void Start_ShouldAddNewOption(string input)
        {
            const string leafValue = "Bolo de Chocolate";
            SetupTree();
            _gameLogicService = new GameLogicService(_userInterfaceMock.Object, _root!);

            _userInterfaceMock.SetupSequence(x => x.CorrectGuess(It.IsAny<string>()))
                .Returns(false)
                .Returns(false);

            _userInterfaceMock.Setup(x => x.AskForDish()).Returns(input);

            _gameLogicService.Start();

            _userInterfaceMock.Verify(x => x.AskForDefinition(input, leafValue), Times.Once);
        }

        [Fact]
        public void Start_ShouldGuessSuccessfully()
        {
            SetupTree();
            _gameLogicService = new GameLogicService(_userInterfaceMock.Object, _root!);

            _userInterfaceMock.Setup(x => x.CorrectGuess(It.IsAny<string>())).Returns(true);

            _gameLogicService.Start();

            _userInterfaceMock.Verify(x => x.ShowWinMessage(), Times.Once);
        }

        private void SetupTree()
        {
            _root = new Node { Dish = "Massa" };
            _root.PositiveBranch = new Node { Dish = "Lasanha", Parent = _root };
            _root.NegativeBranch = new Node { Dish = "Bolo de Chocolate", Parent = _root };
        }
    }
}
