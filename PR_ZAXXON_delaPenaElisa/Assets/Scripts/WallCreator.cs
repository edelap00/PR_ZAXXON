using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{

    [SerializeField] GameObject ladrillo;
    [SerializeField] Transform initPos;

    // Start is called before the first frame update
    void Start()
    {
        float separacion = 2;
        Vector3 newPos = initPos.position;
        Vector3 despl = new Vector3(separacion, 0f, 0f);
        
       
        // esto se haría en una corrutina
        for(int n = 0; n<10; n++)
        {
            //en lugar de esto podria usar el transform, ya que tengo acceso, ej: initPos.position
            Instantiate(ladrillo, newPos , Quaternion.identity);
            newPos = newPos+ despl;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
