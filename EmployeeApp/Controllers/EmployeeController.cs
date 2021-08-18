using EmployeeApp.init;
using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        Employee _employee = new Employee();
        List<Employee> _employees = new List<Employee>();

        public EmployeeController()
        {
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPlicyErrors) => { return true; };
        }


        //GET-Employees From API
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _employees = new List<Employee>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44373/api/employee"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _employees = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
                }
            }
            return View(_employees);
        }

        //GET-Employee by id
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            _employee = new Employee();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44373/api/employee/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _employee = JsonConvert.DeserializeObject<Employee>(apiResponse);
                }
            }

            return View(_employee);
        }

        //View Create Employee
        public IActionResult Create()
        {
            return View();
        }

        //Post data to Api
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            _employee = new Employee();
            employee.Id = new Guid();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employee),Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44373/api/Employee/" ,content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _employee = JsonConvert.DeserializeObject<Employee>(apiResponse);
                }
            }

            return RedirectToAction("Index");
        }


        //Delete View
        public async Task<IActionResult> Delete(Guid id)
        {
            _employee = new Employee();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44373/api/employee/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _employee = JsonConvert.DeserializeObject<Employee>(apiResponse);
                }
            }

            return View(_employee);
        }

        //DELETE Employee from Api
        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            string message = "";

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44373/api/Employee/" + id))
                {
                   message = await response.Content.ReadAsStringAsync();
                   
                }
            }

            return RedirectToAction("Index");
        }


        //Delete View
        public async Task<IActionResult> Edit(Guid id)
        {
            _employee = new Employee();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:44373/api/employee/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _employee = JsonConvert.DeserializeObject<Employee>(apiResponse);
                }
            }

            return View(_employee);
        }


        //EDIT Employee
        [HttpPost]
        public async Task<IActionResult> Update(Employee employee)
        {
            _employee = new Employee();
            var id = employee.Id;

            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PatchAsync("https://localhost:44373/api/Employee/"+id, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _employee = JsonConvert.DeserializeObject<Employee>(apiResponse);
                }
            }

            return RedirectToAction("Index");
        }

    }
}
