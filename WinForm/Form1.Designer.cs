
namespace WinForm
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.input = new System.Windows.Forms.NumericUpDown();
            this.RocketAdder = new System.Windows.Forms.Button();
            this.FreezeAdder = new System.Windows.Forms.Button();
            this.SnipeAdder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.input)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Money: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(189, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Magic!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // input
            // 
            this.input.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.input.Location = new System.Drawing.Point(63, 7);
            this.input.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(120, 20);
            this.input.TabIndex = 3;
            // 
            // RocketAdder
            // 
            this.RocketAdder.Location = new System.Drawing.Point(19, 57);
            this.RocketAdder.Name = "RocketAdder";
            this.RocketAdder.Size = new System.Drawing.Size(54, 53);
            this.RocketAdder.TabIndex = 4;
            this.RocketAdder.Text = "Rocket";
            this.RocketAdder.UseVisualStyleBackColor = true;
            this.RocketAdder.Click += new System.EventHandler(this.AddRocketsToWishList);
            // 
            // FreezeAdder
            // 
            this.FreezeAdder.Location = new System.Drawing.Point(19, 116);
            this.FreezeAdder.Name = "FreezeAdder";
            this.FreezeAdder.Size = new System.Drawing.Size(54, 52);
            this.FreezeAdder.TabIndex = 5;
            this.FreezeAdder.Text = "Freeze";
            this.FreezeAdder.UseVisualStyleBackColor = true;
            this.FreezeAdder.Click += new System.EventHandler(this.AddFreezeToWishList);
            // 
            // SnipeAdder
            // 
            this.SnipeAdder.Location = new System.Drawing.Point(19, 232);
            this.SnipeAdder.Name = "SnipeAdder";
            this.SnipeAdder.Size = new System.Drawing.Size(54, 52);
            this.SnipeAdder.TabIndex = 7;
            this.SnipeAdder.Text = "Snipe";
            this.SnipeAdder.UseVisualStyleBackColor = true;
            this.SnipeAdder.Click += new System.EventHandler(this.AddSnipeToWishList);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 380);
            this.Controls.Add(this.SnipeAdder);
            this.Controls.Add(this.FreezeAdder);
            this.Controls.Add(this.RocketAdder);
            this.Controls.Add(this.input);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.input)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown input;
        private System.Windows.Forms.Button RocketAdder;
        private System.Windows.Forms.Button FreezeAdder;
        private System.Windows.Forms.Button SnipeAdder;
    }
}

