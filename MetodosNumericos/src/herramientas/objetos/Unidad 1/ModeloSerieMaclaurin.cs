using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodosNumericos.src.herramientas.objetos.Unidad_1
{
    public class ModeloSerieMaclaurin : Modelo
    {
        public ResultadoSerieMaclaurin Resultado{ get; set; }
        public List<ResultadoSerieMaclaurin> Resultados { get; set; }
        public ModeloSerieMaclaurin(float exponente, int cifrasSignificativas)
        {
            Resultado = new ResultadoSerieMaclaurin();
            Resultados = new List<ResultadoSerieMaclaurin>();
            base.ValorXinicial = exponente;
            Resultado.valorVerdadero = Math.Pow(Math.E, exponente);
            Resultado.ToleranciaPorcentual = 0.5 * Math.Pow(10, 2 - cifrasSignificativas);
            Resultado.ErrorRelativoPorcentual = 10000;
            calcularIteraciones();
        }
        private int factorial(int x)
        {
            return x > 0 ? x * factorial(x - 1) : 1;
        }
        public double calcularSerieMaclaurin(int iteracion)
        {
            double resultado = 0;

            if (iteracion == 0)
                resultado = 1;

            if (iteracion == 1)
                resultado = 1 + base.ValorXinicial;

            if (iteracion > 1)
            {
                resultado = 1 + base.ValorXinicial;
                for (int i = 2; i <= iteracion; i++)
                {
                    resultado += (Math.Pow(base.ValorXinicial, i) / factorial(i));
                }
            }
            return resultado;
        }

        private void calcularIteraciones()
        {
            int iteracion = 0;
            while (Resultado.ErrorRelativoPorcentual > Resultado.ToleranciaPorcentual)
            {
                Resultado.valorAproximado = calcularSerieMaclaurin(iteracion);
                Resultado.ErrorVerdadero = Resultado.valorVerdadero - Resultado.valorAproximado;
                Resultado.ErrorPorcental = Resultado.ErrorVerdadero / Resultado.valorVerdadero * 100;
                if (iteracion != 0)
                    Resultado.ErrorRelativoPorcentual = Math.Abs(((Resultado.valorAproximado - Resultados.ElementAt(iteracion-1).valorAproximado) / Resultado.valorAproximado) * 100);
                Resultados.Add(new ResultadoSerieMaclaurin
                {
                    exponente = base.ValorXinicial,
                    valorVerdadero = Resultado.valorVerdadero,
                    valorAproximado = Resultado.valorAproximado,
                    ErrorVerdadero = Resultado.ErrorVerdadero,
                    ErrorPorcental = Resultado.ErrorPorcental,
                    ErrorRelativoPorcentual = Resultado.ErrorRelativoPorcentual,
                    ToleranciaPorcentual = Resultado.ToleranciaPorcentual
                });
                iteracion++;
            }
        }

        public List<ResultadoSerieMaclaurin> resultado()
        {
            return this.Resultados;
        }

        public override float[] resultados()
        {
            return null;
        }
        public override List<float> puntos()
        {
            List<float> puntos = new List<float>();
            foreach (var iteracion in Resultados)
            {
                puntos.Add((float)iteracion.valorAproximado);
            }
            return puntos;
        }

    }
}
