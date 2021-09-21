
namespace SQL3
{
    partial class Zagruzka
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Zagruzka));
            this.prograssbar1 = new CircularProgressBar.CircularProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // prograssbar1
            // 
            this.prograssbar1.AnimationFunction = ((WinFormAnimation.AnimationFunctions.Function)(resources.GetObject("prograssbar1.AnimationFunction")));
            this.prograssbar1.AnimationSpeed = 500;
            this.prograssbar1.BackColor = System.Drawing.SystemColors.Window;
            this.prograssbar1.Font = new System.Drawing.Font("Microsoft Yi Baiti", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prograssbar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.prograssbar1.InnerColor = System.Drawing.SystemColors.Window;
            this.prograssbar1.InnerMargin = 2;
            this.prograssbar1.InnerWidth = -1;
            this.prograssbar1.Location = new System.Drawing.Point(47, 92);
            this.prograssbar1.MarqueeAnimationSpeed = 2000;
            this.prograssbar1.Name = "prograssbar1";
            this.prograssbar1.OuterColor = System.Drawing.SystemColors.ButtonHighlight;
            this.prograssbar1.OuterMargin = -25;
            this.prograssbar1.OuterWidth = 20;
            this.prograssbar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.prograssbar1.ProgressWidth = 10;
            this.prograssbar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.prograssbar1.Size = new System.Drawing.Size(150, 150);
            this.prograssbar1.StartAngle = 270;
            this.prograssbar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prograssbar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.prograssbar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.prograssbar1.SubscriptText = "";
            this.prograssbar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.prograssbar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.prograssbar1.SuperscriptText = "";
            this.prograssbar1.TabIndex = 0;
            this.prograssbar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.prograssbar1.Value = 68;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Yi Baiti", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.label2.Location = new System.Drawing.Point(78, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Загрузка...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Yi Baiti", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.label3.Location = new System.Drawing.Point(199, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "© Л.С.";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Zagruzka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(255, 378);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.prograssbar1);
            this.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Zagruzka";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zagruzka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CircularProgressBar.CircularProgressBar prograssbar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}