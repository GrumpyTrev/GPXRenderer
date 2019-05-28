namespace GPXRenderer
{
	/// <summary>
	/// Mediator message used to inform listeners that a Path's active property has changed
	/// </summary>
	class PathActiveChangedMessage
	{
		public int PathID { get; set; }
		public bool active { get; set; }
	}
}
