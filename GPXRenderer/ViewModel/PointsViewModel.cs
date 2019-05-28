using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace GPXRenderer.ViewModel
{
	/// <summary>
	/// Holds the maps (Paths instance) and associated points (TrackPoints) that can be displayed 
	/// </summary>
	class PointsViewModel
	{
		public PointsViewModel()
		{
			// Register interest in the PathActiveChangedMessage message.
			// Update the active state of the associated Paths object in the local collection
			Mediator.Instance.Register( ( object obj ) => 
			{
				PathActiveChangedMessage message = ( PathActiveChangedMessage )obj;
				Paths pathChanged = Routes.FirstOrDefault( path => path.PathID == message.PathID );
				if ( pathChanged != null )
				{
					pathChanged.active = message.active;
				}
			},
			typeof( PathActiveChangedMessage ) );
		}

		/// <summary>
		/// Load all the Paths objects and their associated TrackPoints objects
		/// </summary>
		public void LoadPoints()
		{
			using ( TracksContext context = new TracksContext() )
			{
				context.Paths.Include( s => s.TrackPoints ).Load();
				Routes = context.Paths.Local;
			}
		}

		/// <summary>
		/// The collection of Paths objects
		/// </summary>
		public ObservableCollection<Paths> Routes { get; set; }
	}
}
