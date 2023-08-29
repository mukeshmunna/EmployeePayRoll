using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    class Payroll_Operation
    {
        private SqlConnection con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog = payroll_service; integrated security = true");
        public PayrollEmployee AddEmployeeDetails(PayrollEmployee employee)
        {
            try
            {
                SqlCommand com = new SqlCommand("AddEmployeeDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@name", employee.name);
                com.Parameters.AddWithValue("@salary", employee.salary);
                com.Parameters.AddWithValue("@start_date", employee.start_date);
                com.Parameters.AddWithValue("@Gender", employee.gender);
                com.Parameters.AddWithValue("@phone", employee.phone);
                com.Parameters.AddWithValue("@Address", employee.address);
                com.Parameters.AddWithValue("@department", employee.department);
                com.Parameters.AddWithValue("@basic_pay", employee.basic_pay);
                com.Parameters.AddWithValue("@deductions", employee.deductions);
                com.Parameters.AddWithValue("@taxable_pay", employee.taxable_pay);
                com.Parameters.AddWithValue("@income_tax", employee.income_tax);
                com.Parameters.AddWithValue("@net_pay", employee.net_pay);
                con.Open();
                var i = com.ExecuteScalar();
                Console.WriteLine("Database Added");
                employee.id = Convert.ToInt32(i);
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void deletemployeeeDetails(int id)
        {
            try
            {
                SqlCommand com = new SqlCommand("DeleteEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@id", id);
                con.Open();
                int i = com.ExecuteNonQuery();
                Console.WriteLine("Database Deleted");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void UpdateEmployee(PayrollEmployee employee)
        {
            try
            {
                SqlCommand com = new SqlCommand("UpdateEmployeeDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", employee.id);
                com.Parameters.AddWithValue("@name", employee.name);
                com.Parameters.AddWithValue("@salary", employee.salary);
                com.Parameters.AddWithValue("@start_date", employee.start_date);
                com.Parameters.AddWithValue("@Gender", employee.gender);
                com.Parameters.AddWithValue("@phone", employee.phone);
                com.Parameters.AddWithValue("@Address", employee.address);
                com.Parameters.AddWithValue("@department", employee.department);
                com.Parameters.AddWithValue("@basic_pay", employee.basic_pay);
                com.Parameters.AddWithValue("@deductions", employee.deductions);
                com.Parameters.AddWithValue("@taxable_pay", employee.taxable_pay);
                com.Parameters.AddWithValue("@income_tax", employee.income_tax);
                com.Parameters.AddWithValue("@net_pay", employee.net_pay);
                con.Open();
                int i = com.ExecuteNonQuery();
                Console.WriteLine("DataBase Updated");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void GetAllEmployeeDetails()
        {
            List<PayrollEmployee> emplist = new List<PayrollEmployee>();
            SqlCommand com = new SqlCommand("GetEmployeeDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                emplist.Add(
                    new PayrollEmployee
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = Convert.ToString(dr["name"]),
                        salary = Convert.ToString(dr["salary"]),
                        start_date = Convert.ToString(dr["start_date"]),
                        gender = Convert.ToChar(dr["Gender"]),
                        phone = Convert.ToString(dr["phone"]),
                        address = Convert.ToString(dr["Address"]),
                        department = Convert.ToString(dr["department"]),
                        basic_pay = Convert.ToInt64(dr["basic_pay"]),
                        deductions = Convert.ToInt64(dr["deductions"]),
                        taxable_pay = Convert.ToInt64(dr["taxable_pay"]),
                        income_tax = Convert.ToInt64(dr["income_tax"]),
                        net_pay = Convert.ToInt64(dr["net_pay"]),
                    }
                    );
            }
            foreach (var data in emplist)
            {
                Console.WriteLine(data.name + " " + data.salary + " " + data.phone + " " + data.address + " " + data.department + " " + data.start_date);
            }
        }

    }
}