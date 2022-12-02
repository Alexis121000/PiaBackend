using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiLoteria.Fitros
{
    public class FiltroPersonalizado : IActionFilter
    {
        private readonly ILogger<FiltroPersonalizado> logger;

        public FiltroPersonalizado(ILogger<FiltroPersonalizado> logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("Mensaje antes de la accion");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("Mensaje despues de la accion");
        }

    }
}
