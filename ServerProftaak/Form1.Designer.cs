namespace SmartParkingGarage.ServerProftaak
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
            this.carList = new System.Windows.Forms.ListBox();
            this.btnAddDummyCars = new System.Windows.Forms.Button();
            this.Parkingspots = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddParkingspot = new System.Windows.Forms.Button();
            this.buttonAddCarToParkingLot = new System.Windows.Forms.Button();
            this.lbFreeSpots = new System.Windows.Forms.ListBox();
            this.btnShowFreeSpots = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // carList
            // 
            this.carList.FormattingEnabled = true;
            this.carList.Location = new System.Drawing.Point(12, 96);
            this.carList.Name = "carList";
            this.carList.Size = new System.Drawing.Size(344, 199);
            this.carList.TabIndex = 0;
            // 
            // btnAddDummyCars
            // 
            this.btnAddDummyCars.Location = new System.Drawing.Point(13, 12);
            this.btnAddDummyCars.Name = "btnAddDummyCars";
            this.btnAddDummyCars.Size = new System.Drawing.Size(75, 23);
            this.btnAddDummyCars.TabIndex = 1;
            this.btnAddDummyCars.Text = "Add cars";
            this.btnAddDummyCars.UseVisualStyleBackColor = true;
            this.btnAddDummyCars.Click += new System.EventHandler(this.btnAddDummyCars_Click);
            // 
            // Parkingspots
            // 
            this.Parkingspots.FormattingEnabled = true;
            this.Parkingspots.Location = new System.Drawing.Point(370, 96);
            this.Parkingspots.Name = "Parkingspots";
            this.Parkingspots.Size = new System.Drawing.Size(352, 199);
            this.Parkingspots.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cars:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Parking spots:";
            // 
            // btnAddParkingspot
            // 
            this.btnAddParkingspot.Location = new System.Drawing.Point(370, 12);
            this.btnAddParkingspot.Name = "btnAddParkingspot";
            this.btnAddParkingspot.Size = new System.Drawing.Size(111, 23);
            this.btnAddParkingspot.TabIndex = 6;
            this.btnAddParkingspot.Text = "Add parking spots";
            this.btnAddParkingspot.UseVisualStyleBackColor = true;
            this.btnAddParkingspot.Click += new System.EventHandler(this.btnAddParkingspot_Click);
            // 
            // buttonAddCarToParkingLot
            // 
            this.buttonAddCarToParkingLot.Location = new System.Drawing.Point(13, 45);
            this.buttonAddCarToParkingLot.Name = "buttonAddCarToParkingLot";
            this.buttonAddCarToParkingLot.Size = new System.Drawing.Size(206, 23);
            this.buttonAddCarToParkingLot.TabIndex = 7;
            this.buttonAddCarToParkingLot.Text = "Add a car to a parking lot";
            this.buttonAddCarToParkingLot.UseVisualStyleBackColor = true;
            this.buttonAddCarToParkingLot.Click += new System.EventHandler(this.buttonAddCarToParkingLot_Click);
            // 
            // lbFreeSpots
            // 
            this.lbFreeSpots.FormattingEnabled = true;
            this.lbFreeSpots.Location = new System.Drawing.Point(738, 96);
            this.lbFreeSpots.Name = "lbFreeSpots";
            this.lbFreeSpots.Size = new System.Drawing.Size(352, 199);
            this.lbFreeSpots.TabIndex = 8;
            // 
            // btnShowFreeSpots
            // 
            this.btnShowFreeSpots.Location = new System.Drawing.Point(738, 12);
            this.btnShowFreeSpots.Name = "btnShowFreeSpots";
            this.btnShowFreeSpots.Size = new System.Drawing.Size(91, 23);
            this.btnShowFreeSpots.TabIndex = 9;
            this.btnShowFreeSpots.Text = "Show free spots";
            this.btnShowFreeSpots.UseVisualStyleBackColor = true;
            this.btnShowFreeSpots.Click += new System.EventHandler(this.btnShowFreeSpots_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(735, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Free parking spots:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 306);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnShowFreeSpots);
            this.Controls.Add(this.lbFreeSpots);
            this.Controls.Add(this.buttonAddCarToParkingLot);
            this.Controls.Add(this.btnAddParkingspot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Parkingspots);
            this.Controls.Add(this.btnAddDummyCars);
            this.Controls.Add(this.carList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox carList;
        private System.Windows.Forms.Button btnAddDummyCars;
        private System.Windows.Forms.ListBox Parkingspots;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddParkingspot;
        private System.Windows.Forms.Button buttonAddCarToParkingLot;
        private System.Windows.Forms.ListBox lbFreeSpots;
        private System.Windows.Forms.Button btnShowFreeSpots;
        private System.Windows.Forms.Label label3;
    }
}

