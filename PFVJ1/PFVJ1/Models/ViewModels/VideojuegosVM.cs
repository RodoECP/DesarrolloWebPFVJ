using Microsoft.AspNetCore.Mvc.Rendering;

namespace PFVJ1.Models.ViewModels
{
    public class VideojuegosVM
    {
        public Datos oDatos {  get; set; }

        public List<SelectListItem> oLista { get; set; }
    }
}
