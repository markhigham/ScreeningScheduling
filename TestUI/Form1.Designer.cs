namespace TestUI
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
            this.runButton = new System.Windows.Forms.Button();
            this.tasks = new System.Windows.Forms.TextBox();
            this.dependencies = new System.Windows.Forms.TextBox();
            this.results = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(549, 27);
            this.runButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(87, 28);
            this.runButton.TabIndex = 2;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // tasks
            // 
            this.tasks.Location = new System.Drawing.Point(163, 27);
            this.tasks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tasks.Name = "tasks";
            this.tasks.Size = new System.Drawing.Size(340, 23);
            this.tasks.TabIndex = 0;
            // 
            // dependencies
            // 
            this.dependencies.Location = new System.Drawing.Point(163, 59);
            this.dependencies.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dependencies.Name = "dependencies";
            this.dependencies.Size = new System.Drawing.Size(340, 23);
            this.dependencies.TabIndex = 1;
            // 
            // results
            // 
            this.results.Location = new System.Drawing.Point(163, 91);
            this.results.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.results.Name = "results";
            this.results.ReadOnly = true;
            this.results.Size = new System.Drawing.Size(340, 23);
            this.results.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tasks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Dependencies";
            // 
            // resultsLabel
            // 
            this.resultsLabel.AutoSize = true;
            this.resultsLabel.Location = new System.Drawing.Point(15, 95);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(49, 16);
            this.resultsLabel.TabIndex = 6;
            this.resultsLabel.Text = "Results";
            // 
            // Form1
            // 
            this.AcceptButton = this.runButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 193);
            this.Controls.Add(this.resultsLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.results);
            this.Controls.Add(this.dependencies);
            this.Controls.Add(this.tasks);
            this.Controls.Add(this.runButton);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.TextBox tasks;
        private System.Windows.Forms.TextBox dependencies;
        private System.Windows.Forms.TextBox results;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label resultsLabel;
    }
}

