using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos.src.herramientas.objetos.Unidad_2
{
    public class ModeloNewtonRapshon : Modelo
    {
        private ResultadoNewtonRapshon _Resultado;
        private List<ResultadoNewtonRapshon> _Resultados;
        public ModeloNewtonRapshon(String funcion, double valorInicial, int cifrasSignificativas)
        {
            base.Funcion = new Funcion(funcion);
            base.ValorXinicial = valorInicial;
            _Resultado = new ResultadoNewtonRapshon
            {
                ErrorRelativoPorcentual = 1000,
                ToleranciaPorcentual = 0.5f * Math.Pow(10, 2 - cifrasSignificativas)
            };
            _Resultados = new List<ResultadoNewtonRapshon>();
            iteraciones();
        }

        private void derivada()
        {
            _Resultado.Derivada = new Derivada(base.Funcion.funcion);

        }

        private void iteraciones()
        {
            derivada();
            int i = 0;
            while (_Resultado.ErrorRelativoPorcentual > _Resultado.ToleranciaPorcentual)
            {
                base.ValorXinicial = _Resultado.valorX = base.ValorXinicial - (base.Funcion.evaluar(base.ValorXinicial) / _Resultado.Derivada.evaluar(base.ValorXinicial));
                if (i != 0)
                    _Resultado.ErrorRelativoPorcentual = Math.Abs(((base.ValorXinicial - _Resultados.ElementAt(i - 1).valorX) / base.ValorXinicial) * 100);
                _Resultados.Add(new ResultadoNewtonRapshon
                {
                    Funcion = base.Funcion.funcion,
                    Derivada = _Resultado.Derivada,
                    valorX = base.ValorXinicial,
                    ErrorRelativoPorcentual = _Resultado.ErrorRelativoPorcentual
                });
                i++;
            }
        }
        public List<ResultadoNewtonRapshon> resultado()
        {
            return _Resultados;
        }
        public override List<double> puntos()
        {
            return base.Funcion.evaluar();
        }
        public override double[] resultados()
        {
            return null;
        }
    }
}
