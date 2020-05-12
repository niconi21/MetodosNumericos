using MetodosNumericos.src.herramientas.objetos.Unidad_1;
using MetodosNumericos.src.herramientas.objetos.Unidad_2;
using MetodosNumericos.src.herramientas.objetos.Unidad_3;
using MetodosNumericos.src.herramientas.objetos.Unidad_4;
using MetodosNumericos.src.herramientas.objetos.Unidad_5;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos.src.herramientas.objetos
{
    public class EscrituraLectura
    {
        private String _ruta = @"C:\\Pruebas\Historial\";
        ////////////////
        ////unidad 1////
        ////////////////
        public void escribirCifrasSignificativas(ResultadoCifraSignificativas resultados)
        {
            StreamWriter sw = new StreamWriter(_ruta + "CifrasSignificativas_Unidad1.txt",true);
            sw.WriteLine(resultados.numero + "," + resultados.cantidadCifras + "," + resultados.notacionCientifica);
            sw.Close();
        }
        public List<ResultadoCifraSignificativas> leerCifrasSignificativas()
        {
            StreamReader sr = new StreamReader(_ruta + "CifrasSignificativas_Unidad1.txt");
            var lineas = sr.ReadToEnd().Split('\n');
            List<ResultadoCifraSignificativas> resultados = new List<ResultadoCifraSignificativas>();
            foreach (var linea in lineas)
            {
                if (!linea.Equals(""))
                {
                    var datos = linea.Split(',');
                    resultados.Add(new ResultadoCifraSignificativas
                    {
                        numero = datos[0],
                        cantidadCifras = datos[1],
                        notacionCientifica = datos[2]
                    });
                }
            }
            sr.Close();
            return resultados;
        }
        public void escribirExactitudPresisión(ResultadoExactitudPrecision resultados)
        {
            StreamWriter sw = new StreamWriter(_ruta + "PrecisiónExactitud_Unidad1.txt", true);
            sw.WriteLine(resultados.limite+ "," + resultados.porcentaje+ "," + resultados.precision + "," + resultados.exactitud);
            sw.Close();
        }
        public List<ResultadoExactitudPrecision> leerPrecisionExactitud()
        {
            StreamReader sr = new StreamReader(_ruta + "PrecisiónExactitud_Unidad1.txt");
            var lineas = sr.ReadToEnd().Split('\n');
            List<ResultadoExactitudPrecision> resultados = new List<ResultadoExactitudPrecision>();
            foreach (var linea in lineas)
            {
                if (!linea.Equals(""))
                {
                    var datos = linea.Split(',');
                    resultados.Add(new ResultadoExactitudPrecision
                    {
                        limite = int.Parse(datos[0]),
                        porcentaje = int.Parse(datos[1]),
                        precision = int.Parse(datos[2]),
                        exactitud = int.Parse(datos[3]),
                    });
                }
            }
            sr.Close();
            return resultados;
        }
        public void escribirSerieMaclaurin(ResultadoSerieMaclaurin resultado)
        {
            StreamWriter sw = new StreamWriter(_ruta + "SerieMaclaurin_Unidad1.txt", true);
            sw.WriteLine(resultado.exponente + "," +
                         resultado.valorVerdadero + "," +
                         resultado.valorAproximado + "," +
                         resultado.ErrorVerdadero + "," +
                         resultado.ErrorPorcental + "," +
                         resultado.ErrorRelativoPorcentual+ "," +
                         resultado.ToleranciaPorcentual);
            sw.Close();
        }
        public List<ResultadoSerieMaclaurin> leerSerieMaclaurin()
        {
            StreamReader sr = new StreamReader(_ruta + "SerieMaclaurin_Unidad1.txt", true);
            var lineas = sr.ReadToEnd().Split('\n');
            List<ResultadoSerieMaclaurin> resultados = new List<ResultadoSerieMaclaurin>();
            foreach (var linea in lineas)
            {
                if (!linea.Equals(""))
                {
                    var datos = linea.Split(',');
                    resultados.Add(new ResultadoSerieMaclaurin
                    {
                        exponente = double.Parse(datos[0]),
                        valorVerdadero = double.Parse(datos[1]),
                        valorAproximado = double.Parse(datos[2]),
                        ErrorVerdadero = double.Parse(datos[3]),
                        ErrorPorcental = double.Parse(datos[4]),
                        ErrorRelativoPorcentual = double.Parse(datos[5]),
                        ToleranciaPorcentual = double.Parse(datos[6]),
                    });
                }
            }
            sr.Close();
            return resultados;
        }
        ////////////////
        ////unidad 2////
        ////////////////
        public List<ResultadoModeloBireccion> leerBiseccion()
        {
            List<ResultadoModeloBireccion> resultados = new List<ResultadoModeloBireccion>();
            StreamReader sr = new StreamReader(_ruta + "Biseccion_Unidad2.txt");
            var lineas = sr.ReadToEnd().Split('\n');
            foreach (var linea in lineas)
            {
                if (!linea.Equals(""))
                {
                    var datos = linea.Split(',');
                    resultados.Add(new ResultadoModeloBireccion
                    {
                        Funcion = datos[0],
                        IntervaloA = double.Parse(datos[1]),
                        IntervaloB = double.Parse(datos[2]),
                        AproximacionRaiz = double.Parse(datos[3])
                    });
                }
            }
            sr.Close();
            return resultados;
        }

        public void escribirBiseccion(ResultadoModeloBireccion resultados)
        {
            StreamWriter sr = new StreamWriter(_ruta + "Biseccion_Unidad2.txt", true);
            sr.WriteLine(resultados.Funcion + "," +
                resultados.IntervaloA + "," +
                resultados.IntervaloB + "," +
                resultados.AproximacionRaiz);
            sr.Close();
        }
        public void escribirNewtonRapshon(ResultadoNewtonRapshon resultados)
        {
            StreamWriter sr = new StreamWriter(_ruta + "NewtonRapshon_Unidad2.txt", true);
            sr.WriteLine(resultados.Funcion + "," +
                resultados.Derivada.unirTerminos() + "," +
                resultados.valorX + "," +
                resultados.ErrorRelativoPorcentual + "," +
                resultados.ToleranciaPorcentual);
            sr.Close();
        }
        public List<ResultadoNewtonRapshon> leerNewtonRapshon()
        {
            List<ResultadoNewtonRapshon> resultados = new List<ResultadoNewtonRapshon>();
            StreamReader sr = new StreamReader(_ruta + "NewtonRapshon_Unidad2.txt");
            var lineas = sr.ReadToEnd().Split('\n');
            foreach (var linea in lineas)
            {
                if (!linea.Equals(""))
                {
                    var datos = linea.Split(',');
                    resultados.Add(new ResultadoNewtonRapshon
                    {
                        Funcion = datos[0],
                        derivada = datos[1],
                        valorX = double.Parse(datos[2]),
                        ErrorRelativoPorcentual = double.Parse(datos[3]),
                        ToleranciaPorcentual = double.Parse(datos[4])
                    });
                }
            }
            sr.Close();
            return resultados;
        }

        ////////////////
        ////unidad 3////
        ////////////////
        public void escribirJacobi(ResultadoJacobi resultados)
        {
            StreamWriter sr = new StreamWriter(_ruta + "Jacobi_unidad3.txt", true);
            sr.WriteLine(resultados.ValorInicial1 + "," +
                         resultados.ValorInicial2 + "," +
                         resultados.ValorInicial3 + "," +
                         resultados.ValorInicial4 + "," +
                         resultados.ValorInicial5 + "," +
                         resultados.ErrorRelativoPorcentual1 + "," +
                         resultados.ErrorRelativoPorcentual2 + "," +
                         resultados.ErrorRelativoPorcentual3 + "," +
                         resultados.ErrorRelativoPorcentual4 + "," +
                         resultados.ErrorRelativoPorcentual5 + "," +
                         resultados.ToleranciaPorcentual);
            sr.Close();
        }
        public List<ResultadoJacobi> leerJacobi()
        {
            List<ResultadoJacobi> resultados = new List<ResultadoJacobi>();
            StreamReader sr = new StreamReader(_ruta + "Jacobi_unidad3.txt");
            var lineas = sr.ReadToEnd().Split('\n');
            foreach (var linea in lineas)
            {
                if (!linea.Equals(""))
                {
                    var datos = linea.Split(',');
                    resultados.Add(new ResultadoJacobi
                    {
                        ValorInicial1 = double.Parse(datos[0]),
                        ValorInicial2 = double.Parse(datos[1]),
                        ValorInicial3 = double.Parse(datos[2]),
                        ValorInicial4 = double.Parse(datos[3]),
                        ValorInicial5 = double.Parse(datos[4]),
                        ErrorRelativoPorcentual1 = double.Parse(datos[5]),
                        ErrorRelativoPorcentual2 = double.Parse(datos[6]),
                        ErrorRelativoPorcentual3 = double.Parse(datos[7]),
                        ErrorRelativoPorcentual4 = double.Parse(datos[8]),
                        ErrorRelativoPorcentual5 = double.Parse(datos[9]),
                        ToleranciaPorcentual = double.Parse(datos[10])
                    });
                }
            }
            sr.Close();
            return resultados;
        }
        internal void escribirGaussSendel(ResultadoJacobi resultados)
        {
            StreamWriter sr = new StreamWriter(_ruta + "GaussSendel_unidad3.txt", true);
            sr.WriteLine(resultados.ValorInicial1 + "," +
                         resultados.ValorInicial2 + "," +
                         resultados.ValorInicial3 + "," +
                         resultados.ValorInicial4 + "," +
                         resultados.ValorInicial5 + "," +
                         resultados.ErrorRelativoPorcentual1 + "," +
                         resultados.ErrorRelativoPorcentual2 + "," +
                         resultados.ErrorRelativoPorcentual3 + "," +
                         resultados.ErrorRelativoPorcentual4 + "," +
                         resultados.ErrorRelativoPorcentual5 + "," +
                         resultados.ToleranciaPorcentual);
            sr.Close();
        }
        public List<ResultadoJacobi> leerGaussSendel()
        {
            List<ResultadoJacobi> resultados = new List<ResultadoJacobi>();
            StreamReader sr = new StreamReader(_ruta + "GaussSendel_unidad3.txt");
            var lineas = sr.ReadToEnd().Split('\n');
            foreach (var linea in lineas)
            {
                if (!linea.Equals(""))
                {
                    var datos = linea.Split(',');
                    resultados.Add(new ResultadoJacobi
                    {
                        ValorInicial1 = double.Parse(datos[0]),
                        ValorInicial2 = double.Parse(datos[1]),
                        ValorInicial3 = double.Parse(datos[2]),
                        ValorInicial4 = double.Parse(datos[3]),
                        ValorInicial5 = double.Parse(datos[4]),
                        ErrorRelativoPorcentual1 = double.Parse(datos[5]),
                        ErrorRelativoPorcentual2 = double.Parse(datos[6]),
                        ErrorRelativoPorcentual3 = double.Parse(datos[7]),
                        ErrorRelativoPorcentual4 = double.Parse(datos[8]),
                        ErrorRelativoPorcentual5 = double.Parse(datos[9]),
                        ToleranciaPorcentual = double.Parse(datos[10])
                    });
                }
            }
            sr.Close();
            return resultados;
        }
        ////////////////
        ////unidad 4////
        ////////////////
        public void escribirDiferenciacionUnidad4(Resultados resultados)
        {
            StreamWriter sr = new StreamWriter(_ruta + "Diferenciacion_Unidad4.txt", true);
            sr.WriteLine(resultados.Funcion + "," +
                         resultados.DosPuntosInfinitasProgresivas + "," +
                         resultados.TresPuntosInfinitasProgresivas + "," +
                         resultados.DosPuntosInfinitasCentradas + "," +
                         resultados.TresPuntosInfinitasCentradas + "," +
                         resultados.DosPuntosInfinitasRegresivas + "," +
                         resultados.TresPuntosInfinitasRegresivas);
            sr.Close();
        }
        public List<Resultados> leerDiferenciacionUnidad4()
        {
            List<Resultados> resultados = new List<Resultados>();
            StreamReader sr = new StreamReader(_ruta + "Diferenciacion_Unidad4.txt");
            var archivo = sr.ReadToEnd().Split('\n');
            sr.Close();
            foreach (var linea in archivo)
            {
                if (!linea.Equals(""))
                {
                    var datos = linea.Split(',');
                    resultados.Add(new Resultados
                    {
                        Funcion = datos[0],
                        DosPuntosInfinitasProgresivas = double.Parse(datos[1]),
                        TresPuntosInfinitasProgresivas = double.Parse(datos[2]),
                        DosPuntosInfinitasCentradas = double.Parse(datos[3]),
                        TresPuntosInfinitasCentradas = double.Parse(datos[4]),
                        DosPuntosInfinitasRegresivas = double.Parse(datos[5]),
                        TresPuntosInfinitasRegresivas = double.Parse(datos[6]),
                    });
                }
            }   
            return resultados;
        }
        public void escribirTrapecioUnidad4(ResultadosTrapecio resultados)
        {
            StreamWriter sw = new StreamWriter(_ruta + "Trapecio_unidad4.txt",true);
            sw.WriteLine(resultados.Funcion+","+
                        resultados.Simple+","+
                        resultados.Compuesto);
            sw.Close();
        }
        public List<ResultadosTrapecio> leerTrapecioUnidad4()
        {
            List<ResultadosTrapecio> resultados = new List<ResultadosTrapecio>();
            StreamReader sr = new StreamReader(_ruta + "Trapecio_unidad4.txt");
            var archivo = sr.ReadToEnd().Split('\n');
            sr.Close();
            foreach (var linea in archivo)
            {
                if (!linea.Equals(""))
                {
                    var datos = linea.Split(',');
                    resultados.Add(new ResultadosTrapecio
                    {
                        Funcion = datos[0],
                        Simple = double.Parse(datos[1]),
                        Compuesto = double.Parse(datos[2])
                    });
                }
            }
            return resultados;
        }
        ////////////////
        ////unidad 5////
        ////////////////
        public void escribirLangrageUnidad5(ResultadoLangrage resultados)
        {
            String datos = resultados.Funcion;
            for (int i = 0; i < resultados.puntosX.Length; i++)
            {
                datos += resultados.puntosX[i] + ",";
            }
            for (int i = 0; i < resultados.puntosY.Length; i++)
            {
                datos += resultados.puntosY[i];
                if (i != resultados.puntosY.Length - 1)
                {
                    datos += ",";
                }
            }
            StreamWriter sw = new StreamWriter(_ruta + "Langrage_Unidad5.txt", true);
            sw.WriteLine(datos);
            sw.Close();
        }
        public List<ResultadoLangrage> leerLangrageUnidad5()
        {
            List<ResultadoLangrage> resultados = new List<ResultadoLangrage>();
            StreamReader sr = new StreamReader(_ruta + "Langrage_Unidad5.txt");
            var archivo = sr.ReadToEnd().Split('\n');
            sr.Close();
            foreach (var linea in archivo)
            {
                if (!linea.Equals(""))
                {
                    var datos = linea.Split(',');
                    ResultadoLangrage resultado= new ResultadoLangrage();
                    int longitud = datos.Length - 1;
                    longitud /= 2;
                    double[] puntosX = new double[longitud];
                    double[] puntosY = new double[longitud];
                    for (int i = 0; i < longitud; i++)
                    {
                        puntosX[i] = double.Parse(datos[i + 1]);
                    }
                    
                    for (int i = 0; i < longitud; i++)
                    {
                        puntosX[i] = double.Parse(datos[i + longitud + 1]);
                    }
                    resultado.Funcion = datos[0];
                    resultado.puntosX = puntosX;
                    resultado.puntosY = puntosY;
                    resultados.Add(resultado);
                }
            }
            return resultados;
        }








     
    }
}
