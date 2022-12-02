namespace WebApiLoteria.Entidades
{
    public class RifaParticipante
    {
        public int RifaId { get; set; }
        public int ParticipanteId { get; set; }
        public int Orden { get; set; }
        public Rifa Rifa { get; set; }
        public Participante Participante { get; set; }
    }
}