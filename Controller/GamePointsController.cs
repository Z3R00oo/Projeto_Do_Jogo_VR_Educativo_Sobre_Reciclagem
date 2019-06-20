using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePointsController : MonoBehaviour {

    public static int currentPoints = 0; //Determina a quantidade de pontos atuais
    public Text currentPointsText; //Determina um texto para quantidade de pontos atuais

	// Usado na Inicialização
	void Start () {

        currentPoints = 0; //A quantidade de pontos recebe 0 inicialmente
		
	}
	
	// Usado em cada Frame
	void Update () {

        currentPointsText.text = currentPoints.ToString(); //O texto recebe a quantidade de pontos
		
	}
}
