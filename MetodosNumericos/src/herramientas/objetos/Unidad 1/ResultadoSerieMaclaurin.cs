using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos.src.herramientas.objetos.Unidad_1
{
    public class ResultadoSerieMaclaurin
    {
        public double exponente { get; set; }
        public double valorVerdadero { get; set; }
        public double valorAproximado { get; set; }
        public double ErrorVerdadero { get; set; }
        public double ErrorPorcental { get; set; }
        public double ErrorRelativoPorcentual { get; set; }
        public double ToleranciaPorcentual { get; set; }
    }
}
