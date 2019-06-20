using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

    public bool isOrganic; //Determina se é Organico
    public bool isPlastic; //Determina se é Plastico
    public bool isPaper; //Determina se é Papel
    public bool isGlass; //Determina se é Vidro

    public AudioSource successSoundFX; //Determina um som para acertos
    public AudioSource failSoundFX; //Determina um som para erros

    public bool inPlayerHands; //Determina se está nas mão do player ou não
    private PlayerGrabController player; //Associa o player a este objeto

    public float timeToDeactivateObject; //Determina um tempo para desativar este objeto
    private float currentTimeToDeactivateObject; //Determina um contador para o tempo para desativar este objeto

    public bool isObjectActivate; //Determina se o objeto está ativado ou não

    // Usado na Inicialização
    void Start () {

        player = FindObjectOfType<PlayerGrabController>(); //Procura na cena um objeto com as características do player
        inPlayerHands = false; //Determina que não está nas mão do player inicialmente


    }
	
	// Usado em cada Frame
	void Update () {

        if (isObjectActivate && !inPlayerHands) //Caso este objeto esteja ativado e não esteja nas mãos do player
        {
            currentTimeToDeactivateObject += Time.deltaTime; //O contador para desativar o objeto se inicia
        }
        else if (isObjectActivate && inPlayerHands) //Caso este objeto estja ativado e nas mãos do player
        {
            currentTimeToDeactivateObject = 0; //O contador volta para 0 até que não esteja mais nas mãos do player
            inPlayerHands = true; //Determina que está nas mãos do player
        }

        if (currentTimeToDeactivateObject >= timeToDeactivateObject) //Caso o contador para desativar o objeto seja maior ou igual ao tempo para desativar
        {
            gameObject.SetActive(false); // Este objeto é desativado na cena
            isObjectActivate = false; //Determina que ele não está ativado
            inPlayerHands = false; //Determina que ele não está nas mãos do player
            currentTimeToDeactivateObject = 0; //O contador volta para 0 até que ele seja ativado novamente
        }


    }
    // Usado quando entrar em um colisor invisivel
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Brow_Waste_Bin") && isOrganic) //Caso o colisor tenha a tag igual a "Brown_Waste_Bin" e este objeto for organico
        {
            gameObject.SetActive(false); //Este objeto é desativado na cena
            gameObject.transform.SetParent(null); //Este objeto passa a ser independe na cena(ele não tem um "pai")
            isObjectActivate = false; //Determina que este objeto não está mais ativo
            inPlayerHands = false; //Determina que não está nas mãos do player
            GamePointsController.currentPoints = GamePointsController.currentPoints + 10; //Os pontos são aumentado em 10
            successSoundFX.Play(); //O som para acertos toca
        }
        else if (other.CompareTag("Blue_Waste_Bin") && isPaper) //Caso o colisor tenha a tag igual a "Blue_Waste_Bin" e este objeto for papel
        {
            gameObject.SetActive(false); //Este objeto é desativado na cena
            gameObject.transform.SetParent(null); //Este objeto passa a ser independe na cena(ele não tem um "pai")
            isObjectActivate = false; //Determina que este objeto não está mais ativo
            inPlayerHands = false; //Determina que não está nas mãos do player
            GamePointsController.currentPoints = GamePointsController.currentPoints + 10; //Os pontos são aumentado em 10
            successSoundFX.Play(); //O som para acertos toca

        }
        else if (other.CompareTag("Red_Waste_Bin") && isPlastic) //Caso o colisor tenha a tag igual a "Red_Waste_Bin" e este objeto for plastico
        {
            gameObject.SetActive(false); //Este objeto é desativado na cena
            gameObject.transform.SetParent(null); //Este objeto passa a ser independe na cena(ele não tem um "pai")
            isObjectActivate = false; //Determina que este objeto não está mais ativo
            inPlayerHands = false; //Determina que não está nas mãos do player
            GamePointsController.currentPoints = GamePointsController.currentPoints + 10; //Os pontos são aumentado em 10
            successSoundFX.Play(); //O som para acertos toca

        }
        else if (other.CompareTag("Green_Waste_Bin") && isGlass) //Caso o colisor tenha a tag igual a "Green_Waste_Bin" e este objeto for vidro
        {
            gameObject.SetActive(false); //Este objeto é desativado na cena
            gameObject.transform.SetParent(null); //Este objeto passa a ser independe na cena(ele não tem um "pai")
            isObjectActivate = false; //Determina que este objeto não está mais ativo
            inPlayerHands = false; //Determina que não está nas mãos do player
            GamePointsController.currentPoints = GamePointsController.currentPoints + 10; //Os pontos são aumentado em 10
            successSoundFX.Play(); //O som para acertos toca

        }
        else //Se ele colidir com o colisor errado
        {
            gameObject.transform.SetParent(null); //Ele se torna independente
            isObjectActivate = false; //Determina que ele não está mais ativo
            inPlayerHands = false; //Determina que ele não está nas mãos do player
            gameObject.SetActive(false); //O objeto é desativado na cena
            failSoundFX.Play(); //O som para erros toca
        }
    }
}
