namespace minesweep
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menu = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Clock1 = new System.Windows.Forms.TextBox();
            this.endMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Location = new System.Drawing.Point(12, 12);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(172, 44);
            this.menu.TabIndex = 7;
            this.menu.Text = "Return to Menu";
            this.menu.UseVisualStyleBackColor = true;
            this.menu.Visible = false;
            this.menu.Click += new System.EventHandler(this.menu_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Clock1
            // 
            this.Clock1.BackColor = System.Drawing.SystemColors.Window;
            this.Clock1.Enabled = false;
            this.Clock1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clock1.ForeColor = System.Drawing.Color.Red;
            this.Clock1.Location = new System.Drawing.Point(368, 12);
            this.Clock1.Multiline = true;
            this.Clock1.Name = "Clock1";
            this.Clock1.ReadOnly = true;
            this.Clock1.Size = new System.Drawing.Size(104, 44);
            this.Clock1.TabIndex = 10;
            this.Clock1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Clock1.TextChanged += new System.EventHandler(this.Clock1_TextChanged);
            // 
            // endMessage
            // 
            this.endMessage.Enabled = false;
            this.endMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endMessage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.endMessage.Location = new System.Drawing.Point(190, 12);
            this.endMessage.Multiline = true;
            this.endMessage.Name = "endMessage";
            this.endMessage.Size = new System.Drawing.Size(172, 44);
            this.endMessage.TabIndex = 11;
            this.endMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.endMessage.Visible = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 444);
            this.Controls.Add(this.endMessage);
            this.Controls.Add(this.Clock1);
            this.Controls.Add(this.menu);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MineSweeper";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button menu;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox Clock1;
        private System.Windows.Forms.TextBox endMessage;
    }
}