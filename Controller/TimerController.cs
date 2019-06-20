using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour {

    public Text timerText; //Determina um texto para o tempo
    public float minutes; //Determina os minutos
    private float currentMinutes; //Determina o contador dos minutos
    private float seconds = 60; //Determina os segundos com valor fixo de 60
    private float currentSeconds; //Determina o contador dos segundos

    private bool isLastMinute; //Determina se é o ultimo minuto ou não

    // Usado na Inicialização
    void Start () {
        currentMinutes = minutes; //O contador dos minutos recebe a quantidade de minutos
        currentSeconds = seconds; //O contador dos segundos recebe a quantidade de segundos
	}

    // Usado em cada Frame
    void Update () {

        currentSeconds -= Time.deltaTime; //O contador dos segundos começa a diminuir

        if (currentMinutes <= 0) //Caso a quantidade de minutos seja menor ou igual a 0
        {
            isLastMinute = true; //Determina que é o ultimo minuto
        }

        if (currentSeconds <= 0 && !isLastMinute) //Caso o contador de segundos seja menor ou igual a 0 e não for o ultimo minuto
        {
            currentSeconds = seconds; //O contador recebe a quantiade de segundos(60) novamente
            currentMinutes--; //Diminui em 1 a quantidade de minutos
        }
        else if(currentSeconds <= 0 && isLastMinute) //Caso o contador dos segundos seja menor ou igual a 0 e for o ultimo minuto
        {
            SceneManager.LoadScene("Game_Over"); //Troca para cena de "Game_Over"

        }

        timerText.text = "Tempo: " + currentMinutes.ToString("F0") + ":" + currentSeconds.ToString("F0"); //O texto do tempo recebe a quantidade de minutos e segundos atuais 

        


    }
}
