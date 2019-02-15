
namespace NetworkMonitor
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
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cmbInterfaces = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbSentAll = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbReciveAll = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbUnicastPacketsSent = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbUnicastPacketsReceived = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbOutputQueueLength = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbOutgoingPacketsWithErrors = new System.Windows.Forms.Label();
            this.lbOutgoingPacketsDiscarded = new System.Windows.Forms.Label();
            this.Label1000 = new System.Windows.Forms.Label();
            this.lbNonUnicastPacketsSent = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbNonUnicastPacketsReceived = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbIncomingUnknownProtocolPackets = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbIncomingPacketsError = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbIncomingPacketDiscarded = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbSentMb = new System.Windows.Forms.Label();
            this.lbReciveMb = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbInterfaceType = new System.Windows.Forms.Label();
            this.lbSpeed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbHasMulticast = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cmbInterfaces);
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(736, 394);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // cmbInterfaces
            // 
            this.cmbInterfaces.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbInterfaces.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterfaces.FormattingEnabled = true;
            this.cmbInterfaces.Location = new System.Drawing.Point(3, 3);
            this.cmbInterfaces.Name = "cmbInterfaces";
            this.cmbInterfaces.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbInterfaces.Size = new System.Drawing.Size(729, 21);
            this.cmbInterfaces.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.11653F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.88347F));
            this.tableLayoutPanel1.Controls.Add(this.lbSentAll, 1, 17);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.lbReciveAll, 1, 16);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.lbUnicastPacketsSent, 1, 15);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.lbUnicastPacketsReceived, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.lbOutputQueueLength, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.lbOutgoingPacketsWithErrors, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.lbOutgoingPacketsDiscarded, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.Label1000, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.lbNonUnicastPacketsSent, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.lbNonUnicastPacketsReceived, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.lbIncomingUnknownProtocolPackets, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.lbIncomingPacketsError, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lbIncomingPacketDiscarded, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbSentMb, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbReciveMb, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbStatus, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbInterfaceType, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbSpeed, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbHasMulticast, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 12);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 18;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(729, 360);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lbSentAll
            // 
            this.lbSentAll.AutoSize = true;
            this.lbSentAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSentAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSentAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSentAll.Location = new System.Drawing.Point(390, 340);
            this.lbSentAll.Name = "lbSentAll";
            this.lbSentAll.Size = new System.Drawing.Size(336, 20);
            this.lbSentAll.TabIndex = 35;
            this.lbSentAll.Text = "0";
            this.lbSentAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(3, 340);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(381, 20);
            this.label17.TabIndex = 34;
            this.label17.Text = "Всего переданоб МегаБайт";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbReciveAll
            // 
            this.lbReciveAll.AutoSize = true;
            this.lbReciveAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbReciveAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbReciveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbReciveAll.Location = new System.Drawing.Point(390, 320);
            this.lbReciveAll.Name = "lbReciveAll";
            this.lbReciveAll.Size = new System.Drawing.Size(336, 20);
            this.lbReciveAll.TabIndex = 33;
            this.lbReciveAll.Text = "0";
            this.lbReciveAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(3, 320);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(381, 20);
            this.label16.TabIndex = 32;
            this.label16.Text = "Всего получено, МегаБайт";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbUnicastPacketsSent
            // 
            this.lbUnicastPacketsSent.AutoSize = true;
            this.lbUnicastPacketsSent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbUnicastPacketsSent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUnicastPacketsSent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbUnicastPacketsSent.Location = new System.Drawing.Point(390, 300);
            this.lbUnicastPacketsSent.Name = "lbUnicastPacketsSent";
            this.lbUnicastPacketsSent.Size = new System.Drawing.Size(336, 20);
            this.lbUnicastPacketsSent.TabIndex = 31;
            this.lbUnicastPacketsSent.Text = "0";
            this.lbUnicastPacketsSent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(3, 300);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(381, 20);
            this.label15.TabIndex = 30;
            this.label15.Text = "Отправлено одноадресных пакетов";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbUnicastPacketsReceived
            // 
            this.lbUnicastPacketsReceived.AutoSize = true;
            this.lbUnicastPacketsReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbUnicastPacketsReceived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUnicastPacketsReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbUnicastPacketsReceived.Location = new System.Drawing.Point(390, 280);
            this.lbUnicastPacketsReceived.Name = "lbUnicastPacketsReceived";
            this.lbUnicastPacketsReceived.Size = new System.Drawing.Size(336, 20);
            this.lbUnicastPacketsReceived.TabIndex = 29;
            this.lbUnicastPacketsReceived.Text = "0";
            this.lbUnicastPacketsReceived.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(3, 280);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(381, 20);
            this.label14.TabIndex = 28;
            this.label14.Text = "Получено одноадресных пакетов";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbOutputQueueLength
            // 
            this.lbOutputQueueLength.AutoSize = true;
            this.lbOutputQueueLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbOutputQueueLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbOutputQueueLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbOutputQueueLength.Location = new System.Drawing.Point(390, 260);
            this.lbOutputQueueLength.Name = "lbOutputQueueLength";
            this.lbOutputQueueLength.Size = new System.Drawing.Size(336, 20);
            this.lbOutputQueueLength.TabIndex = 27;
            this.lbOutputQueueLength.Text = "0";
            this.lbOutputQueueLength.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(3, 260);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(381, 20);
            this.label13.TabIndex = 26;
            this.label13.Text = "Длина очереди вывода";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbOutgoingPacketsWithErrors
            // 
            this.lbOutgoingPacketsWithErrors.AutoSize = true;
            this.lbOutgoingPacketsWithErrors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbOutgoingPacketsWithErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbOutgoingPacketsWithErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbOutgoingPacketsWithErrors.Location = new System.Drawing.Point(390, 240);
            this.lbOutgoingPacketsWithErrors.Name = "lbOutgoingPacketsWithErrors";
            this.lbOutgoingPacketsWithErrors.Size = new System.Drawing.Size(336, 20);
            this.lbOutgoingPacketsWithErrors.TabIndex = 25;
            this.lbOutgoingPacketsWithErrors.Text = "0";
            this.lbOutgoingPacketsWithErrors.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbOutgoingPacketsDiscarded
            // 
            this.lbOutgoingPacketsDiscarded.AutoSize = true;
            this.lbOutgoingPacketsDiscarded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbOutgoingPacketsDiscarded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbOutgoingPacketsDiscarded.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbOutgoingPacketsDiscarded.Location = new System.Drawing.Point(390, 220);
            this.lbOutgoingPacketsDiscarded.Name = "lbOutgoingPacketsDiscarded";
            this.lbOutgoingPacketsDiscarded.Size = new System.Drawing.Size(336, 20);
            this.lbOutgoingPacketsDiscarded.TabIndex = 23;
            this.lbOutgoingPacketsDiscarded.Text = "0";
            this.lbOutgoingPacketsDiscarded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label1000
            // 
            this.Label1000.AutoSize = true;
            this.Label1000.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label1000.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1000.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label1000.Location = new System.Drawing.Point(3, 220);
            this.Label1000.Name = "Label1000";
            this.Label1000.Size = new System.Drawing.Size(381, 20);
            this.Label1000.TabIndex = 22;
            this.Label1000.Text = "Исходящих пакетов отброшено ";
            this.Label1000.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbNonUnicastPacketsSent
            // 
            this.lbNonUnicastPacketsSent.AutoSize = true;
            this.lbNonUnicastPacketsSent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNonUnicastPacketsSent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNonUnicastPacketsSent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbNonUnicastPacketsSent.Location = new System.Drawing.Point(390, 200);
            this.lbNonUnicastPacketsSent.Name = "lbNonUnicastPacketsSent";
            this.lbNonUnicastPacketsSent.Size = new System.Drawing.Size(336, 20);
            this.lbNonUnicastPacketsSent.TabIndex = 21;
            this.lbNonUnicastPacketsSent.Text = "0";
            this.lbNonUnicastPacketsSent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(3, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(381, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "Отправлено не одноадресных пакетов";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbNonUnicastPacketsReceived
            // 
            this.lbNonUnicastPacketsReceived.AutoSize = true;
            this.lbNonUnicastPacketsReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNonUnicastPacketsReceived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNonUnicastPacketsReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbNonUnicastPacketsReceived.Location = new System.Drawing.Point(390, 180);
            this.lbNonUnicastPacketsReceived.Name = "lbNonUnicastPacketsReceived";
            this.lbNonUnicastPacketsReceived.Size = new System.Drawing.Size(336, 20);
            this.lbNonUnicastPacketsReceived.TabIndex = 19;
            this.lbNonUnicastPacketsReceived.Text = "0";
            this.lbNonUnicastPacketsReceived.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(3, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(381, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "Получено не одноадресных пакетов";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbIncomingUnknownProtocolPackets
            // 
            this.lbIncomingUnknownProtocolPackets.AutoSize = true;
            this.lbIncomingUnknownProtocolPackets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbIncomingUnknownProtocolPackets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIncomingUnknownProtocolPackets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbIncomingUnknownProtocolPackets.Location = new System.Drawing.Point(390, 160);
            this.lbIncomingUnknownProtocolPackets.Name = "lbIncomingUnknownProtocolPackets";
            this.lbIncomingUnknownProtocolPackets.Size = new System.Drawing.Size(336, 20);
            this.lbIncomingUnknownProtocolPackets.TabIndex = 17;
            this.lbIncomingUnknownProtocolPackets.Text = "0";
            this.lbIncomingUnknownProtocolPackets.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(3, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(381, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Входящих пакетов с неизвестным протоколом";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbIncomingPacketsError
            // 
            this.lbIncomingPacketsError.AutoSize = true;
            this.lbIncomingPacketsError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbIncomingPacketsError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIncomingPacketsError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbIncomingPacketsError.Location = new System.Drawing.Point(390, 140);
            this.lbIncomingPacketsError.Name = "lbIncomingPacketsError";
            this.lbIncomingPacketsError.Size = new System.Drawing.Size(336, 20);
            this.lbIncomingPacketsError.TabIndex = 15;
            this.lbIncomingPacketsError.Text = "0";
            this.lbIncomingPacketsError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(3, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(381, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Входящих пакетов с ошибками";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbIncomingPacketDiscarded
            // 
            this.lbIncomingPacketDiscarded.AutoSize = true;
            this.lbIncomingPacketDiscarded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbIncomingPacketDiscarded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIncomingPacketDiscarded.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbIncomingPacketDiscarded.Location = new System.Drawing.Point(390, 120);
            this.lbIncomingPacketDiscarded.Name = "lbIncomingPacketDiscarded";
            this.lbIncomingPacketDiscarded.Size = new System.Drawing.Size(336, 20);
            this.lbIncomingPacketDiscarded.TabIndex = 13;
            this.lbIncomingPacketDiscarded.Text = "0";
            this.lbIncomingPacketDiscarded.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(381, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Сетевой интерфейс для приема многоадресных пакетов";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbSentMb
            // 
            this.lbSentMb.AutoSize = true;
            this.lbSentMb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSentMb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSentMb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSentMb.Location = new System.Drawing.Point(390, 80);
            this.lbSentMb.Name = "lbSentMb";
            this.lbSentMb.Size = new System.Drawing.Size(336, 20);
            this.lbSentMb.TabIndex = 9;
            this.lbSentMb.Text = "0";
            this.lbSentMb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbReciveMb
            // 
            this.lbReciveMb.AutoSize = true;
            this.lbReciveMb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbReciveMb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbReciveMb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbReciveMb.Location = new System.Drawing.Point(390, 60);
            this.lbReciveMb.Name = "lbReciveMb";
            this.lbReciveMb.Size = new System.Drawing.Size(336, 20);
            this.lbReciveMb.TabIndex = 8;
            this.lbReciveMb.Text = "0";
            this.lbReciveMb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbStatus.Location = new System.Drawing.Point(390, 40);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(336, 20);
            this.lbStatus.TabIndex = 7;
            this.lbStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbInterfaceType
            // 
            this.lbInterfaceType.AutoSize = true;
            this.lbInterfaceType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbInterfaceType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbInterfaceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbInterfaceType.Location = new System.Drawing.Point(390, 20);
            this.lbInterfaceType.Name = "lbInterfaceType";
            this.lbInterfaceType.Size = new System.Drawing.Size(336, 20);
            this.lbInterfaceType.TabIndex = 6;
            this.lbInterfaceType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSpeed
            // 
            this.lbSpeed.AutoSize = true;
            this.lbSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSpeed.Location = new System.Drawing.Point(390, 0);
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(336, 20);
            this.lbSpeed.TabIndex = 5;
            this.lbSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(381, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Скорость сетевого интерфейса";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(381, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Тип сетевого интерфейса";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(381, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Статус";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(381, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Входящий трафик";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(381, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Исходящий трафик";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbHasMulticast
            // 
            this.lbHasMulticast.AutoSize = true;
            this.lbHasMulticast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbHasMulticast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHasMulticast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbHasMulticast.Location = new System.Drawing.Point(390, 100);
            this.lbHasMulticast.Name = "lbHasMulticast";
            this.lbHasMulticast.Size = new System.Drawing.Size(336, 20);
            this.lbHasMulticast.TabIndex = 11;
            this.lbHasMulticast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(3, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(381, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Входящих пакетов отброшено";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(3, 240);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(381, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "Исходящих пакетов с ошибками";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.toolStripMenuItem1.Text = "Close";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 394);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Opacity = 0.7D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мониторинг трафика";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbInterfaces;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label Label1000;
        private System.Windows.Forms.Label lbOutgoingPacketsWithErrors;
        private System.Windows.Forms.Label lbOutgoingPacketsDiscarded;
        private System.Windows.Forms.Label lbNonUnicastPacketsSent;
        private System.Windows.Forms.Label lbNonUnicastPacketsReceived;
        private System.Windows.Forms.Label lbIncomingUnknownProtocolPackets;
        private System.Windows.Forms.Label lbIncomingPacketsError;
        private System.Windows.Forms.Label lbIncomingPacketDiscarded;
        private System.Windows.Forms.Label lbSentMb;
        private System.Windows.Forms.Label lbReciveMb;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lbInterfaceType;
        private System.Windows.Forms.Label lbSpeed;
        private System.Windows.Forms.Label lbHasMulticast;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbOutputQueueLength;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbUnicastPacketsReceived;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbUnicastPacketsSent;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbReciveAll;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbSentAll;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

