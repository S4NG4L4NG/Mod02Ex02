using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Mod02Ex02.Model;



namespace Mod02Ex02.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private Employee _employee;

        private string _fullName; //variable for data conversion

        public EmployeeViewModel()
        {
            //initialized a sample employee model and coordinate with Model
            _employee = new Employee { FirstName = "John", LastName = "Doe",
            Position = "Manager ", Department = "IT", IsActive = true };
            LoademployeeDataCommand = new Command(async () => await LoademployeeDataAsync());


            Employees = new ObservableCollection<Employee>
            {
                new Employee {FirstName="Jane", LastName="Smith", Position="Secretary",
                    Department="IT", IsActive=true},
                new Employee {FirstName="Mollie", LastName="Mamoth", Position="Admin",
                    Department="IT", IsActive=true},
                new Employee {FirstName="Rahdan", LastName="Radagon", Position="Administrator",
                    Department="IT", IsActive=false}
            };

        }

        //setting collection to public
        public ObservableCollection<Employee> Employees { get; set; }

        //two way data binding and data conversion
        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }


        //UI thread Management
        public ICommand LoademployeeDataCommand { get; }

        private async Task LoademployeeDataAsync()
        {
            await Task.Delay(1000); // I/0 operation
            FullName = $"{_employee.FirstName} {_employee.LastName} {_employee.Position}" +
                $"{_employee.Department}"; //conversion

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
