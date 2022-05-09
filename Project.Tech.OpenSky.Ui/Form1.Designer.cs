namespace Project.Tech.OpenSky.Ui
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
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView3 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.listView4 = new System.Windows.Forms.ListView();
            this.StopAutoRunning = new System.Windows.Forms.Button();
            this.HighetFlight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button1.Location = new System.Drawing.Point(25, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 78);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 372);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(223, 197);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(538, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(351, 200);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(271, 197);
            this.listView2.TabIndex = 4;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseDoubleClick);
            // 
            // listView3
            // 
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(753, 232);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(253, 205);
            this.listView3.TabIndex = 5;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(538, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button2.Location = new System.Drawing.Point(758, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(248, 78);
            this.button2.TabIndex = 7;
            this.button2.Text = "Lowset Flight";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listView4
            // 
            this.listView4.HideSelection = false;
            this.listView4.Location = new System.Drawing.Point(12, 149);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(223, 179);
            this.listView4.TabIndex = 8;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView4_MouseClick);
            // 
            // StopAutoRunning
            // 
            this.StopAutoRunning.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.StopAutoRunning.Location = new System.Drawing.Point(269, 13);
            this.StopAutoRunning.Name = "StopAutoRunning";
            this.StopAutoRunning.Size = new System.Drawing.Size(210, 78);
            this.StopAutoRunning.TabIndex = 9;
            this.StopAutoRunning.Text = "Stop";
            this.StopAutoRunning.UseVisualStyleBackColor = true;
            this.StopAutoRunning.Click += new System.EventHandler(this.StopAutoRunning_Click);
            // 
            // HighetFlight
            // 
            this.HighetFlight.Font = new System.Drawing.Font("Microsoft YaHei", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.HighetFlight.Location = new System.Drawing.Point(758, 124);
            this.HighetFlight.Name = "HighetFlight";
            this.HighetFlight.Size = new System.Drawing.Size(248, 78);
            this.HighetFlight.TabIndex = 10;
            this.HighetFlight.Text = "Highet Flight";
            this.HighetFlight.UseVisualStyleBackColor = true;
            this.HighetFlight.Click += new System.EventHandler(this.HighetFlight_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 602);
            this.Controls.Add(this.HighetFlight);
            this.Controls.Add(this.StopAutoRunning);
            this.Controls.Add(this.listView4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.Button StopAutoRunning;
        private System.Windows.Forms.Button HighetFlight;
    }
}

