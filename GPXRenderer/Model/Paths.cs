using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace GPXRenderer
{
	public partial class Paths : INotifyPropertyChanged
	{
		[Key]
		public int PathID { get; set; }
		public string name { get; set; }
		public string desc { get; set; }

		/// <summary>
		/// Is this path active, i.e. being displayed.
		/// Needs to be a tracked property as it can be changed by the user and displayed in multiple views
		/// </summary>
		public bool active
		{
			get
			{
				return activeValue;
			}
			set
			{
				if ( value != activeValue )
				{
					activeValue = value;

					NotifyPropertyChanged();
				}
			}
		}

		// This method is called by the Set accessor of each property.
		// The CallerMemberName attribute that is applied to the optional propertyName
		// parameter causes the property name of the caller to be substituted as an argument.
		private void NotifyPropertyChanged( [CallerMemberName] string propertyName = "" )
		{
			PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
		}

		public virtual ICollection<TrackPoints> TrackPoints { get; set; }

		/// <summary>
		/// Explicit backup for the active property.
		/// </summary>
		private bool activeValue = false;

		/// <summary>
		/// Event used to track the 'active' property changes
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

	}
}
