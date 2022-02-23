using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacMove : MonoBehaviour
{
   // [SerializeField] GameObject initGame;
     InitGame initGame;
    float speedCol = 15f;
    [SerializeField] GameObject miObjeto;
    
    // Start is called before the first frame update
    void Start()
    {
        miObjeto = GameObject.Find("initGame");
       initGame = miObjeto.GetComponent<InitGame>();
    }

    // Update is called once per frame
    void Update()
    {
     if (gameObject.tag == "lava")
        {
            transform.Translate(Vector3.back * Time.deltaTime * speedCol);
        }
        else
        {
transform.Translate(Vector3.back * Time.deltaTime*initGame.naveSpeed);
        }
        
        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }
}
