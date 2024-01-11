using JogoGourmet.Domain;
using JogoGourmet.Services;

namespace JogoGourmet
{
    public partial class GourmetGameBaseForm : Form
    {
        private readonly GameLogicService _gameLogicService;
        public GourmetGameBaseForm()
        {
            var root = new Node { Dish = "Massa" };
            root.PositiveBranch = new Node { Dish = "Lasanha", Parent = root };
            root.NegativeBranch = new Node { Dish = "Bolo de Chocolate", Parent = root };

            _gameLogicService = new GameLogicService(new UserInterfaceService(), root);
            InitializeComponent();
        }

        private void OkClick(object sender, EventArgs e)
        {
            _gameLogicService.Start();
        }
    }
}
