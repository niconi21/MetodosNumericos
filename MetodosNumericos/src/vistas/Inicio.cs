using MetodosNumericos.src.herramientas.objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetodosNumericos.src.herramientas.objetos.Unidad4;
using MetodosNumericos.src.herramientas.objetos.Unidad_4;
using System.Windows.Forms.DataVisualization.Charting;
using MetodosNumericos.src.herramientas.objetos.Unidad_5;
using MetodosNumericos.src.herramientas.objetos.Unidad_1;
using MetodosNumericos.src.herramientas.objetos.Unidad_2;
using MetodosNumericos.src.herramientas.objetos.Unidad_3;

namespace MetodosNumericos.src.vistas
{
    public partial class Inicio : Form
    {
        private EscrituraLectura _escribirLeer = new EscrituraLectura();
        private Modelo _modelo;
        private int _cantidadImagenes;
        public Inicio()
        {
            InitializeComponent();
            labelInstruccionesUnidad1.Text = "Daremos una breve introducción a los metodos numéricos con una simple explicación de " +
                "\nun programa que nos ayude a calcular las cifras significativas que tiene una cierta cantidad, tambien vamos a calcular la precisión " +
                "\ny la exactitud de un conjunto de datos generados aleatoriamente, además de calcular el valor de euler con series de Maclautrin";
            labelInstruccionesUnidad2.Text = "Los metodos para solución de ecuaciones nos ayudan a encontrar los valores de ciertas" +
                "\nfunciones mediante un metodo fuera de los tradcionales, de esta manera podemos explorar muchas formas de aprender a solucionar" +
                "\n los problemas que nos podemos encontrar.";
            labelInstruccionesUnidad4.Text = "Calcularemos laa integral y la derivada e funciones, es por ello que tenemos dos secciones." +
                "\nEn la primera \"Diferenciación\" podrás encontrar tres cajas de texto, donde introducirás tu función y el valor correspondiente a h y a x0\npara poder calcular la derivada.\n " +
                "\nEn la segunda \"Trapecio simple y compuesto\" podrémos encontrar tres cajas de texto donde se introducirán la funcion y los intervalos\n de esta para poder calcular la integral";
            lblInstruccionesUnidad5.Text = "En esta unidad calcularemos una función a partir de unos puntos datos, es decir, tu nos proporcionarás " +
                "\nlos puntos que tengas, y a partir de ellos calcularemos una funcion polinomial utilizando la interpoalción de Lagrange" +
                "\n\nLas aplicaciones de esto suelen ser en la predicción de datos a partir de un conjunto de datos, como lo puede ser en la economía";
        }

