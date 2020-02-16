﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using curdMVC.Models;

namespace curdMVC.database_access_layer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public void Add_record(Employee emp)
        {
            SqlCommand com = new SqlCommand("sp_employee_Add", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name",emp.Name);
            com.Parameters.AddWithValue("@Address",emp.Address);
            com.Parameters.AddWithValue("@City",emp.City);
            com.Parameters.AddWithValue("@Pin_Code",emp.Pin_code);
            com.Parameters.AddWithValue("@Designation",emp.Designation);
            con.Open();
            com.ExecuteNonQuery();
            con.CreateCommand();
        }
        public void Update_record(Employee emp)
        {
            {
                SqlCommand com = new SqlCommand("sp_employee_update", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Emp_id", emp.empid);
                com.Parameters.AddWithValue("@Name", emp.Name);
                com.Parameters.AddWithValue("@Address", emp.Address);
                com.Parameters.AddWithValue("@City", emp.City);
                com.Parameters.AddWithValue("@Pin_Code", emp.Pin_code);
                com.Parameters.AddWithValue("@Designation", emp.Designation);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
            }

        }
        public DataSet Show_record_byid(int id)
        {
            SqlCommand com = new SqlCommand("sp_emp_id", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Emp_id", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
              
        }        
        public DataSet Show_data()
        {
            SqlCommand com = new SqlCommand("sp_emp_all", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
              
        }
        public void delete_record(int id)
        {
            SqlCommand com = new SqlCommand("tbl_emp_delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Emp_id", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

    }
}