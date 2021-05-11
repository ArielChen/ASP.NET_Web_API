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
            string sql = "SELECT * FROM HR.Employees WHERE EmployeeID = " + id + "";

            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCmd = OpenDataBaseConnection(sqlConnection, sql);

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
            string sql = "INSERT INTO HR.Employees" +
                "(LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, Country, Phone, ManagerID, Gender, MonthlyPayment, YearlyPayment) " +
                "VALUES (@LastName, @FirstName, @Title, @TitleOfCourtesy, @BirthDate, @HireDate, @Address, @City, @Region, @Country, @Phone, @ManagerID, @Gender, null, null)";

            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCmd = OpenDataBaseConnection(sqlConnection, sql);

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
            string sql = "DELETE FROM HR.Employees WHERE EmployeeID = " + id + "";

            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCmd = OpenDataBaseConnection(sqlConnection, sql);

            int rowDeleted = sqlCmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public SqlCommand OpenDataBaseConnection(SqlConnection sqlConnection, string sql)
        {
            sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TSQL2012"].ConnectionString);
            SqlCommand sqlCmd = new SqlCommand(sql, sqlConnection);
            sqlConnection.Open();

            return sqlCmd;
        }
    }
}
