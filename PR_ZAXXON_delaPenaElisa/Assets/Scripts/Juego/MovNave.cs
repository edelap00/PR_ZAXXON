using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MovNave : MonoBehaviour

{
    AudioSource audioSource;
   
    //variables
    public float speedX = 10.0f;
    public float speedY = GameManager.speed;
    float limRight = 15.5f;
    float limLeft = -15.5f;
    float limUp = 8;
    float limDown = 0f;
    bool inLimitH;
    bool disparo;
    [SerializeField] bool inLimitV = true;
    InitGame initGame;
    [SerializeField] Image fireSpr;
    Color activado;
    Color desactivado;
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

        activado = new Color32(255, 228, 138, 255);
        desactivado = new Color32(10, 10, 10, 255);

        audioSource = GetComponent<AudioSource>();
        disparo = true; //ojo, que iba antes de guardar
        fireSpr.color = activado;
        print(desactivado);
        GameManager.punt = 0;
        GameManager.muertos = 0;
        GameManager.globalPoints = 0;
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

        /*
        if (disparo && fireSpr.color == desactivado)
        {
            fireSpr.color = activado;
        }
        if (!disparo && fireSpr.color == activado)
        {
            fireSpr.color = desactivado;
        }
        */
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
                Instantiate(nube, other.gameObject.transform.position, Quaternion.identity);
                audioSource.PlayOneShot(monstruo, 1f);
                //Invoke("Morir()",2f);
                //initGame.Morir();
                StartCoroutine("EsperarMuerte");
                break;
            case 7:
                audioSource.PlayOneShot(powerUp, 1f);
                GameManager.punt++;
                GameManager.globalPoints++;
                Destroy(other.gameObject);
                print("Tienes una gema! Gemas:" + GameManager.punt);
                if (GameManager.globalPoints > GameManager.highscore)
                {
                    GameManager.highscore = GameManager.globalPoints;
                }
                break;

            case 8:
                audioSource.PlayOneShot(fire, 1f);
                disparo = true;
                fireSpr.color = activado;

                //rend.enabled = false;
                break;
            case 9:
                //columna
                Instantiate(nube, other.gameObject.transform.position, Quaternion.identity);
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
            fireSpr.color = desactivado;

        }

    }

    public void Morir()
    {
        initGame.Morir();
    }

    IEnumerator EsperarMuerte()
    {
        //desactivar compenentes de scripts. ObstacMove, Ani suelo. si no puedo desactivar obst, cambiar velocidad.
        yield return new WaitForSeconds(0.1f);
        initGame.Morir();
    }

    IEnumerator FadeMusic()
    {
        //bajar audiomixer while sea mayor que 0.
        yield return new WaitForSeconds(0.1f);
        

    }
}
