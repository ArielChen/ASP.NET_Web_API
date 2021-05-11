using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_ADO.NET.Models;

namespace WebAPI_ADO.NET.Controllers
{
    public class EmployeesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public Employee Get(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSQL2012"].ConnectionString);
            string sql = "SELECT * FROM HR.Employees WHERE EmployeeID = " + id + "";
            SqlCommand sqlCmd = new SqlCommand(sql, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = null;
            reader = sqlCmd.ExecuteReader();

            Employee emp = null;
            while (reader.Read())
            {
                emp = new Employee();
                emp.EmployeeID = Convert.ToInt32(reader.GetValue(0));
                emp.LastName = reader.GetValue(1).ToString();
                emp.FirstName = reader.GetValue(2).ToString();
            }

            sqlConnection.Close();

            return emp;
        }

        // POST api/values
        public void Post(Employee emp)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSQL2012"].ConnectionString);
            string sql = "INSERT INTO HR.Employees" +
                "(LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, Country, Phone, ManagerID, Gender, MonthlyPayment, YearlyPayment) " +
                "VALUES (@LastName, @FirstName, @Title, @TitleOfCourtesy, @BirthDate, @HireDate, @Address, @City, @Region, @Country, @Phone, @ManagerID, @Gender, null, null)";
            SqlCommand sqlCmd = new SqlCommand(sql, sqlConnection);

            sqlCmd.Parameters.AddWithValue("@LastName", emp.LastName);
            sqlCmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            sqlCmd.Parameters.AddWithValue("@Title", emp.Title);
            sqlCmd.Parameters.AddWithValue("@TitleOfCourtesy", emp.TitleOfCourtesy);
            sqlCmd.Parameters.AddWithValue("@BirthDate", emp.BirthDate);
            sqlCmd.Parameters.AddWithValue("@HireDate", emp.HireDate);
            sqlCmd.Parameters.AddWithValue("@Address", emp.Address);
            sqlCmd.Parameters.AddWithValue("@City", emp.City);
            sqlCmd.Parameters.AddWithValue("@Region", emp.Region);
            sqlCmd.Parameters.AddWithValue("@Country", emp.Country);
            sqlCmd.Parameters.AddWithValue("@Phone", emp.Phone);
            sqlCmd.Parameters.AddWithValue("@ManagerID", emp.ManagerID);
            sqlCmd.Parameters.AddWithValue("@Gender", emp.Gender);
            sqlCmd.Parameters.AddWithValue("@MonthlyPayment", emp.MonthlyPayment);
            sqlCmd.Parameters.AddWithValue("@YearlyPayment", emp.YearlyPayment);

            sqlConnection.Open();
            int rowInserted = sqlCmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSQL2012"].ConnectionString);
            string sql = "DELETE FROM HR.Employees WHERE EmployeeID = " + id + "";

            SqlCommand sqlCmd = new SqlCommand(sql, sqlConnection);

            sqlConnection.Open();
            int rowDeleted = sqlCmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
