using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFire : MonoBehaviour
{
    AudioSource audioSource;
    Animator ani;
    [SerializeField] float fuegoSpeed = 45f;
    [SerializeField] GameObject nube;
    [SerializeField] GameObject hijo;
    [SerializeField] AudioClip powerUp;
    [SerializeField] AudioClip columna;
    [SerializeField] AudioClip monstruo;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * fuegoSpeed);
        
        if (transform.position.z > 90)
        {
            Destroy(gameObject);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        print("el disparo ha chocado");
        Instantiate(nube, transform.position, Quaternion.identity);
        switch (other.gameObject.layer)
        {
            case 6:
                //enemigo
                SphereCollider collider = other.gameObject.GetComponent<SphereCollider>();
                audioSource.PlayOneShot(monstruo, 0.85f);
                ani = other.GetComponent<Animator>();
                ani.SetTrigger("morir");
                Destroy(collider);
                Destroy(other.gameObject, 1f);
                GameManager.muertos++;
                GameManager.globalPoints = GameManager.globalPoints + 2;
                if (GameManager.globalPoints > GameManager.highscore)
                {
                    GameManager.highscore = GameManager.globalPoints;
                }

                break;
            case 7:
                //powerupGema
                audioSource.PlayOneShot(powerUp, 0.6f);
                Destroy(other.gameObject);
                break;
                

            case 8:
                //fire
               
                break;

            case 9:
                //columna
                audioSource.PlayOneShot(columna, 1f);
               
                
                break;
        }
        Destroy(hijo);
        Destroy(gameObject,0.5f);
       // Destroy(nube, 3f);

    }
}
