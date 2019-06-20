using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VRGazeController : MonoBehaviour {

    public Image imgGaze; //Determina uma imagem
    public float totalTime = 2; //Determina um valor de duração do loading
    private float gvrTimer; //Determina um contador para a duração do loading

    public bool gvrStatus; //Determina o Status do loading

    public int distanceOfRay = 10; //Determina uma distancia para o raio de visão
    private RaycastHit hit; //Determina um alvo do raio de visão

    // Update is called once per frame
    void Update () {

        if (gvrStatus) //Caso o status seja positivo 
        {
            gvrTimer += Time.deltaTime; //O contador se inicia
            imgGaze.fillAmount = gvrTimer / totalTime; //A imagem recebe o efeito de loading baseada na divisão do contador pela duração do loading
        }
        else //Caso o status seja negativo
        {
            gvrTimer = 0; //O contador recebe 0
            imgGaze.fillAmount = 0; //A imagem fica invisivel na cena
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); //Cria um raio de visão que sai da camera

        if(Physics.Raycast(ray, out hit, distanceOfRay, 1 << 12)) //Se o raio de visao atingir um objeto que esteja na layer 12
        {
            if(imgGaze.fillAmount == 1 && hit.transform.CompareTag("Teleport_Point")) //Caso a imagem esteja completa e o alvo atingido tenha a tag igual a "Teleport_Point"
            { 

                hit.transform.gameObject.GetComponent<TeleportController>().TeleportPlayer(); //Pega um componente no alvo que tenha as caracteristicas do TeleportPlayer e faz o teleporte do player
            }

            if (imgGaze.fillAmount == 1 && hit.transform.CompareTag("Back_Button")) //Caso a imagem esteja completa e o alvo atingido tenha a tag igual a "Back_Button"
            {
                SceneManager.LoadScene("Game_Menu"); //Troca para a cena de Menu
            }

            if (imgGaze.fillAmount == 1 && hit.transform.CompareTag("Play_Button")) //Caso a imagem esteja completa e o alvo atingido tenha a tag igual a "Play_Button"
            {
                SceneManager.LoadScene("Game_Tutorial"); //Troca para a cena de Jogo
            }
        }
	}

    // Usado para determinar o Status do loading (positivo)
    public void GvrOn()
    {
        gvrStatus = true;
    }

    // Usado para determinar o Status do loading (negativo)
    public void GvrOff()
    {
        gvrStatus = false;
    }
}
