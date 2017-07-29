using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModel
{
    public class Department
    {
        #region DepartmentProperity
        private int _departmentId;
        public int DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }
        private string name;
        [Display(Name = "Department Name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string location;
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        // Navigation with Employees
        public ICollection<Employee> Employees { get; set; }
        [Timestamp]
        public byte[] rowVirsion { get; set; }
        #endregion
    }
}
