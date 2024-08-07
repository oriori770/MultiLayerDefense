using System.ComponentModel.DataAnnotations;

namespace Multi_Layer_Defense.Models
{
    // Response model capturing the response details to threats
    public class Response
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ThreatId { get; set; }
        public Threat Threat { get; set; }
        [Required]
        public DateTime LaunchTime { get; set; }
        public DateTime? InterceptTime { get; set; }
        public int InterceptorId { get; set; }
        public Interceptor Interceptor { get; set; }
        //public CounterMeasureType ResponseType { get; set; }
        public ResponseStatus status { get; set; }
    }
}
