using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour {

    public float speed; //Determina uma velocidade
    private Rigidbody rb; //Determina um rigidbody

    private GameObject target; //Determina um alvo

    public GameObject[] triggers; //Cria um vetor de objetos

    private VehicleSpawnerController spawner; //Associa o spawner de veiculos a este objeto


    // Usado na Inicialização
    void Start () {

        rb = GetComponent<Rigidbody>(); //Pega um componente do proprio objeto com as caracteristicas do rigidbody
        spawner = GetComponentInParent<VehicleSpawnerController>(); //Pega um componente no "pai" do objeto com as caracteristicas do spawner de veiculos


        triggers[0] = spawner.trigger1; //Determina que o objeto do vetor na posição [0] recebe o objeto trigger 1 do spawner
        triggers[1] = spawner.trigger2; //Determina que o objeto do vetor na posição [1] recebe o objeto trigger 2 do spawner
        triggers[2] = spawner.trigger3; //Determina que o objeto do vetor na posição [2] recebe o objeto trigger 3 do spawner
        triggers[3] = spawner.trigger4; //Determina que o objeto do vetor na posição [3] recebe o objeto trigger 4 do spawner

        target = triggers[0]; //Determina que o alvo será o objeto na posição [0] do vetor incialmente

	}

    // Usado em cada Frame
    void Update () {

        transform.position = new Vector3(transform.position.x, -0.2f, transform.position.z); //Determina a posição deste objeto

        float fixedSpeed = speed * Time.deltaTime; //Determina a velocidade deste objeto
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, fixedSpeed); //Determina a direção do movimento

        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z); //Determina a posição do alvo

        transform.LookAt(targetPosition); //Faz este objeto olhar para o alvo
        
	}

    // Usado quando entrar em um colisor invisivel 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Track_Trigger_1")) //Caso o colisor tenha a tag igual a "Track_Trigger_1"
        {
            target = triggers[1]; //O alvo passa a ser o objeto do vetor na posição [1]

        }
        else if (other.CompareTag("Track_Trigger_2")) //Caso o colisor tenha a tag igual a "Track_Trigger_2"
        {
            target = triggers[2]; //O alvo passa a ser o objeto do vetor na posição [2]
        }
        else if (other.CompareTag("Track_Trigger_3")) //Caso o colisor tenha a tag igual a "Track_Trigger_3"
        {
            target = triggers[3]; //O alvo passa a ser o objeto do vetor na posição [3]
        }
        else if (other.CompareTag("Track_Trigger_4")) //Caso o colisor tenha a tag igual a "Track_Trigger_4"
        {
            Destroy(gameObject); //Destroi este objeto
        }


    }
}
