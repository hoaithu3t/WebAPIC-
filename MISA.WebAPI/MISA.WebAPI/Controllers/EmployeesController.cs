using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.WebAPI.Modal;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        string connectionString = "User Id=nvmanh;Host=103.124.92.43;port=3306;password=12345678;Database=MS03_09_NTTHIEM_CukCuk;Character Set=utf8";
        // GET: api/<EmployeesController> lấy hết nhân viên
        [HttpGet]
        public List<Employee> Get()
        {
            //return new string[] { "value1", "value2" };
            List<Employee> employees = new List<Employee>();
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                //lấy dữ liệu
                employees = dbConnection.Query<Employee>("Select * From Employee").ToList();
            }
            return employees;

    }

        // GET api/<EmployeesController>/5  lấy nhân viên theo ID
        [HttpGet("{id}")]
        public Employee Get(Guid id)
        {
            Employee employee = new Employee();
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                //lấy dữ liệu
                var sqlQuery = $"Select * From Employee Where CustomerId = '{id.ToString()}'";
                employee = dbConnection.Query<Employee>(sqlQuery).FirstOrDefault();
            }
            return employee;
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            var param = new
            {
                EmployeeId = "",
                EmployeeCode = employee.EmployeeCode,
                FullName = employee.FullNamme,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                IdentifyNumber = employee.IdentityNumber,
                IdentityDate = employee.IdentityDate,
                IdentityPlace = employee.IdentityPlace,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                PositionId = employee.PositionId,
                DepartmentId = employee.DepartmentId,
                TaxCode = employee.TaxCode,
                Salary = employee.Salary,
                JoinDate = employee.JoinDate,
                Status = employee.WordStatusId,
            };
            // Lấy dữ liệu:
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var affectedRows = dbConnection.Execute($"Proc_InsertEmployee", param, commandType: CommandType.StoredProcedure);
            if (affectedRows > 0)
            {
                return CreatedAtAction("POST", affectedRows);
            }            
            return NoContent();
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {
            var sqlQuery = $"Proc_UpdateEmployee";
            var param = new
            {
                EmployeeId = id.ToString(),
                EmployeeCode = employee.EmployeeCode,
                FullName = employee.FullNamme,
                DateOfBirth = employee.DateOfBirth,
                Gender = employee.Gender,
                IdentifyNumber = employee.IdentityNumber,
                IdentityDate = employee.IdentityDate,
                IdentityPlace = employee.IdentityPlace,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                PositionId = employee.PositionId,
                DepartmentId = employee.DepartmentId,
                TaxCode = employee.TaxCode,
                Salary = employee.Salary,
                JoinDate = employee.JoinDate,
                Status = employee.WordStatusId,
            };
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var affectedRows = dbConnection.Execute(sqlQuery, param, commandType: CommandType.StoredProcedure);
            if (affectedRows > 0)
            {
                return CreatedAtAction("POST", affectedRows);
            }
            return NoContent();
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var sqlQuery = $"Proc_DeleteEmployee";
            dbConnection.Query(sqlQuery, new { EmployeeId = id.ToString() }, commandType: CommandType.StoredProcedure);
            return Ok();
        }
    }
}
