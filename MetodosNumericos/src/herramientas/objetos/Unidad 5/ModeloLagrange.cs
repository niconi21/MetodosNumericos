using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodosNumericos.src.herramientas.objetos.Unidad_5
{
    public class ModeloLagrange : Modelo
    {
        private float[] coordenadasX { get; set; }
        private float[] coordenadasY { get; set; }
        private List<float> coeficientes { get; set; }
        private List<String> polinomios { get; set; }
        public ModeloLagrange(float[] coordenadasX, float[] coordenadasY)
        {
            this.coordenadasX = coordenadasX;
            this.coordenadasY = coordenadasY;
            this.coeficientes = new List<float>();
            this.polinomios = new List<string>();
        }
        private void getCoeficientes(){
            for (int i = 0; i < this.coordenadasX.Length; i++)
            {
                float valorPocision = this.coordenadasX[i];
                float productoDenominador = 1;
                for (int j = 0; j < this.coordenadasX.Length; j++)
                {
                    if (j != i)
                    {
                        productoDenominador *= valorPocision - this.coordenadasX[j];
                    }
                }
                float coeficiente = this.coordenadasY[i] / productoDenominador;
                coeficientes.Add(coeficiente);
            }
        }
        private void getPolinomios()
        {

            for (int i = 0; i < this.coordenadasX.Length; i++)
            {
                float puntoX = this.coordenadasX[i];
                String polinomio = "";
                for (int j = 0; j < this.coordenadasX.Length; j++)
                {
                    if (i != j)
                    {
                        polinomio += "(x" + ((-1 * this.coordenadasX[j]) >= 0 ? "+" + (-1 * this.coordenadasX[j]) : (-1 * this.coordenadasX[j]).ToString()) + ")";
                    }
                }
                polinomios.Add(polinomio);
            }
        }
        private List<String> resolverPolinomio()
        {
            List<String> auxPolinomios = new List<string>();
            foreach (var polinomio in polinomios)
            {
                String polinomioConEspacio = "";
                var sinParentesisFinal = polinomio.Split(')');
                foreach (var auxiliarMonomio in sinParentesisFinal)
                {
                    var sinParentesisInicio = auxiliarMonomio.Split('(');
                    if (sinParentesisInicio.Length > 1)
                        polinomioConEspacio += sinParentesisInicio[1] + " ";
                }
                auxPolinomios.Add(polinomioConEspacio);
            }

            return auxPolinomios;
        }
        public String resultadoFuncion()
        {
            getCoeficientes();
            getPolinomios();

            String funcion = "";
            for (int i = 0; i < polinomios.Count; i++)
            {
                funcion += coeficientes[i] + polinomios[i];
                if (i != polinomios.Count - 1)
                {
                    funcion += "+";
                    if (polinomios.Count > 3)
                        if (i % 2 == 0)
                            funcion += "\n";
                }
            }
            return funcion;

        }
        public override List<float> puntos()
        {
            List<float> puntos = new List<float>();
            var monomios = resolverPolinomio();
            
            for (float i = coordenadasX[0]; i < coordenadasX[coordenadasX.Length-1]; i++)
            {
                int j = 0;
                foreach (var monomio in monomios)
                {
                    float producto = coeficientes[j++];
                    var terminos = monomio.Split(' ');
                    foreach (var termino in terminos)
                    {
                        if (!termino.Equals(""))
                        {
                            base.Funcion = new Funcion(termino);
                            producto *= base.Funcion.evaluar(i);
                        }
                    }
                    puntos.Add(producto);
                }
            }
            return puntos;
        }
        public override float[] resultados()
        {
            return null;
        }
    }
}
