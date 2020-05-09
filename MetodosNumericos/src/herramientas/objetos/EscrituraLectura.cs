using MetodosNumericos.src.herramientas.objetos.Unidad_1;
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
                        DosPuntosInfinitasProgresivas = float.Parse(datos[1]),
                        TresPuntosInfinitasProgresivas = float.Parse(datos[2]),
                        DosPuntosInfinitasCentradas = float.Parse(datos[3]),
                        TresPuntosInfinitasCentradas = float.Parse(datos[4]),
                        DosPuntosInfinitasRegresivas = float.Parse(datos[5]),
                        TresPuntosInfinitasRegresivas = float.Parse(datos[6]),
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
                        Simple = float.Parse(datos[1]),
                        Compuesto = float.Parse(datos[2])
                    });
                }
            }
            return resultados;
        }
        ////////////////
        ////unidad 4////
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
                    float[] puntosX = new float[longitud];
                    float[] puntosY = new float[longitud];
                    for (int i = 0; i < longitud; i++)
                    {
                        puntosX[i] = float.Parse(datos[i + 1]);
                    }
                    
                    for (int i = 0; i < longitud; i++)
                    {
                        puntosX[i] = float.Parse(datos[i + longitud + 1]);
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
