namespace LiveSplit.BM
{
    partial class BMSettings
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbStartSplits = new System.Windows.Forms.GroupBox();
            this.tlpStartSplits = new System.Windows.Forms.TableLayoutPanel();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.chkAutoReset = new System.Windows.Forms.CheckBox();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.gbEndSplits = new System.Windows.Forms.GroupBox();
            this.tlpEndSplits = new System.Windows.Forms.TableLayoutPanel();
            this.chk00 = new System.Windows.Forms.CheckBox();
            this.chk01 = new System.Windows.Forms.CheckBox();
            this.chk04 = new System.Windows.Forms.CheckBox();
            this.chk03 = new System.Windows.Forms.CheckBox();
            this.chk05 = new System.Windows.Forms.CheckBox();
            this.chk06 = new System.Windows.Forms.CheckBox();
            this.chk02 = new System.Windows.Forms.CheckBox();
            this.chk08 = new System.Windows.Forms.CheckBox();
            this.chk09 = new System.Windows.Forms.CheckBox();
            this.chk10 = new System.Windows.Forms.CheckBox();
            this.chk11 = new System.Windows.Forms.CheckBox();
            this.chk12 = new System.Windows.Forms.CheckBox();
            this.chk13 = new System.Windows.Forms.CheckBox();
            this.gbStartSplits.SuspendLayout();
            this.tlpStartSplits.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.gbEndSplits.SuspendLayout();
            this.tlpEndSplits.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbStartSplits
            // 
            this.gbStartSplits.Controls.Add(this.tlpStartSplits);
            this.gbStartSplits.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbStartSplits.Location = new System.Drawing.Point(3, 3);
            this.gbStartSplits.Name = "gbStartSplits";
            this.gbStartSplits.Size = new System.Drawing.Size(434, 65);
            this.gbStartSplits.TabIndex = 5;
            this.gbStartSplits.TabStop = false;
            this.gbStartSplits.Text = "Start Auto-splits";
            // 
            // tlpStartSplits
            // 
            this.tlpStartSplits.BackColor = System.Drawing.Color.Transparent;
            this.tlpStartSplits.ColumnCount = 1;
            this.tlpStartSplits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStartSplits.Controls.Add(this.chkAutoStart, 0, 1);
            this.tlpStartSplits.Controls.Add(this.chkAutoReset, 0, 0);
            this.tlpStartSplits.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpStartSplits.Location = new System.Drawing.Point(3, 16);
            this.tlpStartSplits.Name = "tlpStartSplits";
            this.tlpStartSplits.RowCount = 2;
            this.tlpStartSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpStartSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpStartSplits.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStartSplits.Size = new System.Drawing.Size(428, 46);
            this.tlpStartSplits.TabIndex = 4;
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Checked = true;
            this.chkAutoStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoStart.Location = new System.Drawing.Point(3, 26);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(48, 17);
            this.chkAutoStart.TabIndex = 5;
            this.chkAutoStart.Text = "Start";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            // 
            // chkAutoReset
            // 
            this.chkAutoReset.AutoSize = true;
            this.chkAutoReset.Checked = true;
            this.chkAutoReset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoReset.Location = new System.Drawing.Point(3, 3);
            this.chkAutoReset.Name = "chkAutoReset";
            this.chkAutoReset.Size = new System.Drawing.Size(54, 17);
            this.chkAutoReset.TabIndex = 4;
            this.chkAutoReset.Text = "Reset";
            this.chkAutoReset.UseVisualStyleBackColor = true;
            this.chkAutoReset.CheckedChanged += new System.EventHandler(this.chkAutoReset_CheckedChanged);
            // 
            // tlpMain
            // 
            this.tlpMain.AutoSize = true;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.gbStartSplits, 0, 0);
            this.tlpMain.Controls.Add(this.gbEndSplits, 0, 1);
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(440, 401);
            this.tlpMain.TabIndex = 0;
            // 
            // gbEndSplits
            // 
            this.gbEndSplits.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbEndSplits.Controls.Add(this.tlpEndSplits);
            this.gbEndSplits.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbEndSplits.Location = new System.Drawing.Point(3, 74);
            this.gbEndSplits.Name = "gbEndSplits";
            this.gbEndSplits.Size = new System.Drawing.Size(434, 321);
            this.gbEndSplits.TabIndex = 7;
            this.gbEndSplits.TabStop = false;
            this.gbEndSplits.Text = "Auto-split";
            // 
            // tlpEndSplits
            // 
            this.tlpEndSplits.BackColor = System.Drawing.Color.Transparent;
            this.tlpEndSplits.ColumnCount = 1;
            this.tlpEndSplits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpEndSplits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpEndSplits.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpEndSplits.Controls.Add(this.chk00, 0, 1);
            this.tlpEndSplits.Controls.Add(this.chk01, 0, 2);
            this.tlpEndSplits.Controls.Add(this.chk04, 0, 4);
            this.tlpEndSplits.Controls.Add(this.chk03, 0, 3);
            this.tlpEndSplits.Controls.Add(this.chk05, 0, 5);
            this.tlpEndSplits.Controls.Add(this.chk06, 0, 6);
            this.tlpEndSplits.Controls.Add(this.chk02, 0, 7);
            this.tlpEndSplits.Controls.Add(this.chk08, 0, 8);
            this.tlpEndSplits.Controls.Add(this.chk09, 0, 9);
            this.tlpEndSplits.Controls.Add(this.chk10, 0, 10);
            this.tlpEndSplits.Controls.Add(this.chk11, 0, 11);
            this.tlpEndSplits.Controls.Add(this.chk12, 0, 12);
            this.tlpEndSplits.Controls.Add(this.chk13, 0, 13);
            this.tlpEndSplits.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpEndSplits.Location = new System.Drawing.Point(3, 16);
            this.tlpEndSplits.Name = "tlpEndSplits";
            this.tlpEndSplits.RowCount = 12;
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEndSplits.Size = new System.Drawing.Size(428, 299);
            this.tlpEndSplits.TabIndex = 4;
            // 
            // chk00
            // 
            this.chk00.AutoSize = true;
            this.chk00.Location = new System.Drawing.Point(3, 3);
            this.chk00.Name = "chk00";
            this.chk00.Size = new System.Drawing.Size(126, 17);
            this.chk00.TabIndex = 6;
            this.chk00.Text = "Death of a Showman";
            this.chk00.UseVisualStyleBackColor = true;
            this.chk00.CheckedChanged += new System.EventHandler(this.chk00_CheckedChanged);
            // 
            // chk01
            // 
            this.chk01.AutoSize = true;
            this.chk01.Checked = true;
            this.chk01.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk01.Location = new System.Drawing.Point(3, 26);
            this.chk01.MinimumSize = new System.Drawing.Size(0, 17);
            this.chk01.Name = "chk01";
            this.chk01.Size = new System.Drawing.Size(97, 17);
            this.chk01.TabIndex = 7;
            this.chk01.Text = "A Vintage Year";
            this.chk01.UseVisualStyleBackColor = true;
            // 
            // chk04
            // 
            this.chk04.AutoSize = true;
            this.chk04.Checked = true;
            this.chk04.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk04.Location = new System.Drawing.Point(3, 72);
            this.chk04.Name = "chk04";
            this.chk04.Size = new System.Drawing.Size(59, 17);
            this.chk04.TabIndex = 8;
            this.chk04.Text = "Flatline";
            this.chk04.UseVisualStyleBackColor = true;
            // 
            // chk03
            // 
            this.chk03.AutoSize = true;
            this.chk03.Checked = true;
            this.chk03.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk03.Location = new System.Drawing.Point(3, 49);
            this.chk03.Name = "chk03";
            this.chk03.Size = new System.Drawing.Size(95, 17);
            this.chk03.TabIndex = 80;
            this.chk03.Text = "Curtains Down";
            this.chk03.UseVisualStyleBackColor = true;
            // 
            // chk05
            // 
            this.chk05.AutoSize = true;
            this.chk05.Checked = true;
            this.chk05.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk05.Location = new System.Drawing.Point(3, 95);
            this.chk05.Name = "chk05";
            this.chk05.Size = new System.Drawing.Size(78, 17);
            this.chk05.TabIndex = 12;
            this.chk05.Text = "A New Life";
            this.chk05.UseVisualStyleBackColor = true;
            // 
            // chk06
            // 
            this.chk06.AutoSize = true;
            this.chk06.Checked = true;
            this.chk06.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk06.Location = new System.Drawing.Point(3, 118);
            this.chk06.Name = "chk06";
            this.chk06.Size = new System.Drawing.Size(125, 17);
            this.chk06.TabIndex = 79;
            this.chk06.Text = "The Murder of Crows";
            this.chk06.UseVisualStyleBackColor = true;
            // 
            // chk02
            // 
            this.chk02.AutoSize = true;
            this.chk02.Checked = true;
            this.chk02.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk02.Location = new System.Drawing.Point(3, 141);
            this.chk02.Name = "chk02";
            this.chk02.Size = new System.Drawing.Size(140, 17);
            this.chk02.TabIndex = 15;
            this.chk02.Text = "You Better Watch Out...";
            this.chk02.UseVisualStyleBackColor = true;
            // 
            // chk08
            // 
            this.chk08.AutoSize = true;
            this.chk08.Checked = true;
            this.chk08.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk08.Location = new System.Drawing.Point(3, 164);
            this.chk08.Name = "chk08";
            this.chk08.Size = new System.Drawing.Size(140, 17);
            this.chk08.TabIndex = 14;
            this.chk08.Text = "Death on the Mississippi";
            this.chk08.UseVisualStyleBackColor = true;
            // 
            // chk09
            // 
            this.chk09.AutoSize = true;
            this.chk09.Checked = true;
            this.chk09.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk09.Location = new System.Drawing.Point(3, 187);
            this.chk09.Name = "chk09";
            this.chk09.Size = new System.Drawing.Size(126, 17);
            this.chk09.TabIndex = 17;
            this.chk09.Text = "Till Death Do Us Part";
            this.chk09.UseVisualStyleBackColor = true;
            // 
            // chk10
            // 
            this.chk10.AutoSize = true;
            this.chk10.Checked = true;
            this.chk10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk10.Location = new System.Drawing.Point(3, 210);
            this.chk10.Name = "chk10";
            this.chk10.Size = new System.Drawing.Size(109, 17);
            this.chk10.TabIndex = 18;
            this.chk10.Text = "A House of Cards";
            this.chk10.UseVisualStyleBackColor = true;
            // 
            // chk11
            // 
            this.chk11.AutoSize = true;
            this.chk11.Checked = true;
            this.chk11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk11.Location = new System.Drawing.Point(3, 233);
            this.chk11.Name = "chk11";
            this.chk11.Size = new System.Drawing.Size(135, 17);
            this.chk11.TabIndex = 19;
            this.chk11.Text = "A Dance with the Devil";
            this.chk11.UseVisualStyleBackColor = true;
            // 
            // chk12
            // 
            this.chk12.AutoSize = true;
            this.chk12.Checked = true;
            this.chk12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk12.Location = new System.Drawing.Point(3, 256);
            this.chk12.Name = "chk12";
            this.chk12.Size = new System.Drawing.Size(106, 17);
            this.chk12.TabIndex = 20;
            this.chk12.Text = "Amendment XXV";
            this.chk12.UseVisualStyleBackColor = true;
            // 
            // chk13
            // 
            this.chk13.AutoSize = true;
            this.chk13.Checked = true;
            this.chk13.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk13.Location = new System.Drawing.Point(3, 279);
            this.chk13.Name = "chk13";
            this.chk13.Size = new System.Drawing.Size(68, 17);
            this.chk13.TabIndex = 21;
            this.chk13.Text = "Requiem";
            this.chk13.UseVisualStyleBackColor = true;
            // 
            // BMSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tlpMain);
            this.Name = "BMSettings";
            this.Size = new System.Drawing.Size(443, 404);
            this.gbStartSplits.ResumeLayout(false);
            this.tlpStartSplits.ResumeLayout(false);
            this.tlpStartSplits.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.gbEndSplits.ResumeLayout(false);
            this.tlpEndSplits.ResumeLayout(false);
            this.tlpEndSplits.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbStartSplits;
        private System.Windows.Forms.TableLayoutPanel tlpStartSplits;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.CheckBox chkAutoReset;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox gbEndSplits;
        private System.Windows.Forms.TableLayoutPanel tlpEndSplits;
        private System.Windows.Forms.CheckBox chk00;
        private System.Windows.Forms.CheckBox chk01;
        private System.Windows.Forms.CheckBox chk04;
        private System.Windows.Forms.CheckBox chk03;
        private System.Windows.Forms.CheckBox chk05;
        private System.Windows.Forms.CheckBox chk06;
        private System.Windows.Forms.CheckBox chk02;
        private System.Windows.Forms.CheckBox chk08;
        private System.Windows.Forms.CheckBox chk09;
        private System.Windows.Forms.CheckBox chk10;
        private System.Windows.Forms.CheckBox chk11;
        private System.Windows.Forms.CheckBox chk12;
        private System.Windows.Forms.CheckBox chk13;
    }
}
