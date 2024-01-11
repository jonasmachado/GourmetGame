namespace JogoGourmet
{
    public partial class InputDialog : Form
    {
        public InputDialog(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;
            AcceptButton = btOk;
        }

        public string Input => inputBox.Text;

        private void OkClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputBox.Text))
            {
                lblAlert.Visible = true;
                return;
            }

            Close();
        }
    }
}
