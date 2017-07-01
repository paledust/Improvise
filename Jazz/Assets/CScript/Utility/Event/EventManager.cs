using System;
using System.Collections.Generic;
using Kevin_Event;

public class EventManager {
	static private EventManager instance;
	static public EventManager Instance{
		get{
			if(instance == null){
			instance = new EventManager();
			}
			return instance;
		}
	}

	private Dictionary<Type, Event.Handler> RegistedHandler = new Dictionary<Type, Event.Handler>();
	public void RegistHandler<T>(Event.Handler handler) where T: Event{
		Type type = typeof(T);
		if(RegistedHandler.ContainsKey(type)){
			RegistedHandler[type] += handler;
		}
		else
			RegistedHandler[type] = handler;
	}
	public void UnregistHandler<T>(Event.Handler handler) where T:Event{
		Type type = typeof(T);
		Event.Handler handlers;

		if(RegistedHandler.TryGetValue(type, out handlers)){
			handlers -= handler;
			if(handlers == null){
				RegistedHandler.Remove(type);
			}
			else{
				RegistedHandler[type] = handlers;
			}
		}
	}
	public void ClearList(){
		RegistedHandler.Clear();
	}
	public void FireEvent(Event e){
		Type type = e.GetType();
		Event.Handler handlers = RegistedHandler[type];

		if(RegistedHandler.TryGetValue(type, out handlers))
			handlers(e);
	}
}
