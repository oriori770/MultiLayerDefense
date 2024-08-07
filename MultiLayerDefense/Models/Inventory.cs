namespace Multi_Layer_Defense.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int InterceptorId { get; set; }

        public Interceptor Interceptor { get; set; }

    }
}
