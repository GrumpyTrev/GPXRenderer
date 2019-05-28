using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace GPXRenderer
{
	static class GpxHelper
	{
		/// <summary>
		/// Convert the supplied Paths object to classes in the RouteSerialiser file and then 
		/// serialise them to Xml format held in a string
		/// </summary>
		/// <param name="pathToConvert"></param>
		/// <returns></returns>
		public static string PathToGpx( Paths pathToConvert )
		{
			string gpxString = "";

			gpxType gpxData = new gpxType() { creator = "GPXRenderer", rte = new rteType[ 1 ] };
			rteType route = new rteType() { name = pathToConvert.name, desc = pathToConvert.desc };
			gpxData.rte[ 0 ] = route;

			List<wptType> tracks = new List<wptType>();

			// Convert all the TrackPoints on the map to Locations
			foreach ( TrackPoints point in pathToConvert.TrackPoints )
			{
				tracks.Add( new wptType() { lat = ( decimal )point.lat, lon = ( decimal )point.lon } );
			}

			route.rtept = tracks.ToArray();

			// Now serialise this to a string
			XmlSerializer serialiser = new XmlSerializer( typeof( gpxType ) );
			using ( StringWriter textWriter = new StringWriter() )
			{
				serialiser.Serialize( textWriter, gpxData );
				gpxString = textWriter.ToString();
			}

			return gpxString;
		}
	}
}
