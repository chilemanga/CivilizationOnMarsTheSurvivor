using UnityEngine;
using System.Collections;

public class DataModelManager : Singleton<DataModelManager> {

	//TODO: retornar algo de tipo Mission
	public string GetMissionDescription(int missionIndex) {
		string description = string.Empty; 
		
		switch(missionIndex)
		{
		case 0: 
			description = 	"En este nivel el jugador se mueve en un escenario básico, donde el objetivo es aprender a jugar. \n";
			description +=	"a.     Se enseña las teclas y movimiento\n";
			description +=	"b.     Se muestra las acciones que puede realizar\n";
			description +=	"c.     Se muestra como explorar el mapa\n";
			description +=	"d.     Se enseña los distintos indicadores con los que cuenta\n";
			description +=	"e.     Se dá por terminado el nivel una vez a explorado el 80% del mapa, y a realizado las acciones que aseguran el manejo de las herramientas básicas (movimiento, acciones, indicadores)\n";
			break;
		case 1:
			
			
			description = 	"1.     En este nivel el jugador debe encontrar los materiales necesarios para construir una base marciana, contará con un primer envío de materiales de la tierra, donde contará con algunos materiales básicos.\n";
			description +=	"2.     Deberá explorar un nuevo tubo de lava, en donde encontrará materias primas para utilizar una impresora 3d, que le permitirá crear nuevas herramientas y materiales.\n";
			description +=	"3.     El nivel se dá por terminado, cuando reúne un 100% de los materiales pedidos, para ello debe explorar los tubos.\n";
			description +=	"4.     Adicional a esto, debe montar la unidad científica y el hábitat inicial\n";
			break;				
			
			
			
		case 2:
			
			description = 	"1.     Ya eres un explorador experto, y tienes materiales y herramientas de construcción. Llegó la hora de explorar los túneles más complejos , y utilizar las unidades iniciales para construir el primer asentamiento humano, de cara a la colonización.\n";
			description +=	"2.     No recibirás más ayuda de la tierra, estás por tu cuenta.\n";
			description +=	"3.     La etapa termina cuando construyes una vivienda humana, un módulo de generación de aire, agua y electricidad, y un módulo de alimentación. \n";
			break;
		default:
			Log.Warning("No hay información de misión para el index {0}", missionIndex);
			break;
		}

		return description;
	}
}
