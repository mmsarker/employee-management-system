namespace EmployeeManagemntWeb.Model
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Guid? DepartmentId { get; set; }               
    }
}
