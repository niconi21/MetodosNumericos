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
        public float intervaloA { get; set; }
        public float intervaloB { get; set; }

        public ModeloTrapecio(String funcion, float a, float b, int n)
        {
            base.Funcion = new Funcion(funcion);
            base.ValorN = n;
            intervaloA = a;
            intervaloB = b;
        }

        private float solucionSimple()
        {
            float diferenciaIntervalos = intervaloB - intervaloA;
            float sustitucionIntervaloA = base.Funcion.evaluar(this.intervaloA);
            float sustitucionIntervaloB = base.Funcion.evaluar(this.intervaloB);
            float resultado = diferenciaIntervalos * ((sustitucionIntervaloA + sustitucionIntervaloB) / 2);
            return resultado;
        }

        private float solucionCompuesta()
        {
            float diferenciaIntervalos = intervaloB - intervaloA;
            float sustitucionIntervaloA = base.Funcion.evaluar(this.intervaloA);
            float sumatoria = 0;
            float intervalo = 1.0f / (float)base.ValorN;
            float acumulador = 0;
            for (int i = 1; i < base.ValorN; i++)
            {
                acumulador += intervalo;
                sumatoria += base.Funcion.evaluar(acumulador);
            }
            float sustitucionIntervaloB = base.Funcion.evaluar(this.intervaloB);
            float resultado = diferenciaIntervalos * ((sustitucionIntervaloA + (2 * sumatoria) + sustitucionIntervaloB) / (2 * base.ValorN)) ;
            return resultado;
        }

        public override float[] resultados()
        {
            float[] soluciones = new float[] { solucionSimple(), solucionCompuesta() }; 
            return soluciones;
        }

        public override List<float> puntos()
        {
            return base.Funcion.evaluar();
        }
    }
}
