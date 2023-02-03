namespace MVC2.ViewModels
{
    public class EmployeeVM
    {
        public int id { get; set; }
        public string? fname { get; set; }
        public string? minit { get; set; }
        public string? lname { get; set; }
        public string? sex { get; set; }
        public string? address { get; set; }
        public int? salary { get; set; }
        public DateTime? birthday { get; set; }
        public int? supervisorid { get; set; }
        public int? departmentWFid { get; set; }
    }
}
