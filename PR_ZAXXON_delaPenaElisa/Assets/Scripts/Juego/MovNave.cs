using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovNave : MonoBehaviour

{
    //variables
    public float speedX = 5.0f;
    public float speedY = 3.0f;
    float limRight = 8;
    float limLeft = -8;
    float limUp = 3;
    float limDown = 0.5f;
    bool inLimitH;
    [SerializeField] bool inLimitV = true;
    InitGame initGame;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0.7f, 0f);

       
        initGame = GameObject.Find("initGame").GetComponent<InitGame>();
        speedX = initGame.naveSpeed;
        speedY = initGame.naveSpeed * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();
    

    }

    void MoverNave()
    {
        
        //mov eje X
        float desplX = Input.GetAxis("Horizontal") * speedX;

       //mov eje Y
        float desplY = Input.GetAxis("Vertical") * speedY;
       

        //código para restricción

        float posX = transform.position.x;
        float posY = transform.position.y;

        if (posX >= limRight && desplX > 0 || posX<=limLeft && desplX < 0)
        {
           inLimitH=false;
        }
        else { inLimitH=true; }

        if (inLimitH)
        {
        transform.Translate(Vector3.right * desplX * Time.deltaTime);
        }

        if (posY >= limUp && desplY > 0 || posY <= limDown && desplY < 0)
        {
            inLimitV = false;
        }
        else { inLimitV = true; }

        if (inLimitV)
        {
            transform.Translate(Vector3.up * desplY * Time.deltaTime);
        }

        /*
         Otra opción para la resticción: con booleanas de limites verticales y horizontales
        
        if (inLimitH){linea de desplazamiento horizontal (transform.Translate(Vect....}   y lo mismo para el horizontal

         Determinación de límites
        if(posX>=limRight && desplX > 0 o se da otra en la que no quieras moverte)
        {
            inLimit=false;
        } else  { inLimit=true }
        
         */

    }

    private void OnTriggerEnter(Collider other)
    {
        //print("kaboom");

        if (other.gameObject.layer == 6)
        {
            initGame.Morir();
        }
    }
}
