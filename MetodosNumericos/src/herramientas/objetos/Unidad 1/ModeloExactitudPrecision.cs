using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodosNumericos.src.herramientas.objetos.Unidad_1
{
    class ModeloExactitudPrecision : Modelo
    {
        private List<int> numeros = new List<int>();
        public ModeloExactitudPrecision(int limite)
        {
            base.ValorN = limite;
            generarNumeros();
        }

        private void generarNumeros()
        {
            for (int i = 0; i < 50; i++)
            {
                int numero = (int)(new Random()).Next(0, base.ValorN);
                this.numeros.Add(numero);
                Thread.Sleep(1);
            }
        }

        private float calcularExactitud()
        {
            int suma = 0;
            for (int i = 0; i < this.numeros.Count; i++)
            {
                suma += this.numeros[i];
            }
            return ((suma / 50 )* 100) / base.ValorN;
        }

        private float calcularPrecision()
        {
            int suma = 0;
            int iteraciones = 0;
            for (int i = 0; i < this.numeros.Count; i++)
            {
                int diferencia = 0;
                for (int j = i; j < this.numeros.Count; j++)
                {
                    diferencia += Math.Abs(numeros[i] - numeros[j]);
                   iteraciones++;
                }
                suma += diferencia;
            }
            
            return (suma / iteraciones) * 100 / base.ValorN;
        }

        public List<int> getNumeros() { return numeros; }

        public override float[] resultados()
        {
            return new float[] { calcularExactitud(), calcularPrecision() };
        }
        public override List<float> puntos()
        {
            return null;
        }
    }
}
