using Mod02Ex02.ViewModel;

namespace Mod02Ex02.View;

public partial class EmployeePage : ContentPage
{
	public EmployeePage()
	{
		InitializeComponent();
        BindingContext = new EmployeeViewModel();
    }
}