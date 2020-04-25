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
        private float[] calcularCifrasSignificativas(String cifras)
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
            float punto = puntoDecimal ? 1 : 0;
            return new float[] { cifrasSinCerosIzquierda.Length - punto, cifrasSinCerosDerecha.Length - punto };
        }
        public String notacionCientifica()
        {
            String cifras = base.Funcion.funcion;
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
            String cifrasSinCeros = "";
            for (int i = cifrasSinCerosDerecha.Length - 1; i >= 0; i--)
            {
                cifrasSinCeros += cifrasSinCerosDerecha[i];
            }
            int exponente = 0;
            String baseNotacionCientifica = "";
            MessageBox.Show(cifrasSinCeros);
            if (cifrasSinCeros[0] != '.')
            {
                baseNotacionCientifica = cifrasSinCeros[0] + ".";
                bool puntoDecimanEncontrado = false;
                for (int i = 1; i < cifrasSinCeros.Length; i++)
                {
                    if (cifrasSinCeros[i] == '.')
                        puntoDecimanEncontrado = true;
                    if (cifrasSinCeros[i] != '.' && !puntoDecimanEncontrado)
                    {
                        exponente++;
                    }
                    if (cifrasSinCeros[i] != '.')
                        baseNotacionCientifica += cifrasSinCeros[i];
                }
            }
            else
            {
 
                
                foreach (var cifra in cifrasSinCeros)
                {
                    if (cifra == '.')
                        continue;
                    baseNotacionCientifica += cifra;
                }
            }
            return baseNotacionCientifica + " x 10^" + exponente;
        }
        public override float[] resultados()
        {
            return calcularCifrasSignificativas(base.Funcion.funcion);
        }
        public override List<float> puntos()
        {
            return null;
        }
    }

}
