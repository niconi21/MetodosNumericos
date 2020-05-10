using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodosNumericos.src.herramientas.objetos.Unidad_2
{
    public class ModeloBiseccion : Modelo
    {
        private ResultadoModeloBireccion _Resultado;
        private List<ResultadoModeloBireccion> _Resultados;
        private Funcion _funcion;
        private int _intervaloA;
        private int _intervaloB;
        public ModeloBiseccion(String funcion,double intervaloA, double intervaloB,int cifrasSignificativas )
        {
            _Resultado = new ResultadoModeloBireccion();
            _Resultados = new List<ResultadoModeloBireccion>();
            _funcion = new Funcion(funcion);
            _intervaloA = (int)intervaloA;
            _intervaloB = (int)intervaloB;
            _Resultado.IntervaloA = intervaloA;
            _Resultado.IntervaloB = intervaloB;
            _Resultado.ToleranciaPorcentual = 0.5f * Math.Pow(10, 2 - cifrasSignificativas);
            _Resultado.ErrorRelativoPorcentual = 1000;
            _Resultado.Funcion = funcion;
            Iteraciones();
            
        }
        private bool comprobarIntervalor(){
            var funcionEvaluadaIntervaloA = _funcion.evaluar(_Resultado.IntervaloA);
            var funcionEvaluadaIntervaloB = _funcion.evaluar(_Resultado.IntervaloB);
            return (funcionEvaluadaIntervaloA * funcionEvaluadaIntervaloB) < 0;
        }
        private void aproximacionRaiz()
        {

            _Resultado.AproximacionRaiz = (_Resultado.IntervaloA + _Resultado.IntervaloB) / 2;
        }
        private void intercambio()
        {
            if ((_funcion.evaluar(_Resultado.IntervaloA) * _funcion.evaluar(_Resultado.AproximacionRaiz)) < 0)
            {
                _Resultado.IntervaloB = _Resultado.AproximacionRaiz;
            }
            if ((_funcion.evaluar(_Resultado.IntervaloA) * _funcion.evaluar(_Resultado.AproximacionRaiz)) > 0)
            {
                _Resultado.IntervaloA = _Resultado.AproximacionRaiz;
            }
        }
        private bool comprobar()
        {
            return _funcion.evaluar(_Resultado.IntervaloA) * _funcion.evaluar(_Resultado.AproximacionRaiz) == 0;
        }
        private void Iteraciones()
        {
            if (comprobarIntervalor())
            {
                int i = 0;
                while (!comprobar() && _Resultado.ErrorRelativoPorcentual > _Resultado.ToleranciaPorcentual)
                {
                    aproximacionRaiz();
                    intercambio();
                    if (i != 0)
                        _Resultado.ErrorRelativoPorcentual = Math.Abs(((_Resultado.AproximacionRaiz - _Resultados.ElementAt(i - 1).AproximacionRaiz) / _Resultado.AproximacionRaiz) * 100);
                    _Resultados.Add(new ResultadoModeloBireccion
                    {
                        IntervaloA = _Resultado.IntervaloA,
                        IntervaloB = _Resultado.IntervaloB,
                        AproximacionRaiz = _Resultado.AproximacionRaiz,
                        SustitucionIntervaloA = _funcion.evaluar(_Resultado.IntervaloA),
                        SustitucionIntervaloB = _funcion.evaluar(_Resultado.IntervaloB),
                        SustitucionIntervaloAproximacionRaiz = _funcion.evaluar(_Resultado.AproximacionRaiz),
                        ProductoSustitucionAyAproximacionRaiz = _funcion.evaluar(_Resultado.IntervaloA) * _funcion.evaluar(_Resultado.AproximacionRaiz),
                        ErrorRelativoPorcentual = _Resultado.ErrorRelativoPorcentual,
                        Funcion = _Resultado.Funcion
                    });
                    i++;
                }

            }
            else
            {
                throw new Exception("No se puede calcular");
            }
            
        }
        public List<ResultadoModeloBireccion> resultado()
        {
            return _Resultados;
        }
        public override double[] resultados()
        {
            var puntos = new double[_intervaloB - _intervaloA];
            int j = 0;
            for (int i = _intervaloA; i < _intervaloB; i++)
            {
                puntos[j] = _funcion.evaluar(i);
                j++;
            }
            return puntos;
        }
        public override List<double> puntos()
        {
            return null;

        }
    }
}












