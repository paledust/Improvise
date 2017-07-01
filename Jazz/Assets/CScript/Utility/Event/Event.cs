using System;

namespace Kevin_Event{
	public abstract class Event {
		public delegate void Handler(Event e);
	}
	public class ShiftNote_Event: Event{

	}
	public class LowerNote_Event: Event{

	}

}
