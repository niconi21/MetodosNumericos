﻿using System;
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
        private List<ResultadoExactitudPrecision> numeros = new List<ResultadoExactitudPrecision>();
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
                this.numeros.Add(new ResultadoExactitudPrecision { numero = numero });
                Thread.Sleep(1);
            }
        }

        private double calcularExactitud()
        {
            int suma = 0;
            for (int i = 0; i < this.numeros.Count; i++)
            {
                suma += this.numeros[i].numero;
            }
            return ((suma / 50 )* 100) / base.ValorN;
        }

        private double calcularPrecision()
        {
            int suma = 0;
            int iteraciones = 0;
            for (int i = 0; i < this.numeros.Count; i++)
            {
                int diferencia = 0;
                for (int j = i; j < this.numeros.Count; j++)
                {
                    diferencia += Math.Abs(numeros[i].numero - numeros[j].numero);
                   iteraciones++;
                }
                suma += diferencia;
            }
            
            return (suma / iteraciones) * 100 / base.ValorN;
        }

        public List<ResultadoExactitudPrecision> getNumeros() { return numeros; }

        public override double[] resultados()
        {
            return new double[] { calcularExactitud(), calcularPrecision() };
        }
        public override List<double> puntos()
        {
            return null;
        }
    }
}
