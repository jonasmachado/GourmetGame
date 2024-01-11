using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoGourmet
{
    public partial class GourmetGameBaseForm : Form
    {
        private readonly Node _root;
        public GourmetGameBaseForm()
        {
            _root = new Node { Dish = "Massa" };
            _root.YesAnswerNode = new Node { Dish = "Lasanha", Parent = _root };
            _root.NoAnswerNode = new Node { Dish = "Bolo de Chocolate", Parent = _root };
            InitializeComponent();
        }

        private void OkClick(object sender, EventArgs e)
        {
            _root.Find();
        }
    }
}
