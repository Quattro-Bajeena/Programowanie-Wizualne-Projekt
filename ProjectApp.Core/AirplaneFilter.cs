namespace OleszekMowinski.ProjectApp.Core
{
    public class AirplaneFilter
    {
        public DateTime? Introduction { get; set; }
        public bool BeforeIntroduction { get; set; }
        public int? Weight { get; set; }
        public bool BelowWeight { get; set; }
        public AirplaneStatus? Status { get; set; }
        public Guid? ManufacturerId { get; set; }
    }
}
