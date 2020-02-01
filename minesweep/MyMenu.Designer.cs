namespace minesweep
{
    partial class MyMenu
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
            this.quit = new System.Windows.Forms.Button();
            this.SixteenbySixteen = new System.Windows.Forms.Button();
            this.SixteenbyThirty = new System.Windows.Forms.Button();
            this.NinebyNine = new System.Windows.Forms.Button();
            this.SuperHard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // quit
            // 
            this.quit.Location = new System.Drawing.Point(88, 152);
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(193, 29);
            this.quit.TabIndex = 1;
            this.quit.Text = "Quit Game";
            this.quit.UseVisualStyleBackColor = true;
            this.quit.Click += new System.EventHandler(this.button2_Click);
            // 
            // SixteenbySixteen
            // 
            this.SixteenbySixteen.Location = new System.Drawing.Point(88, 47);
            this.SixteenbySixteen.Name = "SixteenbySixteen";
            this.SixteenbySixteen.Size = new System.Drawing.Size(193, 29);
            this.SixteenbySixteen.TabIndex = 3;
            this.SixteenbySixteen.Text = "Medium Game 16 x 16";
            this.SixteenbySixteen.UseVisualStyleBackColor = true;
            this.SixteenbySixteen.Click += new System.EventHandler(this.SixteenbySixteen_Click);
            // 
            // SixteenbyThirty
            // 
            this.SixteenbyThirty.Location = new System.Drawing.Point(88, 82);
            this.SixteenbyThirty.Name = "SixteenbyThirty";
            this.SixteenbyThirty.Size = new System.Drawing.Size(193, 29);
            this.SixteenbyThirty.TabIndex = 4;
            this.SixteenbyThirty.Text = "Hard Game 16 x 30";
            this.SixteenbyThirty.UseVisualStyleBackColor = true;
            this.SixteenbyThirty.Click += new System.EventHandler(this.SixteenbyThirty_Click);
            // 
            // NinebyNine
            // 
            this.NinebyNine.Location = new System.Drawing.Point(88, 12);
            this.NinebyNine.Name = "NinebyNine";
            this.NinebyNine.Size = new System.Drawing.Size(193, 29);
            this.NinebyNine.TabIndex = 5;
            this.NinebyNine.Text = "Easy Game 9 x 9";
            this.NinebyNine.UseVisualStyleBackColor = true;
            this.NinebyNine.Click += new System.EventHandler(this.NinebyNine_Click);
            // 
            // SuperHard
            // 
            this.SuperHard.Location = new System.Drawing.Point(88, 117);
            this.SuperHard.Name = "SuperHard";
            this.SuperHard.Size = new System.Drawing.Size(193, 29);
            this.SuperHard.TabIndex = 7;
            this.SuperHard.Text = "Super Hard Game 40 x 50";
            this.SuperHard.UseVisualStyleBackColor = true;
            this.SuperHard.Click += new System.EventHandler(this.SuperHard_Click);
            // 
            // MyMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 453);
            this.Controls.Add(this.SuperHard);
            this.Controls.Add(this.NinebyNine);
            this.Controls.Add(this.SixteenbyThirty);
            this.Controls.Add(this.SixteenbySixteen);
            this.Controls.Add(this.quit);
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "MyMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MineSweeper";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button quit;
        private System.Windows.Forms.Button SixteenbySixteen;
        private System.Windows.Forms.Button SixteenbyThirty;
        private System.Windows.Forms.Button NinebyNine;
        private System.Windows.Forms.Button SuperHard;
    }
}

