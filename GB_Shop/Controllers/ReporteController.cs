using System.Collections;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GB_Shop.Infraestructure.Repository;
using GB_Shop.Domain.Dtos;
using GB_Shop.Domain.Entities;
using GB_Shop.Applications;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReporteController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        [Route("Reportar")]
        public string reportar(string MotivoDenuncia, string DescripLugar, string GeoUbi, string Colonia, string Fotos)
        {
            var repository = new ReporteSqlRepository();
            var respuesta = repository.reportar(MotivoDenuncia, DescripLugar, GeoUbi, Colonia, Fotos);
            return respuesta;
        }
    }
}