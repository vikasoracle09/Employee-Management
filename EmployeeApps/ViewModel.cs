using System.Collections.ObjectModel;

namespace EmployeeApps
{
    public class ViewModel
    {
        private readonly IApiService _service;

        public ViewModel()
        {
            ListEmployees = new ObservableCollection<Employee>();
            _service = new ApiService();
            ListEmployees = _service.Employees;
        }

        public ObservableCollection<Employee> ListEmployees { get; set; }

        /// <summary>
        /// Create New user
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool AddUserToList(Employee employee)
        {
            var data = _service.AddUser(employee);
            return data;
        }

        /// <summary>
        /// Update existing user
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool EditUserToList(Employee employee)
        {
            var data = _service.EditUser(employee);
            return data;
        }


        /// <summary>
        /// Delete Existing user
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool DeleteUserToList(Employee employee)
        {
            var data = _service.DeleteUser(employee);
            return data;
        }

        /// <summary>
        /// Search User based on Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ObservableCollection<Employee> SearchUserToList(string name)
        {
            var data = _service.SearchEmployee(name);
            return new ObservableCollection<Employee>(data);
        }

    }
}
