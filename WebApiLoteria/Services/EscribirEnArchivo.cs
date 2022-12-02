namespace WebApiLoteria.Services
{
    public class EscribirEnArchivo : IHostedService
    {
        private readonly IWebHostEnvironment env;
        private readonly string nombreArchivo = "Registros.txt";
        private Timer timer;
        public EscribirEnArchivo(IWebHostEnvironment env)
        {
            this.env = env;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(15));
            Escribir("Inicio del procesamiento");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer.Dispose();
            Escribir("Fin del procesamiento");
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            Escribir("Ejecucion en proceso: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));
        }
        private void Escribir(string msg)
        {
            var ruta = $@"{env.ContentRootPath}\wwwroot\{nombreArchivo}";
            using (StreamWriter writer = new StreamWriter(ruta, append: true)) { writer.WriteLine(msg); }
        }
    }
}
