using System.Data.Entity;

namespace GPXRenderer
{
	public partial class TracksContext: DbContext
	{
		protected override void OnModelCreating( DbModelBuilder modelBuilder )
		{
			// Configures one-to-many relationship between Paths and TrackPoints
			modelBuilder.Entity<TrackPoints>()
				.HasRequired<Paths>( s => s.Path )
				.WithMany( g => g.TrackPoints )
				.HasForeignKey<int>( s => s.PathID );
		}

		public virtual DbSet<Paths> Paths { get; set; }
		public virtual DbSet<TrackPoints> TrackPoints { get; set; }
	}
}
