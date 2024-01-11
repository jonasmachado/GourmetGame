namespace JogoGourmet
{
    partial class InputDialog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMessage = new Label();
            inputBox = new TextBox();
            btOk = new Button();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(42, 33);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(171, 20);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Placeholder for question";
            // 
            // inputBox
            // 
            inputBox.Font = new Font("Segoe UI", 12F);
            inputBox.Location = new Point(42, 67);
            inputBox.Name = "inputBox";
            inputBox.Size = new Size(276, 34);
            inputBox.TabIndex = 1;
            // 
            // btOk
            // 
            btOk.Location = new Point(129, 118);
            btOk.Name = "btOk";
            btOk.Size = new Size(94, 29);
            btOk.TabIndex = 2;
            btOk.Text = "Ok";
            btOk.UseVisualStyleBackColor = true;
            btOk.Click += OkClick;
            // 
            // InputDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 191);
            Controls.Add(btOk);
            Controls.Add(inputBox);
            Controls.Add(lblMessage);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "InputDialog";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMessage;
        private TextBox inputBox;
        private Button btOk;
    }
}
