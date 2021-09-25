using System.Windows;
using System.Windows.Input;
using System.Globalization;

namespace EmployeeApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModel _viewModel = new ViewModel();
        private Employee _selectedEmployee = new Employee();
        private Employee _employee = new Employee();
        public MainWindow()
        {
            InitializeComponent();
            GetProducts();
            NewProductGrid.DataContext = _employee;
        }

        private void GetProducts()
        {
            grdEmployee.ItemsSource = _viewModel.ListEmployees;
        }

        private void AddItem(object s, RoutedEventArgs e)
        {
           var data = _viewModel.AddUserToList(_employee);
            if (data)
            {
                _viewModel.ListEmployees.Add(_employee);
                GetProducts();
                _employee = new Employee();
                NewProductGrid.DataContext = _employee;
            }
            else
            {
                _ = MessageBox.Show("Email ID already exist");
            }

           
        }
        private void UpdateItem(object s, RoutedEventArgs e)
        {
            _ = _viewModel.EditUserToList(_selectedEmployee);
            GetProducts();
        }
        private void SelectItemToEdit(object s, RoutedEventArgs e)
        {
            _selectedEmployee = (s as FrameworkElement)?.DataContext as Employee;
            

            UpdateProductGrid.DataContext = _selectedEmployee;
        }
        private void DeleteEmployee(object s, RoutedEventArgs e)
        {
            var productToDelete = (s as FrameworkElement)?.DataContext as Employee;
            var data = _viewModel.DeleteUserToList(productToDelete);
            if (!data) return;
            _viewModel.ListEmployees.Remove(productToDelete);
            GetProducts();
        }

        private void TxtSearchBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;
            e.Handled = true;
            var res = _viewModel.SearchUserToList(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(TxtSearchBox.Text.ToLower()));

            _viewModel.ListEmployees = res;
            GetProducts();
        }
    }
}
