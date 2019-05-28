using System.ComponentModel.DataAnnotations;

namespace GPXRenderer
{
	public partial class TrackPoints
	{
		[Key]
		public int TrackPointID { get; set; }
		public double lon { get; set; }
		public double lat { get; set; }

		public int PathID { get; set; }
		public Paths Path { get; set; }
	}
}
