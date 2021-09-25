using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ServiceLayer;
using System.Globalization;

namespace EmployeeApps
{
    public interface IApiService
    {
        List<Employee> SearchEmployee(string name);
        bool AddUser(Employee employee);
        bool EditUser(Employee employee);
        bool DeleteUser(Employee employee);

        ObservableCollection<Employee> Employees { get; set; }
    }

    public class ApiService : IApiService
    {
       private ObservableCollection<Employee> _employees = new ObservableCollection<Employee>();
       private readonly  IService _service = new Service();

       public ApiService()
       {
           GetEmployee();
       }
        private void GetEmployee()
        {
            var res = _service.GetData();

            var list2 = ConvertToList(res);


            _employees = new ObservableCollection<Employee>(list2);
        }

        public List<Employee> SearchEmployee(string name)
        {
            var res = _service.GetSpecificData(name);
            var list2 = ConvertToList(res);

            return list2;

        }

        private static List<Employee> ConvertToList(IEnumerable<Datum> res)
        {
            return res.Select(a => new Employee() { ID = a.id, Name = a.name, Status = a.status, Gender = a.gender, Email = a.email }).ToList();
        }

        public bool AddUser(Employee employee)
        {
            var employeemodel = new EmployeeModel()
            {
                ID = employee.ID,
                Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(employee.Name.ToLowerInvariant()),
                Email = employee.Email,
                Status = employee.Status,
                Gender = employee.Gender
            };

            var res = _service.CreateUser(employeemodel);

            return res.Result;
        }


        public bool EditUser(Employee employee)
        {
            var employeemodel = new EmployeeModel()
            {
                ID = employee.ID,
                Name = employee.Name,
                Email = employee.Email,
                Status = employee.Status,
                Gender = employee.Gender
            };

            var res = _service.EditUser(employeemodel);

            return res.Result;
        }


        public bool DeleteUser(Employee employee)
        {
            var employeemodel = new EmployeeModel()
            {
                ID = employee.ID,
                Name = employee.Name,
                Email = employee.Email,
                Status = employee.Status,
                Gender = employee.Gender
            };

            var res = _service.DeleteUser(employeemodel);

            return res.Result;
        }

        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set => _employees = value;
        }
    }
}
