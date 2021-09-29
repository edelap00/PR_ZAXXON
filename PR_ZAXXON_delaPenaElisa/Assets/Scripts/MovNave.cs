using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovNave : MonoBehaviour

{
    //variables
    public float speedX = 5.0f;
    public float speedY = 3.0f;
    float limRight = 10;
    float limLeft = 10;
    float limUp = 10;
    float limDown = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mov eje 1
        float desplY = Input.GetAxis("Vertical") * speedY;
        transform.Translate(Vector3.up * desplY * Time.deltaTime);

        //mov eje 2
        float desplX = Input.GetAxis("Horizontal") * speedX;
        transform.Translate(Vector3.right * desplX * Time.deltaTime);

        //código para restricción

        float posX = transform.position.x;
        float posY = transform.position.y;
        
        if(posX>=limRight && desplX > 0)
        {
            desplX = 0;
        } else { }


    }
}
