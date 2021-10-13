using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    //Variable de tipo transform que está vinculada a la nave
    [SerializeField] Transform playerPosition;
    //Variables mov de la cámara
    [SerializeField] float distancia = 4;
    [SerializeField] float altura = 1;
    Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CamFol();
    }

    void CamFol() {
        //distancia = 6;
        cameraPosition = new Vector3(playerPosition.position.x, (playerPosition.position.y + altura), (playerPosition.position.z - distancia));
        transform.position = cameraPosition;
        transform.LookAt(playerPosition);
    }
}
