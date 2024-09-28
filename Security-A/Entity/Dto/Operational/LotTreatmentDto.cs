namespace Entity.Dto.Operational
{
    public class LotTreatmentDto
    {
        public int Id { get; set; }
        public int? LotId { get; set; }
        public int? TreatmentId { get; set; }
        public Boolean? State { get; set; }
        public string? lot {  get; set; }
    }
}
