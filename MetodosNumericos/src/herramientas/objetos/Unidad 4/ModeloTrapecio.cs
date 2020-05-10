using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodosNumericos.src.herramientas.objetos.Unidad4
{
    public class ModeloTrapecio : Modelo
    {
        public double intervaloA { get; set; }
        public double intervaloB { get; set; }

        public ModeloTrapecio(String funcion, double a, double b, int n)
        {
            base.Funcion = new Funcion(funcion);
            base.ValorN = n;
            intervaloA = a;
            intervaloB = b;
        }

        private double solucionSimple()
        {
            double diferenciaIntervalos = intervaloB - intervaloA;
            double sustitucionIntervaloA = base.Funcion.evaluar(this.intervaloA);
            double sustitucionIntervaloB = base.Funcion.evaluar(this.intervaloB);
            double resultado = diferenciaIntervalos * ((sustitucionIntervaloA + sustitucionIntervaloB) / 2);
            return resultado;
        }

        private double solucionCompuesta()
        {
            double diferenciaIntervalos = intervaloB - intervaloA;
            double sustitucionIntervaloA = base.Funcion.evaluar(this.intervaloA);
            double sumatoria = 0;
            double intervalo = diferenciaIntervalos / (double)base.ValorN;
            double acumulador = this.intervaloA + intervalo;
            while (acumulador != this.intervaloB)
            {
                sumatoria += base.Funcion.evaluar(acumulador);
                acumulador += intervalo;
            }
            
            double sustitucionIntervaloB = base.Funcion.evaluar(this.intervaloB);
            double resultado = diferenciaIntervalos * ((sustitucionIntervaloA + (2 * sumatoria) + sustitucionIntervaloB) / (2 * base.ValorN)) ;
            return resultado;
        }

        public override double[] resultados()
        {
            double[] soluciones = new double[] { solucionSimple(), solucionCompuesta() }; 
            return soluciones;
        }

        public override List<double> puntos()
        {
            return base.Funcion.evaluar();
        }
    }
}
