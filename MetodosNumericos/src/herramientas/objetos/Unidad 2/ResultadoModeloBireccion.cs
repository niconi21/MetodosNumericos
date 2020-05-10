using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos.src.herramientas.objetos.Unidad_2
{
    public class ResultadoModeloBireccion
    {
        public String Funcion { get; set; }
        public double IntervaloA { get; set; }
        public double IntervaloB { get; set; }
        public double AproximacionRaiz { get; set; }
        public double SustitucionIntervaloA { get; set; }
        public double SustitucionIntervaloB { get; set; }
        public double SustitucionIntervaloAproximacionRaiz { get; set; }
        public double ProductoSustitucionAyAproximacionRaiz{ get; set; }
        public double ErrorRelativoPorcentual { get; set; }
        public double ToleranciaPorcentual { get; set; }
    }
}
