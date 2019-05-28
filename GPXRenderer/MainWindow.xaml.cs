using System.Windows;

namespace GPXRenderer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow: Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Called when the data grid showing the route details has been loaded (RouteView.xaml)
		/// Create a RouteViewModel instance and load the route summary data. Set the context for the data grid
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RouteViewControl_Loaded( object sender, RoutedEventArgs e )
		{
			ViewModel.RouteViewModel viewModel = new ViewModel.RouteViewModel();
			viewModel.LoadRoutes();

			RouteViewControl.DataContext = viewModel;
		}

		/// <summary>
		/// Called when the WebBrowser control has been loaded.
		/// Create a PointsViewModel instance, load the route points and pass them to the browser
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MapViewControl_Loaded( object sender, RoutedEventArgs e )
		{
			ViewModel.PointsViewModel viewModel = new ViewModel.PointsViewModel();
			viewModel.LoadPoints();

			mapViewControl.MapContents = viewModel.Routes;
		}
	}
}
