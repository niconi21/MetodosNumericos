using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MetodosNumericos.src.herramientas.objetos
{
    public class Funcion
    {
        public String funcion { get; set; }
        private List<String> Terminos { get; set; }
        private List<double> constantes { get; set; }
        public Funcion(String funcion)
        {
            this.funcion = funcion;
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
        private void convertirTerminosANumeros(double x)
        {
            this.constantes = new List<double>();//instanciamos nuestra lista de las constantes
            foreach (var termino in this.Terminos)//recorremos los terminos y lo almacenamos en un termino
            {
                var auxTermino = termino.Split('x');//separamos el termino con respecto a la x, lo que nos dará varios casos
                switch (auxTermino.Length)
                {
                    case 1://si la longitud del arreglo auxTermino es 1, quiere decir que solo es una constante
                        if (auxTermino[0].Equals("+e") || auxTermino[0].Equals("-e"))
                        {
                            constantes.Add((double)Math.E);
                        }
                        else
                        {
                            constantes.Add(double.Parse(auxTermino[0]));//lo convertimos a numero y lo almacenamos
                        }
                        break;
                    case 2://si la longitud es 2, entonces tenemos 4 casos
                        if ((auxTermino[0].Equals("+") || auxTermino[0].Equals("-")) && auxTermino[1].Equals(""))//primer caso donde se puede encontrar el termino con la forma "x" es decir, solo la variable x
                        {
                            constantes.Add(x);//simplemente agregamos el valor de la variable x
                            continue;
                        }
                        if (!auxTermino[0].Equals("") && auxTermino[1].Equals(""))//segundo caso donde se puede encontrar el termino con la forma "2x" es decir, una constante por la variable
                        {
                            try
                            {
                                constantes.Add(double.Parse(auxTermino[0]) * x);//se convierte la constante a numero y se multiplica por x, al final se almacena
                                continue;
                            }
                            catch
                            {
                                bool negativo = false;
                                char menos = auxTermino[0].ElementAt(0);
                                if (menos == '-')
                                    negativo = true;
                                auxTermino[0] = auxTermino[0].Substring(1);
                                var auxEuler = auxTermino[0].Split('e');
                                if (!auxEuler[0].Equals("") && auxEuler[1].Equals("^"))
                                {
                                    double eulerElevadoX = (double)Math.Pow(Math.E, x);
                                    double producto = double.Parse(auxEuler[0]) * eulerElevadoX;
                                    constantes.Add(negativo ? producto * -1 : producto);
                                    continue;
                                }else if (auxEuler[0].Equals("") && auxEuler[1].Equals("^"))
                                {
                                    double eulerElevadoX = (double)Math.Pow(Math.E, x);
                                    constantes.Add(negativo ? eulerElevadoX * -1 : eulerElevadoX);
                                    continue;
                                }
                                else
                                {
                                    var auxExponente = auxEuler[1].Split('^');
                                    double productoVariableConstante = double.Parse(auxExponente[1]) * x;
                                    double eulerElevadoAlProducto = (double)Math.Pow(Math.E, productoVariableConstante);
                                    constantes.Add(eulerElevadoAlProducto);
                                    continue;
                                }
                                

                            }
                        }
                        if ((auxTermino[0].Equals("+") || auxTermino[0].Equals("-")) && !auxTermino[1].Equals(""))//tercer caso donde se puede encontrar el termino con la forma "x^2" es decir, una variable elevada a una potencia
                        {
                            
                            String exponente = auxTermino[1].Substring(1);//se obtiene el valor de la potencia o exponente
                            constantes.Add((double)Math.Pow(x, double.Parse(exponente)));//a la variable la elevamos a la potencia o exponente
                            continue;
                        }
                        if (!auxTermino[0].Equals("") && !auxTermino[1].Equals(""))//cuarto caso donde se puede encontrar el termino con la forma "2x^2" es decir, una constante por la variable elevada a una potencia
                        {
                            try
                            {
                                String exponente = auxTermino[1].Substring(1);//se consigue el exponente a la que está elevado
                                double elevadoExponente = (double)Math.Pow(x, double.Parse(exponente));//la variable se eleva a ese exponente
                                double producto = double.Parse(auxTermino[0]) * elevadoExponente;//se multiplica la constante por el resultado de la variable elevado al exponente 
                                constantes.Add(producto);//se almacena el resultado
                                continue;
                            }
                            catch (Exception)
                            {
                                bool negativo = false;
                                char menos = auxTermino[0].ElementAt(0);
                                if (menos == '-')
                                    negativo = true;
                                auxTermino[0] = auxTermino[0].Substring(1);
                                var auxEuler = auxTermino[0].Split('e');
                                if (!auxEuler[0].Equals("") && auxEuler[1].Equals("^"))
                                {
                                    double variableElevadaConstante = (double)Math.Pow(x, double.Parse(auxTermino[1].Substring(1)));
                                    double eulerElevadoX = (double)Math.Pow(Math.E, variableElevadaConstante);
                                    double producto = double.Parse(auxEuler[0]) * eulerElevadoX;
                                    constantes.Add(negativo ? producto * -1 : producto);
                                    continue;
                                }else if (auxEuler[0].Equals("") && auxEuler[1].Equals("^"))
                                {
                                    double variableElevadaConstante = (double)Math.Pow(x, double.Parse(auxTermino[1].Substring(1)));
                                    double eulerElevadoX = (double)Math.Pow(Math.E, variableElevadaConstante);
                                    constantes.Add(negativo ? eulerElevadoX * -1 : eulerElevadoX);
                                    continue;
                                }
                                
                            }
                        }
                        break;
                }
            }//se repite hasta que se terminen todos los terminos
        }
        public double evaluar(double x)
        {
            separarFuncionEnTerminos();
            convertirTerminosANumeros(x);
            double resultado = 0;
            foreach (var constante in constantes)
            {
                resultado += constante;
            }
            return resultado;
        }
        public List<double> evaluar()
        {
            List<double> puntos = new List<double>();
            for (double i = -3; i < 3; i+=.2f)
            {
                puntos.Add(evaluar(i));
            }
            return puntos;
        }
        
    }
}
