namespace Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string GetFullname()
        {
            return $"{Firstname} {Lastname}";
        }
    }
}
