using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModel
{
    public class Employee
    {
        #region EmployeeProperity
        private int employeeId;
        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }
        private string name;
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string email;
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string mobile;
        [MaxLength(10)]
        [Required(ErrorMessage = "Please Enter Your Mobile")]
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        [Timestamp]
        public byte[] rowVirsion { get; set; }
        public virtual Department Departments { get; set; }
        #endregion
    }
}
