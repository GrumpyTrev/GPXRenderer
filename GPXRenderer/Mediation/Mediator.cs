using System;

namespace GPXRenderer
{
	public sealed class Mediator
	{
		/// <summary>
		/// Registers interest in a specific message
		/// </summary>
		/// <param name="callback">The callback to use when the message it received</param>
		/// <param name="message">The message to register</param>
		public void Register( Action<Object> callback, Type message )
		{
			internalList.AddValue( message, callback );
		}

		/// <summary>
		/// Notify all consumers that have registered interest in the specific message
		/// </summary>
		/// <param name="message">The message by</param>
		public void NotifyConsumers( object message )
		{
			if ( internalList.ContainsKey( message.GetType() ) == true )
			{
				// Forward the message to all registered listeners
				foreach ( Action<object> callback in internalList[ message.GetType() ] )
				{
					callback( message );
				}
			}
		}

		/// <summary>
		/// The Mediator singleton
		/// </summary>
		public static Mediator Instance { get; } = new Mediator();

		private Mediator()
		{
		}

		/// <summary>
		/// Dictionary of message type to listeners
		/// </summary>
		private MultiDictionary< Type , Action<Object>> internalList = new MultiDictionary<Type, Action<object>>();
	}
}
