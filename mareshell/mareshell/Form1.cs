namespace mareshell
{
    public partial class Form1 : Form
    {

        private ParkingLot parkingLot; // Declare at class level


        public Form1()
        {
            InitializeComponent();
              parkingLot = new ParkingLot(10, 5); // 10 car spots, 5 motorcycle spots
            UpdateParkingStatus();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void InitializeComponents()
        {
            this.Size = new Size(800, 600);
            this.Text = "Parking Lot Management System";

            // Group Box for Vehicle Entry
            grpVehicleEntry = new GroupBox();
            grpVehicleEntry.Text = "Vehicle Entry";
            grpVehicleEntry.Location = new Point(20, 20);
            grpVehicleEntry.Size = new Size(740, 100);

            // License Plate Input
            Label lblLicensePlate = new Label();
            lblLicensePlate.Text = "License Plate:";
            lblLicensePlate.Location = new Point(20, 30);
            lblLicensePlate.AutoSize = true;
            txtLicensePlate = new TextBox();
            txtLicensePlate.Location = new Point(120, 27);
            txtLicensePlate.Size = new Size(150, 20);

            // Vehicle Type Dropdown
            Label lblVehicleType = new Label();
            lblVehicleType.Text = "Vehicle Type:";
            lblVehicleType.Location = new Point(300, 30);
            lblVehicleType.AutoSize = true;
            cmbVehicleType = new ComboBox();
            cmbVehicleType.Location = new Point(400, 27);
            cmbVehicleType.Size = new Size(150, 20);
            cmbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVehicleType.Items.AddRange(new string[] { "Car", "Motorcycle" });
            cmbVehicleType.SelectedIndex = 0;

            // Buttons
            btnPark = new Button();
            btnPark.Text = "Park Vehicle";
            btnPark.Location = new Point(580, 25);
            btnPark.Size = new Size(120, 30);
            btnPark.Click += btnPark_Click;
             void btnRemove_Click(object sender, EventArgs e)
            {
                // Your code logic
            }
            btnRemove = new Button();
            btnRemove.Text = "Remove Vehicle";
            btnRemove.Location = new Point(580, 60);
            btnRemove.Size = new Size(120, 30);
            btnRemove.Click += btnRemove_Click;

            // Available Spots Label
            lblAvailableSpots = new Label();
            lblAvailableSpots.Location = new Point(20, 60);
            lblAvailableSpots.AutoSize = true;

            // Parking Status ListView
            grpParkingStatus = new GroupBox();
            grpParkingStatus.Text = "Parking Status";
            grpParkingStatus.Location = new Point(20, 140);
            grpParkingStatus.Size = new Size(740, 400);
            lvwParkingStatus = new ListView();
            lvwParkingStatus.Location = new Point(20, 20);
            lvwParkingStatus.Size = new Size(700, 360);
            lvwParkingStatus.View = View.Details;
            lvwParkingStatus.FullRowSelect = true;
            lvwParkingStatus.GridLines = true;
            lvwParkingStatus.Columns.Add("Spot", 70);
            lvwParkingStatus.Columns.Add("Type", 100);
            lvwParkingStatus.Columns.Add("Status", 100);
            lvwParkingStatus.Columns.Add("License Plate", 120);
            lvwParkingStatus.Columns.Add("Entry Time", 150);

            // Add controls to group boxes
            grpVehicleEntry.Controls.AddRange(new Control[] {
                lblLicensePlate, txtLicensePlate, lblVehicleType, cmbVehicleType, btnPark, btnRemove, lblAvailableSpots
            });
            grpParkingStatus.Controls.Add(lvwParkingStatus);

            // Add group boxes to form
            this.Controls.AddRange(new Control[] { grpVehicleEntry, grpParkingStatus });
        }

        private void btnPark_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLicensePlate.Text))
            {
                MessageBox.Show("Please enter a license plate number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Vehicle vehicle = new Vehicle(txtLicensePlate.Text, cmbVehicleType.SelectedItem.ToString());
            if (parkingLot.ParkVehicle(vehicle))
            {
                MessageBox.Show("Vehicle parked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateParkingStatus();
            }
            else
            {
                MessageBox.Show("No available parking spots for this vehicle type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            void btnRemove_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(txtLicensePlate.Text))
                {
                    MessageBox.Show("Please enter a license plate number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Vehicle vehicle = parkingLot.RemoveVehicle(txtLicensePlate.Text); // Remove the vehicle by its license plate
                if (vehicle != null)
                {
                    TimeSpan duration = DateTime.Now - vehicle.EntryTime;  // Calculate parking duration
                    decimal fee = CalculateParkingFee(duration);  // Calculate parking fee
                    MessageBox.Show($"Vehicle removed.\nParking duration: {duration.Hours}h {duration.Minutes}m\nParking fee: ${fee:F2}",
                        "Vehicle Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateParkingStatus();  // Refresh parking status
                }
                else
                {
                    MessageBox.Show("Vehicle not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            decimal CalculateParkingFee(TimeSpan duration)
            {
                decimal hourlyRate = 2.0m;
                return (decimal)Math.Ceiling(duration.TotalHours) * hourlyRate;
            }


            var spots = parkingLot.GetParkingStatus();  // Get the current parking spots status
            int availableCar = spots.Count(s => s.VehicleType == "Car" && !s.IsOccupied);
            int availableMoto = spots.Count(s => s.VehicleType == "Motorcycle" && !s.IsOccupied);

            lblAvailableSpots.Text = $"Available Spots - Cars: {availableCar}, Motorcycles: {availableMoto}";
        }
             void UpdateParkingStatus()
            {
                lvwParkingStatus.Items.Clear();  // Clears the list view for new data

                var spots = parkingLot.GetParkingStatus(); // Get the current parking spots status
                foreach (var spot in spots)
                {
                    var item = new ListViewItem(spot.SpotNumber.ToString());  // Creates a new item for each spot
                    item.SubItems.Add(spot.VehicleType);  // Adds vehicle type (Car or Motorcycle)
                    item.SubItems.Add(spot.IsOccupied ? "Occupied" : "Available"); // Updates spot status

                    if (spot.IsOccupied)
                    {
                        var vehicle = parkingLot.GetVehicleBySpot(spot.SpotNumber);  // Get vehicle if occupied
                        if (vehicle != null)
                        {
                            item.SubItems.Add(vehicle.LicensePlate);  // Add license plate if occupied
                            item.SubItems.Add(vehicle.EntryTime.ToString("g"));  // Add entry time
                        }
                    }
                    else
                    {
                        item.SubItems.Add("-");  // Placeholder if the spot is empty
                        item.SubItems.Add("-");  // Placeholder for entry time if the spot is empty
                    }

                // Your snippet to calculate available spots:
                int availableCar = spots.Count(s => s.VehicleType == "Car" && !s.IsOccupied); // Count available car spots
                int availableMoto = spots.Count(s => s.VehicleType == "Motorcycle" && !s.IsOccupied); // Count available motorcycle spots

                // Update the label with available spots
                lblAvailableSpots.Text = $"Available Spots - Cars: {availableCar}, Motorcycles: {availableMoto}";
            }
        


            }

        }
    }


