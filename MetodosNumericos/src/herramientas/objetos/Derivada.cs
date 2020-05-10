using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MetodosNumericos.src.herramientas.objetos
{
    public class Derivada
    {
        private Funcion _Funcion { get; set; }
        private List<String> Terminos;
        private List<String> TerminosDerivados;
        private String funcion;
        public Derivada(String funcion)
        {
            this.funcion = funcion;
            separarFuncionEnTerminos();
        }
        private void separarFuncionEnTerminos()
        {
            this.Terminos = new List<string>();//instacio la lista de los terminos
            if (this.funcion.ElementAt(0) != '+' && this.funcion.ElementAt(0) != '-')//verifico si tiene el signo de + o -, se lo pongo si no lo tiene
                this.funcion = "+" + this.funcion;
            String termino = "";//auxiliar que me auidará a manterner todo el termino
            foreach (var caracter in this.funcion)//recorro los caracteres de la funcion
            {
                if (caracter == '+' || caracter == '-')//si el caracter es un + o - 
                {
                    this.Terminos.Add(termino);//el termino lo meto a la lista de terminos
                    termino = caracter.ToString();//el termino le borro todo asignandole el valor el signo que es caracter
                    continue;//continuamos con el bucle, ignorando todas las intrucciones que sigue, y regresando al inicio pero con la siguiente iteracion
                }
                termino += caracter;//concatenamos el caracter para hacer un termno
            }
            this.Terminos.Add(termino);//al ultimo termino lo agregamos despues del bucle
            this.Terminos.RemoveAt(0);//borramos el primer elemento ya que siempre estará vacio
        }
        private void derivar()
        {
            TerminosDerivados = new List<string>();
            foreach (var termino in Terminos)
            {
                String auxTermino = termino.Substring(1);
                char signo = termino.ElementAt(0);
                var terminoSeparado = auxTermino.Split('x');
                if (terminoSeparado.Length == 1)
                {
                    TerminosDerivados.Add(signo + "0");
                    continue;
                }
                else
                {
                    if (terminoSeparado[0].Equals("") && terminoSeparado[1].Equals(""))
                    {
                        TerminosDerivados.Add(signo+"1");
                        continue;
                    }
                    if (terminoSeparado[0].Equals("") && !terminoSeparado[1].Equals(""))
                    {
                        var auxTermino2 = terminoSeparado[1].Substring(1);
                        TerminosDerivados.Add(signo + auxTermino2 + "x^" + (double.Parse(auxTermino2) - 1));
                        continue;
                    }
                    if (!terminoSeparado[0].Equals("") && terminoSeparado[1].Equals(""))
                    {
                        TerminosDerivados.Add(signo + terminoSeparado[0]);
                        continue;
                    }
                    if (!terminoSeparado[0].Equals("") && !terminoSeparado[1].Equals(""))
                    {
                        var exponente = double.Parse(terminoSeparado[1].Substring(1));
                        var constante = double.Parse(terminoSeparado[0]);
                        String baseDerivada = (exponente * constante).ToString();
                        String derivada = signo + baseDerivada + "x^" + (exponente - 1);
                        TerminosDerivados.Add(derivada);
                        continue;
                    }
                }
                
            }
        }
        public String unirTerminos()
        {
            derivar();
            String funcionDerivara = "";
            foreach (var termino in TerminosDerivados)
            {
                funcionDerivara += termino;
            }
            return funcionDerivara;
        }
        public double evaluar(double valor)
        {
            _Funcion = new Funcion(unirTerminos());
            return _Funcion.evaluar(valor);
        }
    }
}
