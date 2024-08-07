namespace Multi_Layer_Defense.Models
{
    //List of tools - missiles to intercept threats
    public class Interceptor
    {
        public int Id {  get; set; }
        //For example Iron Dome - "Tamir"
        public string Name { get; set; }
        public CounterMeasureType InterceptsThrough { get; set; }

        public WeaponType ForType { get; set; }



    }
}
