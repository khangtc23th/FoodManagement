namespace wed.Areas.Admin.Models
{
    public class NemberViewModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? LoginName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Picturn { get; set; }
        public Guid? GroupId { get; set; }
       
    }
}
