namespace WebApiLoteria.DTOs
{
    public class GetPremioDTO
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
    }
}
