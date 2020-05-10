using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos.src.herramientas.objetos.Unidad4
{
    public class ModeloDiferenciacionNumerica : Modelo
    {
        public double valorH { get; set; }

        public ModeloDiferenciacionNumerica(String funcion,double x, double h)
        {
            base.Funcion = new Funcion(funcion);
            base.ValorXinicial = x;
            this.valorH = h;

        }

        ////////////////////////
        ///////dos puntos//////
        ////////////////////////
        //Diferenciales finitas progresivas
        private double solucionDosPuntosFinitasPrograsivas()
        {
            double sustitucionValorIniciaMasH = base.Funcion.evaluar(base.ValorXinicial + this.valorH);
            double sustitucionValorInicial = base.Funcion.evaluar(base.ValorXinicial);
            double resultado = (sustitucionValorIniciaMasH - sustitucionValorInicial) / this.valorH;
            return resultado;
        }
        //Diferenciales finitas centradas
        private double solucionDosPuntosFinitasCentradas()
        {
            double sustitucionValorIniciaMasH = base.Funcion.evaluar(base.ValorXinicial + this.valorH);
            double sustitucionValorInicialMenosH = base.Funcion.evaluar(base.ValorXinicial - this.valorH);
            double resultado = (sustitucionValorIniciaMasH - sustitucionValorInicialMenosH) / (2 * this.valorH)  ;
            return resultado;
        }
        //Diferenciales finitas regresivas
        private double solucionDosPuntosFinitasRegresivas()
        {
            double sustitucionValorInicial = base.Funcion.evaluar(base.ValorXinicial);
            double sustitucionValorInicialMenosH = base.Funcion.evaluar(base.ValorXinicial - this.valorH);
            double resultado = (sustitucionValorInicial - sustitucionValorInicialMenosH) / this.valorH;
            return resultado;
        }
        ////////////////////////
        ///////tres puntos//////
        ////////////////////////
        //Diferenciales finitas progresivas
        private double solucionTresPuntosFinitasPrograsivas()
        {
            double menosTripleSustitucionValorInicial = -3 * base.Funcion.evaluar(base.ValorXinicial);
            double cuatrupleSustitucionValorIniciaMasH = 4 * base.Funcion.evaluar(base.ValorXinicial + this.valorH);
            double sustitucionValorIniciaMasDosH = base.Funcion.evaluar(base.ValorXinicial + (2 * this.valorH));
            double resultado = (menosTripleSustitucionValorInicial + cuatrupleSustitucionValorIniciaMasH - sustitucionValorIniciaMasDosH) / (2.0f * this.valorH);
            return resultado;
        }
        //Diferenciales finitas Centradas
        private double solucionTresPuntosFinitasCentradas()
        {
            double sustitucionValorInicialMenosDosH = base.Funcion.evaluar(base.ValorXinicial - (2 * this.valorH));
            double octupleSustitucionValorInicialMenosH = 8 * base.Funcion.evaluar(base.ValorXinicial - this.valorH);
            double octupleSustitucionValorInicialMasH = 8 * base.Funcion.evaluar(base.ValorXinicial + this.valorH);
            double sustitucionValorInicialMasDosH = base.Funcion.evaluar(base.ValorXinicial + (2 * this.valorH));
            double resultado = (sustitucionValorInicialMenosDosH - octupleSustitucionValorInicialMenosH + octupleSustitucionValorInicialMasH - sustitucionValorInicialMasDosH) / (12 * this.valorH);
            return resultado;
        }
        //Diferenciales finitas Regresiva
        private double solucionTresPuntosFinitasRegresivas()
        {
            double sustitucionValorInicialMenosDosH = base.Funcion.evaluar(base.ValorXinicial - (2 * this.valorH));
            double cuadrupleSustitucionValorInicialMenosH = 4 *base.Funcion.evaluar(base.ValorXinicial - this.valorH);
            double tripleSustitucionValorInicial = 3 * base.Funcion.evaluar(base.ValorXinicial);
            double resultado = (sustitucionValorInicialMenosDosH - cuadrupleSustitucionValorInicialMenosH + tripleSustitucionValorInicial) / (2 * this.valorH);
            return resultado;
        }

        public override double[] resultados()
        {
            double[] resultados = new double[] { 
                solucionDosPuntosFinitasPrograsivas(),
                solucionTresPuntosFinitasPrograsivas(),
                solucionDosPuntosFinitasCentradas(),
                solucionTresPuntosFinitasCentradas(),
                solucionDosPuntosFinitasRegresivas(),
                solucionTresPuntosFinitasRegresivas(),
            };
            return resultados;   
        }

        public override List<double> puntos()
        {
            return base.Funcion.evaluar();
        }
    }
}
