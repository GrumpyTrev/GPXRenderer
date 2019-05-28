using System.Collections.ObjectModel;
using System.Data.Entity;

namespace GPXRenderer.ViewModel
{
	/// <summary>
	/// Holds the maps (Paths instance) that can be displayed 
	/// </summary>
	class RouteViewModel
	{
		public ObservableCollection<Paths> Routes { get; set; }

		public void LoadRoutes()
		{
			context.Paths.Load();
			Routes = context.Paths.Local;

			// Monitor the active property of the Paths so that it can be saved to the model and passed to other views if required
			foreach ( Paths path in Routes )
			{
				path.PropertyChanged += ( o, i ) => 
				{
					context.SaveChanges();

					// Notify other models of this change
					Mediator.Instance.NotifyConsumers( new PathActiveChangedMessage() { active = path.active, PathID = path.PathID } );
				}; 
			}
		}

		/// <summary>
		/// Use a class scope context so that path property changes can be saved.
		/// </summary>
		private TracksContext context = new TracksContext();
	}
}
