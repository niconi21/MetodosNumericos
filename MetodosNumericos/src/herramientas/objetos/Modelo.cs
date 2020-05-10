using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos.src.herramientas.objetos
{
    public abstract class Modelo
    {
        public int ValorN { get; set; }
        public double ValorXinicial { get; set; }
        public Funcion Funcion { get; set; }
        public abstract double[] resultados();
        public abstract List<double> puntos();
    }
}
