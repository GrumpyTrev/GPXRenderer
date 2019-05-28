using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Windows.Controls;

namespace GPXRenderer.Views
{
	/// <summary>
	/// Interaction logic for MapView.xaml
	/// </summary>
	[ComVisible( true )]
	public partial class MapView: UserControl
	{
		public MapView()
		{
			InitializeComponent();

			browserControl.ObjectForScripting = this;

			browserControl.LoadCompleted += BrowserControl_LoadCompleted;
		}

		/// <summary>
		/// The collection of maps (Paths class instances) to display on the WebBrowser
		/// </summary>
		public ObservableCollection<Paths> MapContents
		{
			get
			{
				return pathsCollection;
			}

			set
			{
				pathsCollection = value;

				// Monitor the active property of the Paths so that the associated map can be hidden or displayed
				foreach ( Paths path in pathsCollection )
				{
					path.PropertyChanged += ( o, i ) => 
					{
						browserControl.InvokeScript( "DisplayMap", new object[] { path.PathID.ToString(), path.active ? 1 : 0 } );
					};
				}
			}
		}

		/// <summary>
		/// Called when the browser control has loaded its 'home' web page.
		/// Load all the maps into the map control held by the web browser
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BrowserControl_LoadCompleted( object sender, System.Windows.Navigation.NavigationEventArgs e )
		{
			foreach ( Paths path in MapContents )
			{
				// Pass this to the web page using the PathID as the name of the layer
				browserControl.InvokeScript( "DisplayGPXString", new object[] { path.PathID.ToString(), GpxHelper.PathToGpx( path ), path.active ? 1 : 0 } );
			}
		}

		/// <summary>
		/// The collection of maps (Paths class instances) to display on the WebBrowser
		/// </summary>
		private ObservableCollection<Paths> pathsCollection = null;
	}
}
