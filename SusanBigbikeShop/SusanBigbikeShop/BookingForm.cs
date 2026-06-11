using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SusanBigbikeShop
{
    public partial class BookingForm : Form
    {
        private int _selectedBookingId = -1;
        private string _currentUserRole;
        private int _currentUserId;

        public BookingForm()
        {
            InitializeComponent();

            _currentUserRole = UserSession.Role ?? "Owner";
            _currentUserId = UserSession.UserId;

            LoadStaticData();
            LoadMechanics();
            LoadMotorcycleAutoComplete();
            LoadBookings();
            GenerateBookingID();
        }


        private void LoadStaticData()
        {
            cboxBookingServicetype.Items.Clear();
            cboxBookingServicetype.Items.AddRange(new string[] {
                "Oil Change", "Tune-Up", "Brake Pad Replacement",
                "Tire Replacement", "Engine Overhaul", "General Maintenance",
                "Electrical Diagnostics", "Change Chain and Sprocket",
                "Coolant Flush", "Valve Clearance"
            });

            cboxBookingHour.Items.Clear();
            for (int i = 1; i <= 12; i++)
                cboxBookingHour.Items.Add(i.ToString("00"));

            cboxBookingMinutes.Items.Clear();
            cboxBookingMinutes.Items.AddRange(new string[] {
                "00", "05", "10", "15", "20", "25",
                "30", "35", "40", "45", "50", "55"
            });

            cboxBookingAMPM.Items.Clear();
            cboxBookingAMPM.Items.AddRange(new string[] { "AM", "PM" });

            comboBox6.Items.Clear();
            comboBox6.Items.Add("All Status");
            comboBox6.Items.Add("Pending");
            comboBox6.Items.Add("Confirmed");
            comboBox6.Items.Add("Cancelled");
            comboBox6.SelectedIndex = 0;
        }

        private void LoadMechanics()
        {
            try
            {
                using (SqlConnection conn = new DBConnection().GetConnection())
                {
                    conn.Open();
                    string query = "SELECT user_id, full_name FROM Users WHERE role = 'Staff' ORDER BY full_name";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var list = new System.Collections.Generic.List<dynamic>();
                        while (reader.Read())
                        {
                            list.Add(new
                            {
                                user_id = reader.GetInt32(0),
                                full_name = reader.GetString(1)
                            });
                        }
                        cboxBookingMechanic.DataSource = list;
                        cboxBookingMechanic.DisplayMember = "full_name";
                        cboxBookingMechanic.ValueMember = "user_id";
                        cboxBookingMechanic.SelectedIndex = -1;
                    }
                }
            }
            catch
            {
                cboxBookingMechanic.Items.Clear();
            }
        }

        private void LoadMotorcycleAutoComplete()
        {
            cboBoxModel.Items.Clear();

            string[] baseModels = new string[] {
                "BMW R 1300 GS", "BMW S 1000 RR", "BMW M 1000 RR",
                "Yamaha YZF-R1", "Yamaha YZF-R6", "Yamaha MT-10 SP", "Yamaha MT-09",
                "Honda CBR1000RR-R Fireblade SP", "Honda CBR600RR", "Honda Africa Twin",
                "Kawasaki Ninja H2", "Kawasaki Ninja ZX-10R", "Kawasaki Ninja ZX-6R",
                "Ducati Panigale V4", "Ducati Streetfighter V4", "Ducati Multistrada V4",
                "Suzuki Hayabusa", "Suzuki GSX-R1000R",
                "KTM 1390 Super Duke R", "KTM 1290 Super Adventure",
                "Triumph Rocket 3 R", "Triumph Speed Triple 1200 RS",
                "Harley-Davidson Pan America 1250", "Harley-Davidson Street Glide"
            };

            int currentYear = DateTime.Now.Year;
            for (int year = 2010; year <= currentYear + 1; year++)
                foreach (string model in baseModels)
                    cboBoxModel.Items.Add($"{year} {model}");

            cboBoxModel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboBoxModel.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void GenerateBookingID()
        {
            try
            {
                using (SqlConnection conn = new DBConnection().GetConnection())
                {
                    conn.Open();
                    string query = "SELECT ISNULL(MAX(booking_id), 0) + 1 FROM Booking";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int nextId = Convert.ToInt32(cmd.ExecuteScalar());
                        txtBookingbookingID.Text = $"BK-{nextId:D5}";
                    }
                }
            }
            catch
            {
                txtBookingbookingID.Text = "BK-00001";
            }
        }

        private void LoadBookings(string search = "", string status = "All Status")
        {
            dgvBookings.Rows.Clear();

            try
            {
                using (SqlConnection conn = new DBConnection().GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT
                        b.booking_id,
                        ISNULL(c.full_name, 'Unknown')       AS full_name,
                        ISNULL(m.plate_number, 'Unknown')    AS plate_number,
                        ISNULL(m.model, 'Unknown')           AS model,
                        b.service_type,
                        b.requested_date,
                        b.preferred_time,
                        ISNULL(u.full_name, 'Unassigned')    AS mechanic_name,
                        b.status,
                        ISNULL(b.notes, '')                  AS notes
                        FROM Booking b
                        LEFT JOIN Customer c   ON b.customer_id   = c.customer_id
                        LEFT JOIN Motorcycle m ON b.motorcycle_id = m.motorcycle_id
                        LEFT JOIN Users u      ON b.mechanic_id   = u.user_id
                        WHERE (@status = 'All Status' OR b.status = @status)
                            AND (
                            ISNULL(c.full_name, '')    LIKE @search
                        OR ISNULL(m.plate_number, '') LIKE @search
                        OR b.service_type             LIKE @search
                        )";

                    if (_currentUserRole == "Customer")
                    {
                        query += " AND c.user_id = @userId";
                    }

                    query += " ORDER BY b.requested_date DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                        if (_currentUserRole == "Customer")
                        {
                            cmd.Parameters.AddWithValue("@userId", _currentUserId);
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgvBookings.Rows.Add(
                                    reader["booking_id"].ToString(),
                                    reader["full_name"].ToString(),
                                    reader["plate_number"].ToString(),
                                    reader["model"].ToString(),
                                    reader["service_type"].ToString(),
                                    Convert.ToDateTime(reader["requested_date"]).ToString("MM/dd/yyyy"),
                                    reader["preferred_time"].ToString(),
                                    reader["mechanic_name"].ToString(),
                                    reader["status"].ToString(),
                                    reader["notes"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtBookingName.Text) ||
                string.IsNullOrWhiteSpace(txtBookingPlateNumber.Text) ||
                string.IsNullOrWhiteSpace(cboxBookingServicetype.Text) ||
                cboxBookingHour.SelectedIndex == -1 ||
                cboxBookingMinutes.SelectedIndex == -1 ||
                cboxBookingAMPM.SelectedIndex == -1 ||
                cboxBookingMechanic.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private string GetCurrentStatus()
        {
            foreach (DataGridViewRow row in dgvBookings.Rows)
            {
                if (row.Cells["ColBookingID"].Value?.ToString() == _selectedBookingId.ToString())
                    return row.Cells["ColStatus"].Value?.ToString() ?? "";
            }
            return "";
        }

        private bool IsDuplicateBooking(int motorcycleId, DateTime requestedDate, TimeSpan preferredTime, string serviceType, int excludeBookingId = -1)
        {
            bool isDuplicate = false;
            try
            {
                using (SqlConnection conn = new DBConnection().GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT COUNT(1) 
                FROM Booking 
                WHERE motorcycle_id = @motorcycleId 
                  AND requested_date = @requestedDate 
                  AND preferred_time = @preferredTime 
                  AND service_type = @serviceType
                  AND status != 'Cancelled'";

                    if (excludeBookingId != -1)
                    {
                        query += " AND booking_id != @excludeBookingId";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@motorcycleId", motorcycleId);
                        cmd.Parameters.AddWithValue("@requestedDate", requestedDate);
                        cmd.Parameters.AddWithValue("@preferredTime", preferredTime);
                        cmd.Parameters.AddWithValue("@serviceType", serviceType);

                        if (excludeBookingId != -1)
                        {
                            cmd.Parameters.AddWithValue("@excludeBookingId", excludeBookingId);
                        }

                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        isDuplicate = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking for duplicate booking: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return isDuplicate;
        }

        private void btnSaveBooking_Click(object sender, EventArgs e)
        {
            if (_selectedBookingId == -1)
            {
                MessageBox.Show("Please select a booking from the list to update.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentStatus = GetCurrentStatus();
            if (currentStatus == "Cancelled")
            {
                MessageBox.Show("This booking has been cancelled and cannot be updated.",
                    "Cancelled Booking", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm()) return;

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to update this booking?",
                "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                string plateNumber = txtBookingPlateNumber.Text.Trim();
                string customerName = txtBookingName.Text.Trim();
                DateTime requestedDate = datetimepickerBookingbookingdate.Value.Date;
                string timeString = $"{cboxBookingHour.Text}:{cboxBookingMinutes.Text} {cboxBookingAMPM.Text}";
                TimeSpan preferredTime = DateTime.Parse(timeString).TimeOfDay;
                string serviceType = cboxBookingServicetype.Text;
                int mechanicId = Convert.ToInt32(cboxBookingMechanic.SelectedValue);

                using (SqlConnection conn = new DBConnection().GetConnection())
                {
                    conn.Open();

                    int motorcycleId = 0;
                    int customerId = 0;

                    string findBikeQuery = "SELECT motorcycle_id, customer_id FROM Motorcycle WHERE plate_number = @PlateNo";
                    using (SqlCommand findCmd = new SqlCommand(findBikeQuery, conn))
                    {
                        findCmd.Parameters.AddWithValue("@PlateNo", plateNumber);
                        using (SqlDataReader reader = findCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                motorcycleId = Convert.ToInt32(reader["motorcycle_id"]);
                                customerId = reader["customer_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["customer_id"]);
                            }
                            else
                            {
                                MessageBox.Show("Motorcycle with that plate number not found.",
                                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    if (IsDuplicateBooking(motorcycleId, requestedDate, preferredTime, serviceType, _selectedBookingId))
                    {
                        MessageBox.Show("A booking with this motorcycle, date, time, and service type already exists.",
                                        "Duplicate Booking Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (customerId == 0)
                    {
                        string findCustomerQuery = "SELECT customer_id FROM Customer WHERE full_name = @name";
                        using (SqlCommand custCmd = new SqlCommand(findCustomerQuery, conn))
                        {
                            custCmd.Parameters.AddWithValue("@name", customerName);
                            object result = custCmd.ExecuteScalar();
                            if (result == null || result == DBNull.Value)
                            {
                                MessageBox.Show("Customer not found.",
                                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            customerId = Convert.ToInt32(result);
                        }
                    }

                    string updateCustomerName = "UPDATE Customer SET full_name = @name WHERE customer_id = @cid";
                    using (SqlCommand updCmd = new SqlCommand(updateCustomerName, conn))
                    {
                        updCmd.Parameters.AddWithValue("@name", customerName);
                        updCmd.Parameters.AddWithValue("@cid", customerId);
                        updCmd.ExecuteNonQuery();
                    }

                    string query = @"UPDATE Booking SET
                        customer_id    = @CustomerID,
                        motorcycle_id  = @MotorcycleID,
                        requested_date = @RequestedDate,
                        preferred_time = @PreferredTime,
                        service_type   = @ServiceType,
                        mechanic_id    = @MechanicID,
                        notes          = @Notes
                    WHERE booking_id = @BookingID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                        cmd.Parameters.AddWithValue("@MotorcycleID", motorcycleId);
                        cmd.Parameters.AddWithValue("@RequestedDate", requestedDate);
                        cmd.Parameters.AddWithValue("@PreferredTime", preferredTime);
                        cmd.Parameters.AddWithValue("@ServiceType", serviceType);
                        cmd.Parameters.AddWithValue("@MechanicID", mechanicId);
                        cmd.Parameters.AddWithValue("@Notes", txtBookingNotes.Text.Trim());
                        cmd.Parameters.AddWithValue("@BookingID", _selectedBookingId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Booking updated successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                LoadBookings();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please make sure all fields are filled out correctly.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating booking: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            _selectedBookingId = -1;

            cboBoxModel.SelectedIndex = -1;
            txtBookingName.Clear();
            txtBookingPhoneNumber.Clear();
            txtBookingEmail.Clear();
            txtBookingPlateNumber.Clear();
            txtBookingNotes.Clear();

            cboxBookingServicetype.SelectedIndex = -1;
            cboxBookingMechanic.SelectedIndex = -1;
            cboxBookingHour.SelectedIndex = -1;
            cboxBookingMinutes.SelectedIndex = -1;
            cboxBookingAMPM.SelectedIndex = -1;

            datetimepickerBookingbookingdate.Value = DateTime.Now;

            GenerateBookingID();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text == "Enter keyword..." ? "" : txtSearch.Text;
            LoadBookings(keyword, comboBox6.SelectedItem?.ToString() ?? "All Status");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnNewBooking_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBookingName.Text) ||
                string.IsNullOrWhiteSpace(txtBookingPlateNumber.Text) ||
                string.IsNullOrWhiteSpace(cboxBookingServicetype.Text) ||
                cboxBookingHour.SelectedIndex == -1 ||
                cboxBookingMinutes.SelectedIndex == -1 ||
                cboxBookingAMPM.SelectedIndex == -1 ||
                cboxBookingMechanic.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string plateNumber = txtBookingPlateNumber.Text.Trim();
                DateTime requestedDate = datetimepickerBookingbookingdate.Value.Date;

                string timeString = $"{cboxBookingHour.Text}:{cboxBookingMinutes.Text} {cboxBookingAMPM.Text}";
                TimeSpan preferredTime = DateTime.Parse(timeString).TimeOfDay;

                string serviceType = cboxBookingServicetype.Text;
                int mechanicId = Convert.ToInt32(cboxBookingMechanic.SelectedValue);

                using (SqlConnection conn = new DBConnection().GetConnection())
                {
                    conn.Open();

                    int motorcycleId = 0;
                    int customerId = 0;

                    string findBikeQuery = "SELECT motorcycle_id, customer_id FROM Motorcycle WHERE plate_number = @PlateNo";
                    using (SqlCommand findCmd = new SqlCommand(findBikeQuery, conn))
                    {
                        findCmd.Parameters.AddWithValue("@PlateNo", plateNumber);
                        using (SqlDataReader reader = findCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                motorcycleId = Convert.ToInt32(reader["motorcycle_id"]);
                                customerId = reader["customer_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["customer_id"]);
                            }
                        }
                    }

                    if (motorcycleId != 0 && IsDuplicateBooking(motorcycleId, requestedDate, preferredTime, serviceType))
                    {
                        MessageBox.Show("A booking with this motorcycle, date, time, and service type already exists.",
                                        "Duplicate Booking Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (motorcycleId == 0)
                    {
                        string findCustQuery = "SELECT customer_id FROM Customer WHERE full_name = @name";
                        using (SqlCommand custCmd = new SqlCommand(findCustQuery, conn))
                        {
                            custCmd.Parameters.AddWithValue("@name", txtBookingName.Text.Trim());
                            object result = custCmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                                customerId = Convert.ToInt32(result);
                        }

                        if (customerId == 0)
                        {
                            string insertCustQuery = @"INSERT INTO Customer (full_name, contact_number, user_id)
                                OUTPUT INSERTED.customer_id
                                VALUES (@name, @phone, @userId)";

                            using (SqlCommand insertCust = new SqlCommand(insertCustQuery, conn))
                            {
                                insertCust.Parameters.AddWithValue("@name", txtBookingName.Text.Trim());
                                insertCust.Parameters.AddWithValue("@phone", txtBookingPhoneNumber.Text.Trim());

                                if (_currentUserRole == "Customer" && _currentUserId != 0)
                                    insertCust.Parameters.AddWithValue("@userId", _currentUserId);
                                else
                                    insertCust.Parameters.AddWithValue("@userId", DBNull.Value);

                                customerId = (int)insertCust.ExecuteScalar();
                            }
                        }

                        string model = cboBoxModel.Text.Trim();
                        string insertBikeQuery = @"INSERT INTO Motorcycle (customer_id, make, model, plate_number)
                                OUTPUT INSERTED.motorcycle_id
                                VALUES (@custId, 'Unknown', @model, @plate)";
                        using (SqlCommand insertBike = new SqlCommand(insertBikeQuery, conn))
                        {
                            insertBike.Parameters.AddWithValue("@custId", customerId);
                            insertBike.Parameters.AddWithValue("@model", string.IsNullOrWhiteSpace(model) ? "Unknown" : model);
                            insertBike.Parameters.AddWithValue("@plate", plateNumber);
                            motorcycleId = (int)insertBike.ExecuteScalar();
                        }
                    }

                    if (customerId == 0)
                    {
                        string findCustFallback = "SELECT customer_id FROM Customer WHERE full_name = @name";
                        using (SqlCommand custCmd = new SqlCommand(findCustFallback, conn))
                        {
                            custCmd.Parameters.AddWithValue("@name", txtBookingName.Text.Trim());
                            object result = custCmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value)
                                customerId = Convert.ToInt32(result);
                            else
                            {
                                MessageBox.Show("Could not find or create customer record.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    string query = @"INSERT INTO Booking
                        (customer_id, motorcycle_id, requested_date, preferred_time,
                         service_type, mechanic_id, status, notes)
                        VALUES
                        (@CustomerID, @MotorcycleID, @RequestedDate, @PreferredTime,
                         @ServiceType, @MechanicID, 'Pending', @Notes)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                        cmd.Parameters.AddWithValue("@MotorcycleID", motorcycleId);
                        cmd.Parameters.AddWithValue("@RequestedDate", requestedDate);
                        cmd.Parameters.AddWithValue("@PreferredTime", preferredTime);
                        cmd.Parameters.AddWithValue("@ServiceType", serviceType);
                        cmd.Parameters.AddWithValue("@MechanicID", mechanicId);
                        cmd.Parameters.AddWithValue("@Notes", txtBookingNotes.Text.Trim());
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Booking saved successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadBookings();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please make sure all fields are filled out correctly.",
                    "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving booking: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvBookings.Rows[e.RowIndex];

            _selectedBookingId = int.Parse(row.Cells["ColBookingID"].Value.ToString());

            txtBookingbookingID.Text = "BK-" + _selectedBookingId.ToString("D5");
            txtBookingName.Text = row.Cells["ColCustomerName"].Value.ToString();
            txtBookingPlateNumber.Text = row.Cells["ColPlate"].Value.ToString();
            txtBookingNotes.Text = row.Cells["ColNotes"].Value.ToString();

            cboBoxModel.Text = row.Cells["ColMotorcycle"].Value.ToString();
            cboxBookingServicetype.Text = row.Cells["ColService"].Value.ToString();
            cboxBookingMechanic.Text = row.Cells["ColMechanic"].Value.ToString();

            if (DateTime.TryParse(row.Cells["ColDate"].Value.ToString(), out DateTime date))
                datetimepickerBookingbookingdate.Value = date;

            string timeVal = row.Cells["ColTime"].Value.ToString();
            if (TimeSpan.TryParse(timeVal, out TimeSpan ts))
            {
                int hour = ts.Hours;
                string ampm = hour >= 12 ? "PM" : "AM";
                hour = hour % 12;
                if (hour == 0) hour = 12;

                cboxBookingHour.Text = hour.ToString("00");
                cboxBookingMinutes.Text = ts.Minutes.ToString("00");
                cboxBookingAMPM.Text = ampm;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_selectedBookingId == -1)
            {
                MessageBox.Show("Please select a booking from the list to cancel.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentStatus = "";
            foreach (DataGridViewRow row in dgvBookings.Rows)
            {
                if (row.Cells["ColBookingID"].Value?.ToString() == _selectedBookingId.ToString())
                {
                    currentStatus = row.Cells["ColStatus"].Value?.ToString();
                    break;
                }
            }

            if (currentStatus == "Cancelled")
            {
                MessageBox.Show("This booking is already cancelled.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to cancel this booking?",
                "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new DBConnection().GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Booking SET status = 'Cancelled' WHERE booking_id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _selectedBookingId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Booking has been cancelled.",
                    "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadBookings(
                    txtSearch.Text == "Enter keyword..." ? "" : txtSearch.Text,
                    comboBox6.SelectedItem?.ToString() ?? "All Status");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling booking: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInProgress_Click(object sender, EventArgs e)
        {
            if (_selectedBookingId == -1)
            {
                MessageBox.Show("Please select a booking from the list.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentStatus = GetCurrentStatus();
            if (currentStatus == "Cancelled")
            {
                MessageBox.Show("This booking has been cancelled and cannot be updated.",
                    "Cancelled Booking", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentStatus == "Confirmed")
            {
                MessageBox.Show("This booking is already marked as Confirmed.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Mark this booking as Confirmed and send it to Repairs & Maintenance?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new DBConnection().GetConnection())
                {
                    conn.Open();

                    string updateQuery = "UPDATE Booking SET status = 'Confirmed' WHERE booking_id = @id";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _selectedBookingId);
                        cmd.ExecuteNonQuery();
                    }

                    string insertJoQuery = @"
                INSERT INTO JobOrder (customer_name, contact_number, motorcycle_model, plate_number, 
                                      parts_used, labor_cost, type, issue_description, 
                                      mechanic_id, motorcycle_id, status)
                SELECT 
                    ISNULL(c.full_name, 'Unknown'), 
                    ISNULL(c.contact_number, 'Unknown'), 
                    ISNULL(m.model, 'Unknown'), 
                    ISNULL(m.plate_number, 'Unknown'), 
                    'None yet', 
                    0.0, 
                    b.service_type, 
                    ISNULL(b.notes, 'No notes provided.'), 
                    b.mechanic_id, 
                    b.motorcycle_id, 
                    'Confirmed' -- The status it will start with in the Job Order grid
                FROM Booking b
                LEFT JOIN Customer c ON b.customer_id = c.customer_id
                LEFT JOIN Motorcycle m ON b.motorcycle_id = m.motorcycle_id
                WHERE b.booking_id = @id";

                    using (SqlCommand cmd = new SqlCommand(insertJoQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _selectedBookingId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Booking Confirmed! A Job Order has been sent to the Repairs list.",
                    "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadBookings(
                    txtSearch.Text == "Enter keyword..." ? "" : txtSearch.Text,
                    comboBox6.SelectedItem?.ToString() ?? "All Status");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text == "Enter keyword..." ? "" : txtSearch.Text;
            LoadBookings(keyword, comboBox6.SelectedItem?.ToString() ?? "All Status");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedBookingId == -1)
            {
                MessageBox.Show("Please select a booking from the list to delete.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to permanently delete this booking? This cannot be undone.",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new DBConnection().GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Booking WHERE booking_id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _selectedBookingId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Booking deleted successfully.",
                    "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadBookings(
                    txtSearch.Text == "Enter keyword..." ? "" : txtSearch.Text,
                    comboBox6.SelectedItem?.ToString() ?? "All Status");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting booking: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text == "Enter keyword..." ? "" : txtSearch.Text;
            LoadBookings(keyword, comboBox6.SelectedItem?.ToString() ?? "All Status");
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Enter keyword...")
                txtSearch.Text = "";
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                txtSearch.Text = "Enter keyword...";
        }
    }
}