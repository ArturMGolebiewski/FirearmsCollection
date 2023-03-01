namespace MyAPI.Models
{
    public class AddAmmunitionModel
    {
        public Guid Id { get; set; }
        public Guid CaliberId {  get; set; }
        public Guid TypeId  { get; set; }
        public int Count { get; set; }
    }
}
