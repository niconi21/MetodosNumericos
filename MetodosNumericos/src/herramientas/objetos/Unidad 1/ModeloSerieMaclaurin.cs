using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos.src.herramientas.objetos.Unidad_1
{
    public class ModeloSerieMaclaurin : Modelo
    {
        public ResultadoSerieMaclaurin Resultado{ get; set; }
        public List<ResultadoSerieMaclaurin> Resultados { get; set; }
        public ModeloSerieMaclaurin(float exponente, int cifrasSignificativas)
        {
            base.ValorXinicial = exponente;
            Resultado.valorVerdadero = Math.Pow(Math.E, exponente);
            Resultado.ToleranciaPorcentual = 0.5 * Math.Pow(10, 2 - cifrasSignificativas);
        }
        private int factorial(int x)
        {
            return x > 0 ? x * factorial(x - 1) : 1;
        }
        private void calcularSerieMaclaurin()
        {

        }

        private void calcularIteraciones()
        {
            while()
        }

    }
}
