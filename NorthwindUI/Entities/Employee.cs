namespace Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string GetFullname()
        {
            return $"{Firstname} {Lastname}";
        }
    }
}
