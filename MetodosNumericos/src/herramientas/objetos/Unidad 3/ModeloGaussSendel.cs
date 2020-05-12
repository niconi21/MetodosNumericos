using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos.src.herramientas.objetos.Unidad_3
{
    public class ModeloGaussSendel : Modelo
    {
         private double[] _terminosIndependientes;
        private double[] _constantesV;
        private double[] _constantesW;
        private double[] _constantesX;
        private double[] _constantesY;
        private double[] _constantesZ;
        private double[] _valorInicial;
        private List<ResultadoJacobi> _Resultados = new List<ResultadoJacobi>();
        private ResultadoJacobi _Resultado = new ResultadoJacobi();

        public ModeloGaussSendel(int cifrasSignificativas, double[] terminosIndependientes, double[] constantesV, double[] constantesW, double[] constantesX, double[] constantesY, double[] constantesZ, double[] valorInicial)
        {
            _terminosIndependientes = terminosIndependientes;
            _constantesV = constantesV;
            _constantesW = constantesW;
            _constantesX = constantesX;
            _constantesY = constantesY;
            _constantesZ = constantesZ;
            _valorInicial = valorInicial;
            _Resultado.ToleranciaPorcentual = 0.5 * Math.Pow(10, 2 - cifrasSignificativas);
            _Resultado.ErrorRelativoPorcentual1 = 10000;
            _Resultado.ErrorRelativoPorcentual2 = 10000;
            _Resultado.ErrorRelativoPorcentual3 = 10000;
            _Resultado.ErrorRelativoPorcentual4 = 10000;
            _Resultado.ErrorRelativoPorcentual5 = 10000;
            _Resultado.ValorInicial1 = valorInicial[0];
            _Resultado.ValorInicial2 = valorInicial[1];
            _Resultado.ValorInicial3 = valorInicial[2];
            _Resultado.ValorInicial4 = valorInicial[3];
            _Resultado.ValorInicial5 = valorInicial[4];
            _Resultados.Add(new ResultadoJacobi
            {
                ErrorRelativoPorcentual1 = _Resultado.ErrorRelativoPorcentual1,
                ErrorRelativoPorcentual2 = _Resultado.ErrorRelativoPorcentual2,
                ErrorRelativoPorcentual3 = _Resultado.ErrorRelativoPorcentual3,
                ErrorRelativoPorcentual4 = _Resultado.ErrorRelativoPorcentual4,
                ErrorRelativoPorcentual5 = _Resultado.ErrorRelativoPorcentual5,
                ValorInicial1 = _Resultado.ValorInicial1,
                ValorInicial2 = _Resultado.ValorInicial2,
                ValorInicial3 = _Resultado.ValorInicial3,
                ValorInicial4 = _Resultado.ValorInicial4,
                ValorInicial5 = _Resultado.ValorInicial5
            });
            iteraciones();
        }

        private void iteraciones()
        {
            int i = 1;
            while (/*_Resultado.ErrorRelativoPorcentual1 > _Resultado.ToleranciaPorcentual && _Resultado.ErrorRelativoPorcentual2 > _Resultado.ToleranciaPorcentual && */_Resultado.ErrorRelativoPorcentual3 > _Resultado.ToleranciaPorcentual && _Resultado.ErrorRelativoPorcentual4 > _Resultado.ToleranciaPorcentual && _Resultado.ErrorRelativoPorcentual5 > _Resultado.ToleranciaPorcentual)
            {
                _Resultado.ValorInicial1 =
                    _terminosIndependientes[0]
                  + _constantesV[0] * _Resultado.ValorInicial1
                  + _constantesW[0] * _Resultado.ValorInicial2
                  + _constantesX[0] * _Resultado.ValorInicial3
                  + _constantesY[0] * _Resultado.ValorInicial4
                  + _constantesZ[0] * _Resultado.ValorInicial5;
                _Resultado.ValorInicial2 =
                    _terminosIndependientes[1]
                  + _constantesV[1] * _Resultado.ValorInicial1
                  + _constantesW[1] * _Resultado.ValorInicial2
                  + _constantesX[1] * _Resultado.ValorInicial3
                  + _constantesY[1] * _Resultado.ValorInicial4
                  + _constantesZ[1] * _Resultado.ValorInicial5;
                _Resultado.ValorInicial3 =
                    _terminosIndependientes[2]
                  + _constantesV[2] * _Resultado.ValorInicial1
                  + _constantesW[2] * _Resultado.ValorInicial2
                  + _constantesX[2] * _Resultado.ValorInicial3
                  + _constantesY[2] * _Resultado.ValorInicial4
                  + _constantesZ[2] * _Resultado.ValorInicial5;
                _Resultado.ValorInicial4 =
                    _terminosIndependientes[3]
                  + _constantesV[3] * _Resultado.ValorInicial1
                  + _constantesW[3] * _Resultado.ValorInicial2
                  + _constantesX[3] * _Resultado.ValorInicial3
                  + _constantesY[3] * _Resultado.ValorInicial4
                  + _constantesZ[3] * _Resultado.ValorInicial5;
                _Resultado.ValorInicial5 =
                    _terminosIndependientes[4]
                  + _constantesV[4] * _Resultado.ValorInicial1
                  + _constantesW[4] * _Resultado.ValorInicial2
                  + _constantesX[4] * _Resultado.ValorInicial3
                  + _constantesY[4] * _Resultado.ValorInicial4
                  + _constantesZ[4] * _Resultado.ValorInicial5;
                _Resultado.ErrorRelativoPorcentual1 = Math.Abs(((_Resultado.ValorInicial1 - _Resultados.ElementAt(i - 1).ValorInicial1) / _Resultado.ValorInicial1) * 100);
                _Resultado.ErrorRelativoPorcentual2 = Math.Abs(((_Resultado.ValorInicial2 - _Resultados.ElementAt(i - 1).ValorInicial2) / _Resultado.ValorInicial2) * 100);
                _Resultado.ErrorRelativoPorcentual3 = Math.Abs(((_Resultado.ValorInicial3 - _Resultados.ElementAt(i - 1).ValorInicial3) / _Resultado.ValorInicial3) * 100);
                _Resultado.ErrorRelativoPorcentual4 = Math.Abs(((_Resultado.ValorInicial4 - _Resultados.ElementAt(i - 1).ValorInicial4) / _Resultado.ValorInicial4) * 100);
                _Resultado.ErrorRelativoPorcentual5 = Math.Abs(((_Resultado.ValorInicial5 - _Resultados.ElementAt(i - 1).ValorInicial5) / _Resultado.ValorInicial5) * 100);
                _Resultados.Add(new ResultadoJacobi
                {
                    ErrorRelativoPorcentual1 = _Resultado.ErrorRelativoPorcentual1,
                    ErrorRelativoPorcentual2 = _Resultado.ErrorRelativoPorcentual2,
                    ErrorRelativoPorcentual3 = _Resultado.ErrorRelativoPorcentual3,
                    ErrorRelativoPorcentual4 = _Resultado.ErrorRelativoPorcentual4,
                    ErrorRelativoPorcentual5 = _Resultado.ErrorRelativoPorcentual5,
                    ValorInicial1 = _Resultado.ValorInicial1,
                    ValorInicial2 = _Resultado.ValorInicial2,
                    ValorInicial3 = _Resultado.ValorInicial3,
                    ValorInicial4 = _Resultado.ValorInicial4,
                    ValorInicial5 = _Resultado.ValorInicial5
                });
                i++;
            }
        }
        public List<ResultadoJacobi> resultado()
        {
            return _Resultados;
        }
        public override List<double> puntos()
        {
            throw new NotImplementedException();
        }
        public override double[] resultados()
        {
            throw new NotImplementedException();
        }
    }
}
