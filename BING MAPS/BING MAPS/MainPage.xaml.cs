using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using System.Collections.ObjectModel;
using Windows.Storage.Streams;
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BING_MAPS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class MainPage : Page
    {
        RandomAccessStreamReference mapIconStrean;
        ObservableCollection<TipeMap> tipemaplist = new ObservableCollection<TipeMap>();
        ObservableCollection<LevelZoom> levelzoomlist = new ObservableCollection<LevelZoom>();
        public MainPage()
        {
            this.InitializeComponent();
            tipemaplist.Add(new TipeMap { Nama="Road",Kode= MapStyle.Road });
            tipemaplist.Add(new TipeMap { Nama = "Aerial", Kode = MapStyle.Aerial });
            tipemaplist.Add(new TipeMap { Nama = "AerialWithRoads", Kode = MapStyle.Aerial3DWithRoads });
            tipemaplist.Add(new TipeMap { Nama = "Terrain", Kode = MapStyle.Terrain});
            tipemaplist.Add(new TipeMap { Nama = "Aerial3D", Kode = MapStyle.Aerial3D });
            tipemaplist.Add(new TipeMap { Nama = "Aerial3DWithRoads", Kode = MapStyle.Aerial3DWithRoads });
            combostyle.ItemsSource = tipemaplist;

            levelzoomlist.Add(new LevelZoom { Nama = "1x", Kode = 1 });
            levelzoomlist.Add(new LevelZoom { Nama = "5x", Kode = 5 });
            levelzoomlist.Add(new LevelZoom { Nama = "10x", Kode = 10 });
            levelzoomlist.Add(new LevelZoom { Nama = "15x", Kode = 15 });
            levelzoomlist.Add(new LevelZoom { Nama = "20x", Kode = 20 });
            combozoom.ItemsSource = levelzoomlist;

            MapControl1.Loaded += MapControl_Loaded;
            mapIconStrean = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assests/MapPin.png"));


        }

        private void MapControl_Loaded(object sender, RoutedEventArgs e)
        {
            MapControl1.MapServiceToken = "ZOIsTgPzmcup0qy5gZ2e~bgLFX1LAnJrkxYFU5ue_iA~AjuP65xpgmXybft4W8kH0v-uG2QcEqFUKHYi7gCrTtf66p24phdhLHLzQKEq2OSD";
            MapControl1.Center = new Geopoint(new BasicGeoposition()
            {
                Latitude = -6.914744,
                Longitude = 107.609810
            });
            MapControl1.Style = MapStyle.Road;
            MapControl1.ZoomLevel = 12;
            MapControl1.LandmarksVisible = true;

            //konfigurasi mapicon
            MapIcon mapicon1 = new MapIcon();
            //untuk mengatur latitude dan longitude dari point
            //Geopoint myPoint = new Geopoint(new BasicGeoposition() { Latitude = 51, Longitude = 0 });
            mapicon1.Location = MapControl1.Center;
            mapicon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
            mapicon1.Title = "Bandung";
            mapicon1.Image = mapIconStrean;
            mapicon1.ZIndex = 2;
            //menambahkan icon map ke dalam mapcontrol
            MapControl1.MapElements.Add(mapicon1);
            //panggil fungsi
            //tambahPolygon();

            tambahpolyline();
        }

        private void tambahpolyline()
        {
            double centerLatitude = MapControl1.Center.Position.Latitude;
            double centerLongitude = MapControl1.Center.Position.Longitude;
            MapPolyline mapPolyline = new MapPolyline();
            mapPolyline.Path = new Geopath(new List<BasicGeoposition>() {
                new BasicGeoposition() {Latitude=centerLatitude-0.0005, Longitude=centerLongitude-0.001 },
                new BasicGeoposition() {Latitude=centerLatitude+0.0005, Longitude=centerLongitude+0.001 },
            });

            mapPolyline.StrokeColor = Colors.Black;
            mapPolyline.StrokeThickness = 3;
            mapPolyline.StrokeDashed = true;
            MapControl1.MapElements.Add(mapPolyline);
        }

        private void combostyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TipeMap selectedmap = combostyle.SelectedItem as TipeMap;
            MapControl1.Style = selectedmap.Kode;
        }

        private void combozoom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LevelZoom selectedzoom = combozoom.SelectedItem as LevelZoom;
            MapControl1.ZoomLevel = selectedzoom.Kode;
        }

        private void tambahPolygon()
        {
            MapPolygon polygon = new MapPolygon();
            //ambil latitude dan longitude center map
            double centerLatitude = MapControl1.Center.Position.Latitude;
            double centerLongitude = MapControl1.Center.Position.Longitude;
            //membuat path 
            polygon.Path = new Geopath(new List<BasicGeoposition>()
            {
                new BasicGeoposition() {Latitude=centerLatitude+0.020, Longitude=centerLongitude-0.020},
                new BasicGeoposition() {Latitude=centerLatitude-0.020, Longitude=centerLongitude-0.020},
                new BasicGeoposition() {Latitude=centerLatitude-0.020, Longitude=centerLongitude+0.020},
                new BasicGeoposition() {Latitude=centerLatitude+0.020, Longitude=centerLongitude+0.020},
            });
            //pengaturan polygin
            polygon.ZIndex = 1; 
            polygon.FillColor = Colors.Red;
            polygon.StrokeColor = Colors.Blue;
            polygon.StrokeThickness = 1;
            polygon.StrokeDashed = false;
            MapControl1.MapElements.Add(polygon);
        }
    }

    public class TipeMap
    {
        public string Nama { get; set; }
        public MapStyle Kode { get; set; }
        
    }


    public class LevelZoom
    {
        public string Nama { get; set; }
        public int Kode { get; set; }
    }
}
