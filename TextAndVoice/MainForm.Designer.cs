namespace TextAndVoice
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.realTimeResults = new System.Windows.Forms.Label();
            this.finalAnswer = new System.Windows.Forms.Label();
            this.btClear = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.realTimeResults, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.finalAnswer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btClear, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // realTimeResults
            // 
            this.realTimeResults.AutoSize = true;
            this.realTimeResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.realTimeResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.realTimeResults.Location = new System.Drawing.Point(3, 0);
            this.realTimeResults.Name = "realTimeResults";
            this.realTimeResults.Size = new System.Drawing.Size(794, 153);
            this.realTimeResults.TabIndex = 0;
            // 
            // finalAnswer
            // 
            this.finalAnswer.AutoSize = true;
            this.finalAnswer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.finalAnswer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finalAnswer.Location = new System.Drawing.Point(3, 153);
            this.finalAnswer.Name = "finalAnswer";
            this.finalAnswer.Size = new System.Drawing.Size(794, 256);
            this.finalAnswer.TabIndex = 1;
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(3, 412);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(75, 23);
            this.btClear.TabIndex = 2;
            this.btClear.Text = "Очистить";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "TextAndVoice";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        internal System.Windows.Forms.Label finalAnswer;
        internal System.Windows.Forms.Label realTimeResults;
        private System.Windows.Forms.Button btClear;
    }
}

