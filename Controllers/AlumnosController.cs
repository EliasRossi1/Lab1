using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab1.Models;
using Microsoft.Extensions.Logging;


namespace Lab1.Controllers
{
    public class AlumnosController : Controller
    {

        private readonly ILogger<AlumnosController> _logger;
        public AlumnosController(ILogger<AlumnosController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

     

        [HttpPost]
		public IActionResult Alumno(
             Alumnos alumno)
		{

            int pago =0;
            alumno.credito=300;
            int canCreditos=0;
			double valigv=0;
           

             if("HISTORIA".Equals(alumno.Curso)){
                pago=alumno.credito+pago;
                canCreditos+=3;
            }
            if("MATEMATICA".Equals(alumno.Curso)){
                pago=alumno.credito+pago;
                canCreditos+=3;
            }
            if("LENGUAJE".Equals(alumno.Curso)){
                pago=alumno.credito+pago;
                canCreditos+=3;
            }
            
            
            
            valigv=pago*1.18-pago;
            alumno.Result=pago+valigv;

            
            ViewData["Message"] = "Resultado: NOMBRE DEL ALUMNO:  "+alumno.nombre+"\n TOTAL DE CURSOS INSCRITOS:  "+canCreditos+"\n PAGO POR CURSOS:  "+pago+"\n IGV:  "+valigv+"\n TOTAL A PAGAR:  "+alumno.Result ;
            return View("Index",alumno);
		}


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}