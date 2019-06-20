using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabController : MonoBehaviour {

    public GameObject item; //Determina um item 
    public Transform itemPosition; //Determina a posição do item quando for pego
    public Transform itemOutPosition; //Determina a posição do item quando for solto

    public GameObject Hands; //Determina o objeto das mãos do player

    private GrabAreaController grabArea; //Associa o raio de visão para pegar um objeto

    Camera cam; //Associa a camera

	// Usado na Inicialização
	void Start () {

        cam = GetComponentInChildren<Camera>(); //Pega um componente nos "filhos" deste objeto que tenha as caracteristicas da camera
        grabArea = GetComponentInChildren<GrabAreaController>(); //Pega um componente nos "filhos" deste objeto que tenha as caracteristicas do raio de visão para pegar um objeto
    }
	
	// Usado em cada Frame
	void Update () {

        if (Input.GetButtonDown("Fire1")) //Caso o botão "Fire1"(botão esquerdo do mouse/ctrl/Gatilho inferior do controle) seja pressionado
        {
            OnClick(); //Chama o método OnClick   
        }
		
	}

    // Usado quando se aperta um botão determinado
    public void OnClick()
    {
        if (!item.GetComponent<ItemController>().inPlayerHands && grabArea.canGrab) //Caso o item não esteja nas mãos do player e ele pode pegar
        {
            item.transform.SetParent(cam.transform); //O player se torna o "pai" do item selecionado
            item.transform.localPosition = itemPosition.localPosition; //o item recebe a posição determinada quando estiver nas mãos do player
            item.GetComponent<Rigidbody>().useGravity = false; //O componenete Rigidbody(usado para a fisica) desabilita a gravidade do item (ele fica estatico)
            item.GetComponent<SphereCollider>().enabled = false; // O compoente de colisão do item é desabilitado
            Hands.SetActive(true); //As mãos do player são ativadas
            item.GetComponent<ItemController>().inPlayerHands = true; //Determina que o item está nas mãos do player

        }
        else if (item.GetComponent<ItemController>().inPlayerHands) //Caso o item ja esteja nas mãos do player quando apertar o determinado botão
        {
            item.transform.SetParent(null); //O item passa a ser independente
            item.transform.position = itemOutPosition.position; //o item recebe a posição determinada quando não estiver nas mãos do player
            item.GetComponent<Rigidbody>().useGravity = true;  //O componenete Rigidbody(usado para a fisica) habilita a gravidade do item
            item.GetComponent<SphereCollider>().enabled = true; // O compoente de colisão do item é habilitado
            Hands.SetActive(false); //As mãos do player são desativadas
            item.GetComponent<ItemController>().inPlayerHands = false; //Determina que o item não está mais nas mãos do player
        }
    }
}
