namespace EmployeeManagemntWeb.Model
{
    public class EmployeeListViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
    }

    public class EmployeeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string DepartmentName { get; set; }

        public Guid DepartmentId { get; set; }
    }

    public class DepartmentViewModel
    {
        public Guid Id { get; set; }
        public Guid Name { get; set; }
    }
}
