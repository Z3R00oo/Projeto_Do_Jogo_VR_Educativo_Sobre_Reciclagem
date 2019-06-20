using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAreaController : MonoBehaviour {

    public bool canGrab = false; //Determina se pode pegar ou não
    private PlayerGrabController player; //Associa o player a este objeto

    public int distanceOfRay = 10; //Determina a distância do raio de visão
    private RaycastHit hit; //Determina um alvo atingido pelo raio de visão


    // Usado na Inicialização
    void Start()
    {
        player = FindObjectOfType<PlayerGrabController>(); //Procura na cena um objeto com as características do player
    }
    // Usado em cada Frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); //Determina um raio que sai da posição da camera

        if (Physics.Raycast(ray, out hit, distanceOfRay, 1 << 13)) //Caso esse raio de visão atingir um objeto na Layer(camada) 13
        {
            if (hit.transform.CompareTag("Item")) //Caso o alvo atingido tenha uma tag igual a "Item"
            {
                player.item = hit.transform.gameObject; //O item do player recebe o objeto atingido
                canGrab = true; //Pode ser pego
            }
            
        }
        else //Caso o raio de visão não atingir um objeto na Layer 13
        {
            canGrab = false; //Não pode ser pego
        }

    }
}
