using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos.src.herramientas.objetos.Unidad4
{
    public class ModeloDiferenciacionNumerica : Modelo
    {
        public float valorH { get; set; }

        public ModeloDiferenciacionNumerica(String funcion,float x, float h)
        {
            base.Funcion = new Funcion(funcion);
            base.ValorXinicial = x;
            this.valorH = h;

        }

        ////////////////////////
        ///////dos puntos//////
        ////////////////////////
        //Diferenciales finitas progresivas
        private float solucionDosPuntosFinitasPrograsivas()
        {
            float sustitucionValorIniciaMasH = base.Funcion.evaluar(base.ValorXinicial + this.valorH);
            float sustitucionValorInicial = base.Funcion.evaluar(base.ValorXinicial);
            float resultado = (sustitucionValorIniciaMasH - sustitucionValorInicial) / this.valorH;
            return resultado;
        }
        //Diferenciales finitas centradas
        private float solucionDosPuntosFinitasCentradas()
        {
            float sustitucionValorIniciaMasH = base.Funcion.evaluar(base.ValorXinicial + this.valorH);
            float sustitucionValorInicialMenosH = base.Funcion.evaluar(base.ValorXinicial - this.valorH);
            float resultado = (sustitucionValorIniciaMasH - sustitucionValorInicialMenosH) / (2 * this.valorH)  ;
            return resultado;
        }
        //Diferenciales finitas regresivas
        private float solucionDosPuntosFinitasRegresivas()
        {
            float sustitucionValorInicial = base.Funcion.evaluar(base.ValorXinicial);
            float sustitucionValorInicialMenosH = base.Funcion.evaluar(base.ValorXinicial - this.valorH);
            float resultado = (sustitucionValorInicial - sustitucionValorInicialMenosH) / this.valorH;
            return resultado;
        }
        ////////////////////////
        ///////tres puntos//////
        ////////////////////////
        //Diferenciales finitas progresivas
        private float solucionTresPuntosFinitasPrograsivas()
        {
            float menosTripleSustitucionValorInicial = -3 * base.Funcion.evaluar(base.ValorXinicial);
            float cuatrupleSustitucionValorIniciaMasH = 4 * base.Funcion.evaluar(base.ValorXinicial + this.valorH);
            float sustitucionValorIniciaMasDosH = base.Funcion.evaluar(base.ValorXinicial + (2 * this.valorH));
            float resultado = (menosTripleSustitucionValorInicial + cuatrupleSustitucionValorIniciaMasH - sustitucionValorIniciaMasDosH) / (2.0f * this.valorH);
            return resultado;
        }
        //Diferenciales finitas Centradas
        private float solucionTresPuntosFinitasCentradas()
        {
            float sustitucionValorInicialMenosDosH = base.Funcion.evaluar(base.ValorXinicial - (2 * this.valorH));
            float octupleSustitucionValorInicialMenosH = 8 * base.Funcion.evaluar(base.ValorXinicial - this.valorH);
            float octupleSustitucionValorInicialMasH = 8 * base.Funcion.evaluar(base.ValorXinicial + this.valorH);
            float sustitucionValorInicialMasDosH = base.Funcion.evaluar(base.ValorXinicial + (2 * this.valorH));
            float resultado = (sustitucionValorInicialMenosDosH - octupleSustitucionValorInicialMenosH + octupleSustitucionValorInicialMasH - sustitucionValorInicialMasDosH) / (12 * this.valorH);
            return resultado;
        }
        //Diferenciales finitas Regresiva
        private float solucionTresPuntosFinitasRegresivas()
        {
            float sustitucionValorInicialMenosDosH = base.Funcion.evaluar(base.ValorXinicial - (2 * this.valorH));
            float cuadrupleSustitucionValorInicialMenosH = 4 *base.Funcion.evaluar(base.ValorXinicial - this.valorH);
            float tripleSustitucionValorInicial = 3 * base.Funcion.evaluar(base.ValorXinicial);
            float resultado = (sustitucionValorInicialMenosDosH - cuadrupleSustitucionValorInicialMenosH + tripleSustitucionValorInicial) / (2 * this.valorH);
            return resultado;
        }

        public override float[] resultados()
        {
            float[] resultados = new float[] { 
                solucionDosPuntosFinitasPrograsivas(),
                solucionTresPuntosFinitasPrograsivas(),
                solucionDosPuntosFinitasCentradas(),
                solucionTresPuntosFinitasCentradas(),
                solucionDosPuntosFinitasRegresivas(),
                solucionTresPuntosFinitasRegresivas(),
            };
            return resultados;   
        }

        public override List<float> puntos()
        {
            return base.Funcion.evaluar();
        }
    }
}
