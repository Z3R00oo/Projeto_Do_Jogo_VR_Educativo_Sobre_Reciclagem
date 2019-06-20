using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalGamePointsController : MonoBehaviour {

    public Text pointsText; //Determina um texto para os pontos finais

	// Usado na Inicialização
	void Start () {

        pointsText.text = "Seus Pontos: " + GamePointsController.currentPoints.ToString(); // O texto recebe a quantidade de pontos garantidos
		
	}
}
