using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacMove : MonoBehaviour
{
   // [SerializeField] GameObject InitObjet;
  //  InitGame initGame;
    float speed=5f;
    // Start is called before the first frame update
    void Start()
    {
   //     initGame = InitObjet.GetComponent<InitGame>();
    }

    // Update is called once per frame
    void Update()
    {
     //   Instantiate()
        transform.Translate(Vector3.back * Time.deltaTime*speed);
    }
}
