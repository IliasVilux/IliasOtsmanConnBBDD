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
using System.Xml.Linq;

namespace IliasOtsmanConnBBDD
{
    public partial class FormShowEmployees : Form
    {
        private SqlConnection conn;
        private List<Employee> employees;
        private List<Location> locations;

        private LinkToDDBBDataContext dc = new LinkToDDBBDataContext();
        public FormShowEmployees(SqlConnection conn)
        {
            InitializeComponent();
            //this.conn = conn;
            //employees = GetEmployees(null, null, null);
            //EmployeesListBox.Items.AddRange(employees.ToArray());
            //locations = GetLocations();
            //CitiesComboBox.Items.AddRange(locations.ToArray());

            GetEmployees2(null, null, null);
            GetLocations2();
        }

        private void GetEmployees2(string name, string surname, string city)
        {
            city = (city == "Todos") ? null : city;

            var data = from e in dc.employees
                        join d in dc.departments on e.department_id equals d.department_id
                        join l in dc.locations on d.location_id equals l.location_id
                        where (city == null || l.city == city) &&
                              (name == null || e.first_name.StartsWith(name)) &&
                              (surname == null || e.last_name.StartsWith(surname))
                        select e;

            foreach (employees emp in data)
            {
                EmployeesListBox.Items.Add(emp);
            }

        }

        private void GetLocations2()
        {
            CitiesComboBox.Items.Clear();
            var data = from l in dc.locations
                       select l;
            foreach (locations loc in data)
            {
                CitiesComboBox.Items.Add(loc);
            }
            CitiesComboBox.Items.Add("Todos");
            CitiesComboBox.SelectedItem = "Todos";
        }

        private void UpdateList2()
        {
            EmployeesListBox.Items.Clear();
            GetEmployees2(NombreTextBox.Text, ApellidoTextBox.Text, CitiesComboBox.Text);

            if (EmployeesListBox.Items.Count == 0)
                EmployeesListBox.Items.Add("No hay registros disponibles.");
        }

        private void NombreTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateList2();
            //UpdateList();
        }

        private void ApellidoTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateList2();
            //UpdateList();
        }

        private void CitiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateList2();
            //UpdateList();
        }

        private List<Employee> GetEmployees(string name, string surname, string city)
        {
            city = city == "Todos" ? null: city;
            List<Employee> employees = new List<Employee>();

            string query = "SELECT * FROM employees WHERE 1 = 1";

            if (!string.IsNullOrEmpty(city))
            {
                query = @"SELECT * FROM employees e
                          INNER JOIN departments d ON e.department_id = d.department_id
                          INNER JOIN locations l ON d.location_id = l.location_id
                          WHERE l.city = @city";

                if (!string.IsNullOrEmpty(name))
                    query += " AND first_name LIKE @inputName";

                if (!string.IsNullOrEmpty(surname))
                    query += " AND last_name LIKE @inputSurname";
            }

            if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(city))
                query += " AND first_name LIKE @inputName";

            if (!string.IsNullOrEmpty(surname) && string.IsNullOrEmpty(city))
                query += " AND last_name LIKE @inputSurname";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                if (!string.IsNullOrEmpty(city))
                    command.Parameters.AddWithValue("@city", city);

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

        private void UpdateList()
        {
            employees = GetEmployees(NombreTextBox.Text, ApellidoTextBox.Text, CitiesComboBox.Text);
            EmployeesListBox.Items.Clear();
            EmployeesListBox.Items.AddRange(employees.ToArray());
        }
    }

    public partial class employees
    {
        public override string ToString()
        {
            return $"{first_name} {last_name} - {email} - {phone_number}";
        }
    }

    public partial class locations
    {
        public override string ToString()
        {
            return city;
        }
    }
}
