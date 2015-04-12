using System;

public class MetaRecurso : IMeta {

	public bool SeCumple {
		get {
			return MasaActual == MasaObjetivo;
		}
	}

	public Recurso Recurso {
		get;
		set;
	}

	public int MasaActual {
		get;
		set;
	}

	public int MasaObjetivo {
		get;
		set;
	}

}
