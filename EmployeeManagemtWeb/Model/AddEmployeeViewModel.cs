namespace EmployeeManagemntWeb.Model
{
    public class AddEmployeeViewModel
    {        
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }        

        public Guid DepartmentId { get; set; }
    }
    
    public class AddEmployeeResponseModel
    {
        public Guid Id { get; set; }
    }
}
