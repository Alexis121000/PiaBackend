namespace WebApiLoteria.Entidades
{
    public class Premio
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int rifaId { get; set; }
        
        public Rifa Rifa { get; set; } 

    }
}
