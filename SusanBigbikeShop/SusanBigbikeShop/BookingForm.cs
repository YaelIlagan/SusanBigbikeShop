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
        public BookingForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.BookingForm_Load);
        }

        private void BookingForm_Load(object sender, EventArgs e)
        {
            LoadStaticData();
            LoadMechanics();
            LoadMotorcycleAutoComplete();
            LoadPlateNumberAutoComplete(); 
        }

        private void LoadStaticData()
        {
            cboxBookingServicetype.Items.Clear();
            cboxBookingServicetype.Items.AddRange(new string[] {
                "Oil Change",
                "Tune-Up",
                "Brake Pad Replacement",
                "Tire Replacement",
                "Engine Overhaul",
                "General Maintenance",
                "Electrical Diagnostics",
                "Change Chain and Sprocket",
                "Coolant Flush",
                "Valve Clearance"
            });

            cboxBookingHour.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                cboxBookingHour.Items.Add(i.ToString("00"));
            }

            cboxBookingMinutes.Items.Clear();
            cboxBookingMinutes.Items.AddRange(new string[] { "00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55" });

            cboxBookingAMPM.Items.Clear();
            cboxBookingAMPM.Items.AddRange(new string[] { "AM", "PM" });
        }

        private void LoadMechanics()
        {
            var mechanics = new[]
            {
                new { user_id = 1, full_name = "Justine" },
                new { user_id = 2, full_name = "Bobot" },
                new { user_id = 3, full_name = "Ian" },
                new { user_id = 4, full_name = "Susan" },
                new { user_id = 5, full_name = "Mark" },
                new { user_id = 6, full_name = "Jay" },
                new { user_id = 7, full_name = "Cris" },
                new { user_id = 8, full_name = "Alex" },
                new { user_id = 9, full_name = "Mike" },
                new { user_id = 10, full_name = "Tony" }
            };

            cboxBookingMechanic.DataSource = mechanics.ToList();
            cboxBookingMechanic.DisplayMember = "full_name";
            cboxBookingMechanic.ValueMember = "user_id";
            cboxBookingMechanic.SelectedIndex = -1;
        }

        private void LoadMotorcycleAutoComplete()
        {
            AutoCompleteStringCollection bikes = new AutoCompleteStringCollection();
            
            string[] baseModels = new string[] {
                "BMW R 1300 GS", "BMW R 1250 GS", "BMW S 1000 RR", "BMW M 1000 RR", "BMW R 1250 RT", "BMW K 1600 GTL", "BMW F 900 R",
                "Yamaha YZF-R1M", "Yamaha YZF-R1", "Yamaha YZF-R6", "Yamaha MT-10 SP", "Yamaha MT-09", "Yamaha Tracer 9 GT", "Yamaha Tenere 700",
                "Honda CBR1000RR-R Fireblade SP", "Honda CBR600RR", "Honda CB1000R", "Honda Africa Twin", "Honda X-ADV 750", "Honda Rebel 1100",
                "Kawasaki Ninja H2", "Kawasaki Ninja ZX-10R", "Kawasaki Ninja ZX-6R", "Kawasaki Z H2", "Kawasaki Z1000", "Kawasaki Versys 1000",
                "Ducati Panigale V4", "Ducati Streetfighter V4", "Ducati Multistrada V4", "Ducati Diavel V4", "Ducati DesertX", "Ducati Monster",
                "Suzuki Hayabusa", "Suzuki GSX-R1000R", "Suzuki Katana", "Suzuki V-Strom 1050", "Suzuki GSX-S1000",
                "KTM 1390 Super Duke R", "KTM 1290 Super Adventure", "KTM 890 Adventure R", "KTM 890 Duke R",
                "Triumph Rocket 3 R", "Triumph Tiger 1200", "Triumph Speed Triple 1200 RS", "Triumph Bonneville T120",
                "Harley-Davidson Pan America 1250", "Harley-Davidson Street Glide", "Harley-Davidson Fat Boy 114", "Harley-Davidson Breakout 117"
            };

            int currentYear = DateTime.Now.Year;
            for (int year = 2010; year <= currentYear + 1; year++) 
            {
                foreach (string model in baseModels)
                {
                    bikes.Add($"{year} {model}"); 
                }
            }

            bikes.AddRange(new string[] {
                "1998 Yamaha YZF-R1",
                "1999 Suzuki Hayabusa",
                "2004 Honda CBR1000RR"
            });

            txtBookingMotorcycle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBookingMotorcycle.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBookingMotorcycle.AutoCompleteCustomSource = bikes;
        }

        private void LoadPlateNumberAutoComplete()
        {
            AutoCompleteStringCollection plates = new AutoCompleteStringCollection();
            
            try
            {
                DBConnection db = new DBConnection();
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT plate_number FROM Motorcycle";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                plates.Add(reader["plate_number"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // We leave this catch block empty. 
            }

            txtBookingPlateNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBookingPlateNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtBookingPlateNumber.AutoCompleteCustomSource = plates;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void textBox5_TextChanged(object sender, EventArgs e) { }
        private void txtBookingCustomerID_TextChanged(object sender, EventArgs e) { }
        private void button11_Click(object sender, EventArgs e) { }

        private void btnSaveBooking_Click(object sender, EventArgs e)
        {
            try
            {
                int customerId = Convert.ToInt32(txtBookingCustomerID.Text);
                string plateNumber = txtBookingPlateNumber.Text;

                DateTime requestedDate = datetimepickerBookingbookingdate.Value.Date;

                string timeString = $"{cboxBookingHour.Text}:{cboxBookingMinutes.Text} {cboxBookingAMPM.Text}";
                TimeSpan preferredTime = DateTime.Parse(timeString).TimeOfDay;

                string serviceType = cboxBookingServicetype.Text;
                int mechanicId = Convert.ToInt32(cboxBookingMechanic.SelectedValue);

                DBConnection db = new DBConnection();

                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    int motorcycleId = 0;
                    string findBikeQuery = "SELECT motorcycle_id FROM Motorcycle WHERE plate_number = @PlateNo";

                    using (SqlCommand findCmd = new SqlCommand(findBikeQuery, conn))
                    {
                        findCmd.Parameters.AddWithValue("@PlateNo", plateNumber);
                        object bikeResult = findCmd.ExecuteScalar();

                        if (bikeResult != null)
                        {
                            motorcycleId = Convert.ToInt32(bikeResult);
                        }
                        else
                        {
                            MessageBox.Show("We couldn't find a motorcycle with that Plate Number in the system. Please register the motorcycle first!", "Motorcycle Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string query = @"INSERT INTO Booking 
                                (customer_id, motorcycle_id, requested_date, preferred_time, service_type, mechanic_id, status, notes) 
                                VALUES 
                                (@CustomerID, @MotorcycleID, @RequestedDate, @PreferredTime, @ServiceType, @MechanicID, 'Pending', @Notes)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerId);
                        cmd.Parameters.AddWithValue("@MotorcycleID", motorcycleId);
                        cmd.Parameters.AddWithValue("@RequestedDate", requestedDate);
                        cmd.Parameters.AddWithValue("@PreferredTime", preferredTime);
                        cmd.Parameters.AddWithValue("@ServiceType", serviceType);
                        cmd.Parameters.AddWithValue("@MechanicID", mechanicId);
                        cmd.Parameters.AddWithValue("@Notes", txtBookingNotes.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Booking saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please make sure all fields are filled out correctly (e.g., IDs must be numbers, time must be selected).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving booking: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtBookingbookingID.Clear();
            txtBookingCustomerID.Clear();
            txtBookingMotorcycle.Clear();
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
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtBookingCustomerID.Focus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text;
                DBConnection db = new DBConnection();

                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    b.booking_id AS [Booking ID], 
                    c.full_name AS [Customer Name], 
                    m.plate_number AS [Plate No], 
                    m.model AS [Motorcycle],
                    b.service_type AS [Service],
                    b.requested_date AS [Date], 
                    b.preferred_time AS [Time],
                    u.full_name AS [Mechanic],
                    b.status AS [Status],
                    b.notes AS [Notes]
                FROM Booking b
                INNER JOIN Customer c ON b.customer_id = c.customer_id
                INNER JOIN Motorcycle m ON b.motorcycle_id = m.motorcycle_id
                LEFT JOIN Users u ON b.mechanic_id = u.user_id
                WHERE c.full_name LIKE @SearchTerm OR m.plate_number LIKE @SearchTerm";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvBookings.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBookingNotes_TextChanged(object sender, EventArgs e)
        {
        }
    }
}