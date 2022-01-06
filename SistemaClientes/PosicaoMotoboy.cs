using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaClientes
{
    public partial class PosicaoMotoboy : Form
    {
        public PosicaoMotoboy()
        {
            InitializeComponent();
        }
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "tJVQSamSvHRtZguzUcn0h3YfPGFoEjl37nI2uNDD",
            BasePath = "https://sandra-foods-34d79-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;

        private void PosicaoMotoboy_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
            }
            catch
            {
                MessageBox.Show("Não foi possível conectar ao Servidor.\nVerifique sua conexão com a internet e tente acessar o sistema novamente.", "Erro");
                this.Close();
            }
            criaListenerPosicaoMotoboy();
            gMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMap.Position = new PointLatLng(-26.27752278742405, -49.385321717780755);
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(-26.27752278742405, -49.385321717780755),
            new Bitmap("C:\\Program Files (x86)\\SSoft\\Sandra Foods\\IconeMotoboy.png"));
            marker.ToolTipText = "Motoboy";
            marker.ToolTip.Fill = Brushes.White;
            marker.ToolTip.Foreground = Brushes.Black;
            marker.ToolTip.Stroke = Pens.Black;
            marker.ToolTip.TextPadding = new Size(20, 20);
            markersOverlay.Markers.Add(marker);
            gMap.Overlays.Add(markersOverlay);
            gMap.ShowCenter = false;
            gMap.DragButton = MouseButtons.Left;
        }
        async void criaListenerPosicaoMotoboy()
        {
            EventStreamResponse response = await client.OnAsync(@"posicao-motoboy",
                    added: (s, args, context) =>
                    {
                        recarregaPosicaoMotoboy();
                    },
                    changed: (s, args, context) =>
                    {
                        recarregaPosicaoMotoboy();
                    },
                    removed: (s, args, context) =>
                    {

                    });
        }
        public void recarregaPosicaoMotoboy()
        {
            gMap.Overlays.Clear();
            FirebaseResponse responseLat = client.Get(@"posicao-motoboy\latitude");
            FirebaseResponse responseLon = client.Get(@"posicao-motoboy\longitude");
            if (responseLat.Body == null || responseLat.Body == "null")
            {
                return;
            }
            Double lati = Convert.ToDouble(responseLat.Body.ToString().Replace(".", ","));
            Double longi = Convert.ToDouble(responseLon.Body.ToString().Replace(".", ","));
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            markersOverlay.Clear();
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lati, longi),
            new Bitmap("C:\\Program Files (x86)\\SSoft\\Sandra Foods\\IconeMotoboy.png"));
            marker.ToolTipText = "Motoboy";
            marker.ToolTip.Fill = Brushes.White;
            marker.ToolTip.Foreground = Brushes.Black;
            marker.ToolTip.Stroke = Pens.Black;
            marker.ToolTip.TextPadding = new Size(20, 20);
            markersOverlay.Markers.Add(marker);
            gMap.Overlays.Add(markersOverlay);
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate () {
                    gMap.ZoomAndCenterMarkers("markers");
                    gMap.Zoom = 18;
                });
            }
            else
            {
                gMap.ZoomAndCenterMarkers("markers");
                gMap.Zoom = 18;
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCentralizar_Click(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate () {
                    gMap.ZoomAndCenterMarkers("markers");
                    gMap.Zoom = 18;
                });
            }
            else
            {
                gMap.ZoomAndCenterMarkers("markers");
                gMap.Zoom = 18;
            }
        }
    }
}
