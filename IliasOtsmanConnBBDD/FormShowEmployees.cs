using IliasOtsmanConnBBDD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IliasOtsmanConnBBDD
{
    public partial class FormShowEmployees : Form
    {
        SqlConnection conn;
        List<Employee> employees;
        List<Location> locations;
        public FormShowEmployees(SqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            employees = GetEmployees(null, null, null);
            EmployeesListBox.Items.AddRange(employees.ToArray());

            locations = GetLocations();
            CitiesComboBox.Items.Add("Todos");
            CitiesComboBox.Items.AddRange(locations.ToArray());
            CitiesComboBox.SelectedItem = "Todos";
        }

        private List<Employee> GetEmployees(string name, string surname, string city)
        {
            city = city == "Todos" ? null: city;
            List<Employee> employees = new List<Employee>();

            string query = "SELECT * FROM employees WHERE 1 = 1";

            if (!string.IsNullOrEmpty(city))
            {
                query = $@"SELECT * FROM employee e
                          INNER JOIN departments d ON e.department_id = d.department_id
                          INNER JOIN locations l ON location_id = location_id
                          WHERE city = {city}";

                if (!string.IsNullOrEmpty(name))
                    query += " AND first_name LIKE @inputName";

                if (!string.IsNullOrEmpty(surname))
                    query += " AND last_name LIKE @inputSurname";
            }

            if (!string.IsNullOrEmpty(name))
                query += " AND first_name LIKE @inputName";

            if (!string.IsNullOrEmpty(surname))
                query += " AND last_name LIKE @inputSurname";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                if (!string.IsNullOrEmpty(name))
                {
                    SqlParameter empName = new SqlParameter("@inputName", SqlDbType.VarChar, 20);
                    empName.Value = name + "%";
                    command.Parameters.Add(empName);
                }

                if (!string.IsNullOrEmpty(surname))
                {
                    SqlParameter empSurname = new SqlParameter("@inputSurname", SqlDbType.VarChar, 20);
                    empSurname.Value = surname + "%";
                    command.Parameters.Add(empSurname);
                }

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int? managerId, departmentId;

                    string empName, phone;

                    int employeeId = reader.GetInt32(0);

                    if (reader.IsDBNull(1))
                        empName = null;
                    else
                        empName = reader.GetString(1);

                    string empSurname = reader.GetString(2);
                    string email = reader.GetString(3);

                    if (reader.IsDBNull(4))
                        phone = null;
                    else
                        phone = reader.GetString(4);

                    DateTime hireDate = reader.GetDateTime(5);
                    decimal salary = reader.GetDecimal(7);
                    int jobId = reader.GetInt32(6);
                    if (reader.IsDBNull(8))
                        managerId = null;
                    else
                        managerId = reader.GetInt32(8);

                    if (reader.IsDBNull(9))
                        departmentId = null;
                    else
                        departmentId = reader.GetInt32(9);

                    Employee employee = new Employee(employeeId, empName, empSurname, email, phone, hireDate, salary, jobId, managerId, departmentId);
                    employees.Add(employee);
                }
                reader.Close();
            }

            return employees;
        }

        private List<Location> GetLocations()
        {
            List<Location> locations = new List<Location>();

            string query = "SELECT * FROM locations";

            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                string streetAdress, postalCode, stateProvince;

                int LocId = reader.GetInt32(0);
                if (reader.IsDBNull(1))
                    streetAdress = null;
                else
                    streetAdress = reader.GetString(1);
                if (reader.IsDBNull(2))
                    postalCode = null;
                else
                    postalCode = reader.GetString(2);

                string city = reader.GetString(3);

                if (reader.IsDBNull(4))
                    stateProvince = null;
                else
                    stateProvince = reader.GetString(4);
                string countryId = reader.GetString(5);

                Location location = new Location(LocId, streetAdress, postalCode, city, stateProvince, countryId);
                locations.Add(location);
            }
            reader.Close();

            return locations;
        }

        private void NombreTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void ApellidoTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void CitiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void UpdateList()
        {
            employees = GetEmployees(NombreTextBox.Text, ApellidoTextBox.Text, CitiesComboBox.Text);
            EmployeesListBox.Items.Clear();
            EmployeesListBox.Items.AddRange(employees.ToArray());
        }
    }
}
