using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodosNumericos.src.herramientas.objetos.Unidad_1
{
    public class ModeloCifrasSignificativas : Modelo
    {
        public ModeloCifrasSignificativas(String cifra)
        {
            base.Funcion = new Funcion(cifra);
        }
        private double[] calcularCifrasSignificativas(String cifras)
        {
            String cifrasSinCerosIzquierda = "";
            bool cerosIzquierda = true;
            foreach (var cifra in cifras)
            {
                if (cifra != '0' && cifra != '.')
                {
                    cerosIzquierda = false;
                }
                if (!cerosIzquierda)
                {
                    cifrasSinCerosIzquierda += cifra;
                }
            }
            
            bool cerosDerecha = true;
            bool puntoDecimal = false;
            String cifrasSinCerosDerecha = "";
            for (int i = cifrasSinCerosIzquierda.Length - 1; i >= 0; i--)
            {
                if (cifrasSinCerosIzquierda[i] != '0')
                {
                    cerosDerecha = false;
                }
                if (!cerosDerecha)
                {
                    cifrasSinCerosDerecha += cifrasSinCerosIzquierda[i];
                    if (cifrasSinCerosIzquierda[i] == '.')
                        puntoDecimal = true;
                }
            }
            double punto = puntoDecimal ? 1 : 0;
            return new double[] { cifrasSinCerosIzquierda.Length - punto, cifrasSinCerosDerecha.Length - punto };
        }
        public String notacionCientifica()
        {
            String cifras = base.Funcion.funcion;
            String cifrasSinCerosIzquierda = "";
            bool cerosIzquierda = true;
            foreach (var cifra in cifras)
            {
                if (cifra != '0')
                {
                    cerosIzquierda = false;
                }
                if (!cerosIzquierda)
                {
                    cifrasSinCerosIzquierda += cifra;
                }
            }
            String notacionCientifica = "";
            String auxCifra = "";
            int exponente = 1;
            if (cifrasSinCerosIzquierda.ElementAt(0) == '.')
            {
                bool cerosDerecha = true;
                for (int i = 1; i < cifrasSinCerosIzquierda.Length; i++)
                {
                    if (i == 2)
                        auxCifra += "." + cifrasSinCerosIzquierda[i];
                    else
                    {
                        auxCifra += cifrasSinCerosIzquierda[i];
                        if (cifrasSinCerosIzquierda[i] != '0')
                            cerosDerecha = false;
                    }
                    if (cifrasSinCerosIzquierda[i] == '0' && cerosDerecha)
                        exponente++;
                }
                notacionCientifica = auxCifra + "x 10^-" + exponente;
            }
            else
            {
                exponente = 0;
                notacionCientifica += cifrasSinCerosIzquierda[0] + ".";
                for (int i = 1; i < cifrasSinCerosIzquierda.Length ; i++)
                {
                    if (cifrasSinCerosIzquierda[i] != '.')
                    {
                        notacionCientifica += cifrasSinCerosIzquierda[i];
                        exponente++;
                    }
                }
                notacionCientifica += "x 10 ^" + exponente;
            }
            return notacionCientifica;
        }
        public override double[] resultados()
        {
            return calcularCifrasSignificativas(base.Funcion.funcion);
        }
        public override List<double> puntos()
        {
            return null;
        }
    }

}
