using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFire : MonoBehaviour
{
    AudioSource audioSource;
    Animator ani;
    [SerializeField] float fuegoSpeed = 45f;
    [SerializeField] GameObject nube;
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
                audioSource.PlayOneShot(monstruo, 1f);
                ani = other.GetComponent<Animator>();
                ani.SetTrigger("morir");
                Destroy(other.gameObject, 1.5f);

                break;
            case 7:
                //powerupGema
                audioSource.PlayOneShot(powerUp, 1f);
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


        Destroy(gameObject);
       // Destroy(nube, 3f);

    }
}
