using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos.src.herramientas.objetos.Unidad_2
{
    public class ResultadoNewtonRapshon
    {
        public String Funcion { get; set; }
        public String derivada { get; set; }
        public Derivada Derivada{ get; set; }
        public double valorX { get; set; }
        public double ErrorRelativoPorcentual { get; set; }
        public double ToleranciaPorcentual { get; set; }
    }
}
