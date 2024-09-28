using Entity.Model.Parameter;

namespace Entity.Model.Operational
{
    public class Lot
    {
        public int Id { get; set; }
        public int CropId { get; set; }
        public Crop Crop { get; set; }
        public int FarmId { get; set; }
        public Farm Farm { get; set; }
        public int Num_hectareas { get; set; }
        public bool State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
