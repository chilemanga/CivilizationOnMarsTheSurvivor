using System;
using System.Collections.Generic;
using System.Linq;

public class Mision {

	private IList<IMeta> metas;

	public Mision ()
	{
		metas = new List<IMeta> (){ new MetaRecurso(){ Recurso = Recurso.Hierro, MasaObjetivo = 75, MasaActual = 0 } };
	}

	public string Descripcion {
		get;
		set;
	}

	public IList<IMeta> Metas { get { return metas; } }

	public bool EstaCumplida{ get { return metas.All(m => m.SeCumple); } }

}
