namespace Win_Tetris
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Panel = new System.Windows.Forms.TableLayoutPanel();
            this.drawBox = new System.Windows.Forms.PictureBox();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.ColumnCount = 2;
            this.Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Panel.Controls.Add(this.drawBox, 0, 1);
            this.Panel.Controls.Add(this.toolBar, 0, 0);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.RowCount = 2;
            this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Panel.Size = new System.Drawing.Size(292, 266);
            this.Panel.TabIndex = 0;
            // 
            // drawBox
            // 
            this.Panel.SetColumnSpan(this.drawBox, 2);
            this.drawBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawBox.Location = new System.Drawing.Point(3, 28);
            this.drawBox.Name = "drawBox";
            this.drawBox.Size = new System.Drawing.Size(286, 235);
            this.drawBox.TabIndex = 0;
            this.drawBox.TabStop = false;
            // 
            // toolBar
            // 
            this.Panel.SetColumnSpan(this.toolBar, 2);
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(292, 25);
            this.toolBar.TabIndex = 1;
            this.toolBar.Text = "toolStrip1";
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.Panel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Panel;
        private System.Windows.Forms.PictureBox drawBox;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.Timer updateTimer;
    }
}

