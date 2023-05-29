
namespace Barbershop.Domain
{
    public class Record
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime DateOfRecord { get; set; }
        List<Service> Services { get; set; } = new();
    }
}
