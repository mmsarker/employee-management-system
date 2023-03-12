namespace EmployeeManagemntWeb.Model
{
    public class DepartmentListViewModel
    {
        public List<DepartmentViewModel> Departments { get; set; }
    }

    public class DepartmentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
    }
}
