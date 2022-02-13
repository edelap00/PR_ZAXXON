using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovNave : MonoBehaviour

{
    //variables
    public float speedX = 5.0f;
    public float speedY = GameManager.speed;
    float limRight = 15.5f;
    float limLeft = -15.5f;
    float limUp = 6;
    float limDown = -0.5f;
    bool inLimitH;
    bool disparo;
    [SerializeField] bool inLimitV = true;
    InitGame initGame;
    [SerializeField] GameObject instanciaBala;
    [SerializeField] GameObject bolaFuego;
    // Start is called before the first frame update
    void Start()
    {
        disparo = true;
        GameManager.punt = 0;
        transform.position = new Vector3(0, 0.7f, 0f);

       
        initGame = GameObject.Find("initGame").GetComponent<InitGame>();
        speedX = initGame.naveSpeed;
        speedY = initGame.naveSpeed * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();

        if (disparo)
        {
            Disparar();
        }
    }

    void MoverNave()
    {
        
        //mov eje X
        float desplX = Input.GetAxis("Horizontal") * speedX;

       //mov eje Y
        float desplY = Input.GetAxis("Vertical") * speedY;
       

        //c�digo para restricci�n

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
         Otra opci�n para la resticci�n: con booleanas de limites verticales y horizontales
        
        if (inLimitH){linea de desplazamiento horizontal (transform.Translate(Vect....}   y lo mismo para el horizontal

         Determinaci�n de l�mites
        if(posX>=limRight && desplX > 0 o se da otra en la que no quieras moverte)
        {
            inLimit=false;
        } else  { inLimit=true }
        
         */

    }

    private void OnTriggerEnter(Collider other)
    {
        //print("kaboom");

        switch (other.gameObject.layer)
        {
            case 6:
               initGame.Morir();
                break;
            case 7:
                GameManager.punt++;
                Destroy(other.gameObject);
                print("Tienes un punto! puntos:" + GameManager.punt);
                if (GameManager.punt > GameManager.highscore)
                {
                    GameManager.highscore = GameManager.punt;
                }
                break;

            case 8:
                break;
            case 9:
                break;
        }
        
    }

    private void Disparar()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(bolaFuego, instanciaBala.transform);
            
            print("pium pium");
        }

    }
}
