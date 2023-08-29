using System;
using EmployeePayroll;
namespace ADODemo
{
    class Program
    {
        static void Main()
        {
            //Payroll employee Stored Proceudre
            PayrollEmployee employee = new PayrollEmployee()
            {
                id = 9,
                name = "Teressa",
                salary = "2000",
                start_date = "",
                gender = 'F',
                phone = "9898789898",
                address = "chennai",
                department = "Marketing",
                basic_pay = 300,
                deductions = 300,
                taxable_pay = 30,
                income_tax = 300,
                net_pay = 300,
            };
            Payroll_Operation payroll = new Payroll_Operation();
             payroll.AddEmployeeDetails(employee);
            payroll.deletemployeeeDetails(8);
              payroll.UpdateEmployee(employee);
              payroll.GetAllEmployeeDetails();
        }

    }
}