        //////////////
        ///Unidad 1///
        //////////////
        private void buttonCalcularCifrasUnidad1_Click(object sender, EventArgs e)
        {
            String cifra = txtCifraUnidad1.Text;
            
            ModeloCifrasSignificativas cifrasSignificativas = new ModeloCifrasSignificativas(cifra);
            labelCifraUniad1.Text = "Cifra: " + cifra;
            var resultados = cifrasSignificativas.resultados();
            if (resultados[0] != resultados[1])
            {
                labelResultadoCifraSignificativaUnidad1.Text = "Resultado: esta cantidad tiene " + resultados[0] + " y " + resultados[1] + " Cifras significativas";

            }
            else
            {
                labelResultadoCifraSignificativaUnidad1.Text = "Resultado: esta cantidad tiene " + resultados[0] + " Cifras significativas";
            }
            labelNotacionCientificaUnidad1.Text = "Notación cientifica: " + cifrasSignificativas.notacionCientifica();
            ResultadoCifraSignificativas resultadoOperaciones = new ResultadoCifraSignificativas
            {
                numero = cifra,
                cantidadCifras = labelResultadoCifraSignificativaUnidad1.Text,
                notacionCientifica = labelNotacionCientificaUnidad1.Text
            };
            (new EscrituraLectura()).escribirCifrasSignificativas(resultadoOperaciones);
        }
        private void tab_resultados_cifrasSignificativas_unidad1_Click(object sender, EventArgs e)
        {
            try
            {
                this.tabla_cifrasSignificativas.DataSource = (new EscrituraLectura()).leerCifrasSignificativas();
            }
            catch { }
        }
        private void btn_calcular_ExtactitudPrecision_Click(object sender, EventArgs e)
        {
            int limite = int.Parse(txt_limite_exactitudPrecision_unidad1.Text);
            int porcentaje = int.Parse(txt_porcentaje_exactitudPrecision.Text);
            this._modelo = new ModeloExactitudPrecision(limite);
            tabla_exactitudprecision.DataSource = ((ModeloExactitudPrecision)_modelo).getNumeros();
            label_limite_unidad1.Text = limite.ToString();
            var resultados = ((ModeloExactitudPrecision)_modelo).resultados();
            if ((int)resultados[0] > porcentaje)
                label_exactitud_unidad1.Text = "Exactitud: " + resultados[0] + "%\n Es exacto";
            else
                label_exactitud_unidad1.Text = "Exactitud: " + resultados[0] + "%\n No es exacto";
            if((int) resultados[1]>porcentaje)
                label_precision_unidad1.Text = "Precisión: " + resultados[1] + "%\n Es preciso";
            else
                label_precision_unidad1.Text = "Precisión: " + resultados[1] + "%\n No es preciso";
            var puntos = ((ModeloExactitudPrecision)_modelo).getNumeros();
            grafica.Series[0].Points.Clear();
            grafica.Series[0].ChartType = SeriesChartType.Point;
            foreach (var punto in puntos)
            {
                grafica.Series[0].Points.AddY(punto.numero);
            }
            grafica.SaveImage(@"C:\Pruebas\Historial\Unidad 5\Lagrange\" + limite + ".png", ChartImageFormat.Png);
            ResultadoExactitudPrecision resultado = new ResultadoExactitudPrecision
            {
                limite = limite,
                porcentaje = porcentaje,
                exactitud = (int)resultados[0],
                precision = (int)resultados[1]
            };
            (new EscrituraLectura()).escribirExactitudPresisión(resultado);
        }
        private void tabHistorialPrecisionExactitud_Click(object sender, EventArgs e)
        {
            try
            {
                HistorialPrecisionExactitud.DataSource = (new EscrituraLectura()).leerPrecisionExactitud();
            }
            catch { }
        }
        private void btnCalcularSerieMaclaurin_Click(object sender, EventArgs e)
        {
            double exponente = double.Parse(txtExponenteSerieMaclaurin.Text);
            int cifrasSignificativas = int.Parse(txtCifrasSignificativasSerieMaclaurin.Text);
            _modelo = new ModeloSerieMaclaurin(exponente,cifrasSignificativas);
            var resultados = ((ModeloSerieMaclaurin)_modelo).resultado();
            labelResultadosSerieMaclaurin.Text = "Resultados de e^" + exponente;
            tablaSerieMaclaurin.DataSource = resultados;
            grafica.Series[0].ChartType = SeriesChartType.Spline;
            grafica.Series[0].Points.Clear();
            var puntos = ((ModeloSerieMaclaurin)_modelo).puntos();
            foreach (var punto in puntos)
            {
                grafica.Series[0].Points.AddY(punto);
            }
            grafica.SaveImage(@"C:\\Pruebas\Historial\Unidad 1\Serie de Maclaurin\" + "e^" + exponente + " - " + "n vale " + cifrasSignificativas + ".png", ChartImageFormat.Png);
            _escribirLeer.escribirSerieMaclaurin(resultados.ElementAt(resultados.Count-1));
        }
        private void tabHistorialSerieMaclaurin_Click(object sender, EventArgs e)
        {
            try
            {
                this.historialSerieMaclaurin.DataSource = _escribirLeer.leerSerieMaclaurin();
            }
            catch { }
        }
        //////////////
        ///Unidad 2///
        //////////////
        private void btnCalcularBiseccion_Click(object sender, EventArgs e)
        {
            try
            {
                String funcion = txtFuncionBiseccion.Text;
                double intervaloA = double.Parse(txtIntervaloABiseccion.Text);
                double intervaloB = double.Parse(txtIntervaloBBiseccion.Text);
                int cifrasSignificativas = int.Parse(txtCifrasBiseccion.Text);
                _modelo = new ModeloBiseccion(funcion, intervaloA, intervaloB, cifrasSignificativas);
                lblResultadoBiseccion.Text = "Resultado de: " + funcion;
                var resultados = ((ModeloBiseccion)_modelo).resultado();
                tablaBiseccion.DataSource = resultados;
                grafica.Series[0].ChartType = SeriesChartType.Spline;
                grafica.Series[0].Points.Clear();
                var puntos = ((ModeloBiseccion)_modelo).resultados();
                foreach (var punto in puntos)
                {
                    grafica.Series[0].Points.AddY(punto);
                }
                grafica.SaveImage(@"C:\\Pruebas\Historial\Unidad 2\Biseccion\" + funcion + "-intervalo(" + intervaloA + "," + intervaloB + ").png", ChartImageFormat.Png);
                _escribirLeer.escribirBiseccion(resultados.ElementAt(resultados.Count - 1));
            }catch{
                MessageBox.Show("No se puede calcular");
            }
        }
        private void tabHistorialBiseccion_Click(object sender, EventArgs e)
        {
            try
            {
                List<ResultadoModeloBireccion> resultados = _escribirLeer.leerBiseccion();
                HistorialBiseccion.DataSource = resultados;
            }
            catch { }
        }
        private void btnCalcularNewtonRapshon_Click(object sender, EventArgs e)
        {
            String funcion = txtFuncionNewtonRapshon.Text;
            double valorInicial = double.Parse(txtValorInicialNewtonRapshon.Text);
            int cifrasSignificativas = int.Parse(txtCifrasSignificativasNewtonRapshon.Text);
            _modelo = new ModeloNewtonRapshon(funcion, valorInicial, cifrasSignificativas);
            var resultados = ((ModeloNewtonRapshon)_modelo).resultado();
            tablaNewtonRapshon.DataSource = resultados;
            grafica.Series[0].ChartType = SeriesChartType.Spline;
            grafica.Series[0].Points.Clear();
            var puntos = ((ModeloNewtonRapshon)_modelo).puntos();
            foreach (var punto in puntos)
            {
                grafica.Series[0].Points.AddY(punto);
            }
            grafica.SaveImage(@"C:\\Pruebas\Historial\Unidad 2\Newton-Rapshon\" + funcion + "-Valor Inicial" + valorInicial + ".png", ChartImageFormat.Png);
            _escribirLeer.escribirNewtonRapshon(resultados.ElementAt(resultados.Count - 1));
        }
        private void tabHistorialNewtonRapshon_Click(object sender, EventArgs e)
        {
            try
            {
                historialNewtonRapshon.DataSource = _escribirLeer.leerNewtonRapshon();
            }
            catch { }
        }

        //////////////
        ///Unidad 3///
        //////////////
        private void btnCalcularJacobi_Click(object sender, EventArgs e)
        {
            double[] terminoIndependiente = new double[5];
            double[] constanteV = new double[5];
            double[] constanteW = new double[5];
            double[] constanteX = new double[5];
            double[] constanteY = new double[5];
            double[] constanteZ = new double[5];
            double[] valorInicial = new double[5];
            for (int i = 0; i < 5; i++)
            {
                terminoIndependiente[i] = double.Parse(((TextBox)flowContenedorConstantes.Controls[0 + (7 * i)]).Text);
                constanteV[i] = double.Parse(((TextBox)flowContenedorConstantes.Controls[1 + (7 * i)]).Text);
                constanteW[i] = double.Parse(((TextBox)flowContenedorConstantes.Controls[2 + (7 * i)]).Text);
                constanteX[i] = double.Parse(((TextBox)flowContenedorConstantes.Controls[3 + (7 * i)]).Text);
                constanteY[i] = double.Parse(((TextBox)flowContenedorConstantes.Controls[4 + (7 * i)]).Text);
                constanteZ[i] = double.Parse(((TextBox)flowContenedorConstantes.Controls[5 + (7 * i)]).Text);
                valorInicial[i] = double.Parse(((TextBox)flowContenedorConstantes.Controls[6 + (7 * i)]).Text);
            }
            int cifrasSignificativas = int.Parse(txtCifrasSignificativasJacobi.Text);
            _modelo = new ModeloJacobi(cifrasSignificativas, terminoIndependiente, constanteV, constanteW, constanteX, constanteY, constanteZ, valorInicial);
            var resultados = ((ModeloJacobi)_modelo).resultado();
            tablaJacobi.DataSource = resultados;
            _escribirLeer.escribirJacobi(resultados.ElementAt(resultados.Count - 1));
        }
        private void tabJacobi_Click(object sender, EventArgs e)
        {
            try
            {
                historialJacobi.DataSource = _escribirLeer.leerJacobi();
            }
            catch { }
        }
            
        private void btnCalcularGaussSendel_Click(object sender, EventArgs e)
        {
            double[] terminoIndependiente = new double[5];
            double[] constanteV = new double[5];
            double[] constanteW = new double[5];
            double[] constanteX = new double[5];
            double[] constanteY = new double[5];
            double[] constanteZ = new double[5];
            double[] valorInicial = new double[5];
            for (int i = 0; i < 5; i++)
            {
                terminoIndependiente[i] = double.Parse(((TextBox)flowContenedorConstantesGauss.Controls[0 + (7 * i)]).Text);
                constanteV[i] = double.Parse(((TextBox)flowContenedorConstantesGauss.Controls[1 + (7 * i)]).Text);
                constanteW[i] = double.Parse(((TextBox)flowContenedorConstantesGauss.Controls[2 + (7 * i)]).Text);
                constanteX[i] = double.Parse(((TextBox)flowContenedorConstantesGauss.Controls[3 + (7 * i)]).Text);
                constanteY[i] = double.Parse(((TextBox)flowContenedorConstantesGauss.Controls[4 + (7 * i)]).Text);
                constanteZ[i] = double.Parse(((TextBox)flowContenedorConstantesGauss.Controls[5 + (7 * i)]).Text);
                valorInicial[i] = double.Parse(((TextBox)flowContenedorConstantesGauss.Controls[6 + (7 * i)]).Text);
            }
            int cifrasSignificativas = int.Parse(txtCifrasSignificativasGaussSendel.Text);
            _modelo = new ModeloGaussSendel(cifrasSignificativas, terminoIndependiente, constanteV, constanteW, constanteX, constanteY, constanteZ, valorInicial);
            var resultados = ((ModeloGaussSendel)_modelo).resultado();
            tablaGaussSendel.DataSource = resultados;
            _escribirLeer.escribirGaussSendel(resultados.ElementAt(resultados.Count - 1));
            
        }
        private void tabGaussSendel_Click(object sender, EventArgs e)
        {
            try
            {
                HistorialGaussSendel.DataSource = _escribirLeer.leerGaussSendel();
            }
            catch { }
        }
        //////////////
        ///Unidad 4///
        //////////////

        private void btnDiferenciacionUnidad4_Click(object sender, EventArgs e)
        {
            String funcion = txtFuncionUnidad4.Text;
            double valorH = double.Parse(txtValorHDiferenciacionUnidad4.Text);
            double valorX0 = double.Parse(txtValorX0DiferenciacionUnidad4.Text);
            this._modelo = new ModeloDiferenciacionNumerica(funcion, valorX0, valorH);
            var resultados = this._modelo.resultados();
            lblResultadoFuncionDiferenciacionUnidad4.Text = "Función: " + funcion;
            lblDosPuntosUnidad4.Text = "Dos puntos:" +
                                       "\nInfinita prograsiva = " + resultados[0] +
                                       "\nInfinita centrada = " + resultados[2] +
                                       "\nInfinita regresiva = " + resultados[4];
            lblTresPuntosUnidad4.Text = "Tres Puntos:" +
                                       "\nInfinita prograsiva = " + resultados[1] +
                                       "\nInfinita centrada = " + resultados[2] +
                                       "\nInfinita regresiva = " + resultados[5];
            grafica.Series[0].ChartType = SeriesChartType.Spline;
            grafica.Series[0].Points.Clear();
            var puntos = this._modelo.puntos();
            int j = 0;
            for (int i = -3; i < 3; i++)
            {
                grafica.Series[0].Points.AddXY(i, puntos[j++]);
            }

            Resultados guardarDatos = new Resultados
            {
                Funcion = funcion,
                DosPuntosInfinitasProgresivas = resultados[0],
                TresPuntosInfinitasProgresivas = resultados[1],
                DosPuntosInfinitasCentradas = resultados[2],
                TresPuntosInfinitasCentradas = resultados[3],
                DosPuntosInfinitasRegresivas = resultados[4],
                TresPuntosInfinitasRegresivas = resultados[5],
            }; 
            grafica.SaveImage(@"C:\Pruebas\Historial\Unidad 4\Diferenciacion Numerica\" + funcion + ".png", ChartImageFormat.Png);
            _escribirLeer.escribirDiferenciacionUnidad4(guardarDatos);

        }
        private void tabHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                var reultados = _escribirLeer.leerDiferenciacionUnidad4();
                historialDiferenciacionUnidad4.DataSource = reultados;
            }
            catch { }
        }
        private void btnTrapecioUnidad4_Click(object sender, EventArgs e)
        {
            String funcion = txtFuncionUnidad4.Text;
            double intervaloA = double.Parse(txtIntervaloAUnidad4.Text);
            double intervaloB = double.Parse(txtIntervaloBUnidad4.Text);
            int valorN = int.Parse(txtValorNTrapecio.Text);
            this._modelo = new ModeloTrapecio(funcion, intervaloA, intervaloB, valorN);
            var resultados = this._modelo.resultados();
            lblFuncionTrapecioUnidad4.Text = "Función: " + funcion;
            lblTrapecioSimple.Text = "Trapecio Simple: = " + resultados[0];
            lblTrapecioCompuesto.Text = "Trapecio Compuesto: = " + resultados[1];

            grafica.Series[0].ChartType = SeriesChartType.Area;
            grafica.Series[0].Points.Clear();
            var puntos = this._modelo.puntos();
            int j = 0;
            for (int i = -3; i < 3; i++)
            {
                grafica.Series[0].Points.AddXY(i, puntos[j++]);
            }
            ResultadosTrapecio guardarResultados=new ResultadosTrapecio{
                Funcion = funcion,
                Simple = resultados[0],
                Compuesto = resultados[1]
            };
            _escribirLeer.escribirTrapecioUnidad4(guardarResultados);
            grafica.SaveImage(@"C:\Pruebas\Historial\Unidad 4\Trapecio" + funcion + ".png", ChartImageFormat.Png);
        }
        private void tabHistorialTrapecio_Click(object sender, EventArgs e)
        {
            try
            {
                var resultados = _escribirLeer.leerTrapecioUnidad4();
                historialTrapecioUnidad4.DataSource = resultados;
            }
            catch {}
        }
        
        //////////////
        ///Unidad 5///
        //////////////
        private void btnCalcularUnidad5_Click(object sender, EventArgs e)
        {
            String textoValoresX = txtValoresXUnidad5.Text;
            String textoValoresY = txtValoresYUnidad5.Text;

            var valoresX = textoValoresX.Split(',');
            var valoresY = textoValoresY.Split(',');
            double[] arrelgoX = new double[valoresX.Length];
            for (int i = 0; i < valoresX.Length; i++)
            {
                arrelgoX[i] = double.Parse(valoresX[i]);
            }
            double[] arrelgoY = new double[valoresY.Length];
            for (int i = 0; i < valoresY.Length; i++)
            {
                arrelgoY[i] = double.Parse(valoresY[i]);
            }

            _modelo = new ModeloLagrange(arrelgoX, arrelgoY);
            String funcion = ((ModeloLagrange)_modelo).resultadoFuncion();
            lblFuncionUnidad5.Text = funcion;
            grafica.Series[0].ChartType = SeriesChartType.Spline;
            grafica.Series[0].Points.Clear();
            
            for (int i = 0; i < arrelgoX.Length; i++)
            {
                grafica.Series[0].Points.AddXY(arrelgoX[i], arrelgoY[i]);
            }
            ResultadoLangrage resultados = new ResultadoLangrage();
            resultados.Funcion = funcion;
            resultados.puntosX = arrelgoX;
            resultados.puntosY = arrelgoY;
            _escribirLeer.escribirLangrageUnidad5(resultados);
            _cantidadImagenes++;
            grafica.SaveImage(@"C:\Pruebas\Historial\Unidad 5\Lagrange\" + _cantidadImagenes + ".png", ChartImageFormat.Png);
        }
        private void tabHistoialUnidad5_Click(object sender, EventArgs e)
        {
            try
            {
                var resultados = _escribirLeer.leerLangrageUnidad5();
                historialUnidad5.DataSource = resultados;
            }
            catch { }
            
        }

        

        
        

        
    }
}
