using ConnectedArchitectureExamples.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace ConnectedArchitectureExamples.Dal
{
    public class CustomerDal
    {
        private object employee1;

        public List<Employee1> GetAllCustomers()
        {
            using (MySqlConnection CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["InfowayPoDbConStr"].ConnectionString))
            {
                using (MySqlCommand CMD = new MySqlCommand())
                {
                    CN.Open();
                    CMD.Connection = CN;
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.CommandText = "GetAllData";
                    MySqlDataReader DR = CMD.ExecuteReader();
                    List<Employee1> employee1 = new List<Employee1>();
                    while (DR.Read())
                    {
                        employee1.Add(new Employee1()
                        {
                            EmployeeId = Convert.ToInt32(DR["EmployeeId"]),
                            EmployeeName = Convert.ToString(DR["EmployeeName"]),
                            EmployeeCity = Convert.ToString(DR["EmployeeCity"])
                        });
                    }
                    DR.Close();
                    CN.Close();
                    return employee1;
                }
            }
        }
        public int InsertCustomer(Employee1 customer)
        {
            using (MySqlConnection CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["InfowayPoDbConStr"].ConnectionString))
            {
                using (MySqlCommand CMD = new MySqlCommand())
                {
                    CN.Open();
                    CMD.Connection = CN;
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.CommandText = "InsertData";
                    CMD.Parameters.AddWithValue("p_EmployeeId", employee1.EmployeeId);
                    CMD.Parameters.AddWithValue("p_EmployeeName",employee1.EmployeeName);
                    _ = CMD.Parameters.AddWithValue("p_EmployeeCity",employee1.EmployeeCity);
                    int result = CMD.ExecuteNonQuery();
                    return result;
                }
            }
        }
        public int UpdateCustomer(Employee1 employee1)
        {
            using (MySqlConnection CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["InfowayPoDbConStr"].ConnectionString))
            {
                using (MySqlCommand CMD = new MySqlCommand())
                {
                    CN.Open();
                    CMD.Connection = CN;
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.CommandText = "UpdateCustomer";
                    CMD.Parameters.AddWithValue("p_EmployeeId", employee1.EmployeeId);
                    CMD.Parameters.AddWithValue("p_EmployeeName",employee1.EmployeeName);
                    CMD.Parameters.AddWithValue("p_EmployeeCity", employee1.EmployeeCity);
                    int result = CMD.ExecuteNonQuery();
                    return result;
                }
            }
        }
        public int DeleteCustomer(Customer customer)
        {
            using (MySqlConnection CN = new MySqlConnection(ConfigurationManager.ConnectionStrings["InfowayPoDbConStr"].ConnectionString))
            {
                using (MySqlCommand CMD = new MySqlCommand())
                {
                    CN.Open();
                    CMD.Connection = CN;
                    CMD.CommandType = CommandType.StoredProcedure;
                    CMD.CommandText = "DeleteCustomer";
                    CMD.Parameters.AddWithValue("p_CustomerId", customer.CustomerId);
                    int result = CMD.ExecuteNonQuery();
                    return result;
                }
            }
        }
    }
}
