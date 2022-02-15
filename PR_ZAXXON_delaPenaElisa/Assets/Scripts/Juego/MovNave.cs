using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovNave : MonoBehaviour

{
    AudioSource audioSource;
   
    //variables
    public float speedX = 10.0f;
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
    [SerializeField] GameObject nube;
    [SerializeField] AudioClip powerUp;
    [SerializeField] AudioClip columna;
    [SerializeField] AudioClip monstruo;
    [SerializeField] AudioClip fire;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

    public void OnTriggerEnter(Collider other)
    {
        //print("kaboom");

       // MeshRenderer rend = GetComponent<MeshRenderer>();
        switch (other.gameObject.layer)
        {
            case 6:
                audioSource.PlayOneShot(monstruo, 1f);
                //Invoke("Morir()",2f);
                //initGame.Morir();
                StartCoroutine("EsperarMuerte");
                break;
            case 7:
                audioSource.PlayOneShot(powerUp, 1f);
                GameManager.punt++;
                Destroy(other.gameObject);
                print("Tienes un punto! puntos:" + GameManager.punt);
                if (GameManager.punt > GameManager.highscore)
                {
                    GameManager.highscore = GameManager.punt;
                }
                break;

            case 8:
                audioSource.PlayOneShot(fire, 1f);
                disparo = true;
                //rend.enabled = false;
                break;
            case 9:
                //columna
                audioSource.PlayOneShot(columna, 1f);
                Instantiate(nube, transform.position, Quaternion.identity);
                //Invoke("Morir", 2f);
                StartCoroutine("EsperarMuerte");
                break;
        }
        
    }

    private void Disparar()
    {
        if (Input.GetKeyDown(KeyCode.P)||Input.GetButtonDown("Fire1"))
        {
            Instantiate(bolaFuego, instanciaBala.transform.position ,Quaternion.identity);
            
            print("pium pium");

            disparo = false;
        }

    }

    public void Morir()
    {
        initGame.Morir();
    }

    IEnumerator EsperarMuerte()
    {
        yield return new WaitForSeconds(0.2f);
        initGame.Morir();
    }
}
