namespace ASPCoreApplication2023.Models
{
    public class Membershiptype
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public float SignUpFee { get; set; }
        public float DiscountRate { get; set; }
        public int DurationInMonth { get; set; }
        public List<Customer>? Customers { get; set; }
    }
}
