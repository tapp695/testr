namespace mareshell
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpVehicleEntry = new GroupBox();
            lblLicensePlate = new Label();
            txtLicensePlate = new TextBox();
            lblVehicleType = new Label();
            cmbVehicleType = new ComboBox();
            btnPark = new Button();
            btnRemove = new Button();
            lblAvailableSpots = new Label();
            grpParkingStatus = new GroupBox();
            lvwParkingStatus = new ListView();
            SuspendLayout();
            // 
            // grpVehicleEntry
            // 
            grpVehicleEntry.Location = new Point(12, 74);
            grpVehicleEntry.Name = "grpVehicleEntry";
            grpVehicleEntry.Size = new Size(247, 104);
            grpVehicleEntry.TabIndex = 0;
            grpVehicleEntry.TabStop = false;
            grpVehicleEntry.Text = "grpVehicleEntry";
            // 
            // lblLicensePlate
            // 
            lblLicensePlate.AutoSize = true;
            lblLicensePlate.Location = new Point(27, 38);
            lblLicensePlate.Name = "lblLicensePlate";
            lblLicensePlate.Size = new Size(85, 15);
            lblLicensePlate.TabIndex = 1;
            lblLicensePlate.Text = "lblLicensePlate";
            // 
            // txtLicensePlate
            // 
            txtLicensePlate.Location = new Point(12, 256);
            txtLicensePlate.Name = "txtLicensePlate";
            txtLicensePlate.Size = new Size(100, 23);
            txtLicensePlate.TabIndex = 2;
            // 
            // lblVehicleType
            // 
            lblVehicleType.AutoSize = true;
            lblVehicleType.Location = new Point(12, 226);
            lblVehicleType.Name = "lblVehicleType";
            lblVehicleType.Size = new Size(81, 15);
            lblVehicleType.TabIndex = 3;
            lblVehicleType.Text = "lblVehicleType";
            // 
            // cmbVehicleType
            // 
            cmbVehicleType.FormattingEnabled = true;
            cmbVehicleType.Location = new Point(12, 313);
            cmbVehicleType.Name = "cmbVehicleType";
            cmbVehicleType.Size = new Size(121, 23);
            cmbVehicleType.TabIndex = 4;
            // 
            // btnPark
            // 
            btnPark.Location = new Point(30, 377);
            btnPark.Name = "btnPark";
            btnPark.Size = new Size(75, 23);
            btnPark.TabIndex = 5;
            btnPark.Text = "btnPark";
            btnPark.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(46, 431);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 6;
            btnRemove.Text = "btnRemove";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // lblAvailableSpots
            // 
            lblAvailableSpots.AutoSize = true;
            lblAvailableSpots.Location = new Point(389, 82);
            lblAvailableSpots.Name = "lblAvailableSpots";
            lblAvailableSpots.Size = new Size(97, 15);
            lblAvailableSpots.TabIndex = 7;
            lblAvailableSpots.Text = "lblAvailableSpots";
            // 
            // grpParkingStatus
            // 
            grpParkingStatus.Location = new Point(397, 168);
            grpParkingStatus.Name = "grpParkingStatus";
            grpParkingStatus.Size = new Size(200, 100);
            grpParkingStatus.TabIndex = 8;
            grpParkingStatus.TabStop = false;
            grpParkingStatus.Text = "grpParkingStatus";
            // 
            // lvwParkingStatus
            // 
            lvwParkingStatus.Location = new Point(411, 328);
            lvwParkingStatus.Name = "lvwParkingStatus";
            lvwParkingStatus.Size = new Size(121, 97);
            lvwParkingStatus.TabIndex = 9;
            lvwParkingStatus.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1394, 630);
            Controls.Add(lvwParkingStatus);
            Controls.Add(grpParkingStatus);
            Controls.Add(lblAvailableSpots);
            Controls.Add(btnRemove);
            Controls.Add(btnPark);
            Controls.Add(cmbVehicleType);
            Controls.Add(lblVehicleType);
            Controls.Add(txtLicensePlate);
            Controls.Add(lblLicensePlate);
            Controls.Add(grpVehicleEntry);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpVehicleEntry;
        private Label lblLicensePlate;
        private TextBox txtLicensePlate;
        private Label lblVehicleType;
        private ComboBox cmbVehicleType;
        private Button btnPark;
        private Button btnRemove;
        private Label lblAvailableSpots;
        private GroupBox grpParkingStatus;
        private ListView lvwParkingStatus;
    }
}
