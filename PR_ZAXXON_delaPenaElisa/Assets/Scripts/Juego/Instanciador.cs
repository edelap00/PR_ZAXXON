using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    [SerializeField] GameObject obst;
    [SerializeField] Transform initPos;
     float intervalo ;
     float intervalo2;
    //variable columnas iniciales
    float distanciaObstaculos = 20;
    float primerObstaculo = 30f;
    [SerializeField] GameObject[] arrayObst;
    [SerializeField] GameObject[] arrayAround;


    // Start is called before the first frame update
    void Start()
    {
        intervalo = 1f;
        
        //COLUMNAS INICIALES
        float numColumnas = (transform.position.z - primerObstaculo) / distanciaObstaculos;

        for(float n= primerObstaculo; n <transform.position.z; n+=distanciaObstaculos)
        {
            Vector3 initColPos = new Vector3(Random.Range(-15f, 15f), Random.Range(0, 5f), n);
           
            int randomNum = Random.Range(0, arrayObst.Length);
            Instantiate(arrayObst[randomNum], initColPos, Quaternion.identity);

        }

        for (float n = primerObstaculo; n < transform.position.z; n += distanciaObstaculos)
        {
            Vector3 instanciaAround = new Vector3(Random.Range(-190f, -16f), -0.1f, n);
            Vector3 instanciaAround2 = new Vector3(Random.Range(16f, 190f), -0.1f, n);


            int randomNum = Random.Range(0, arrayAround.Length);
            int randomNum2 = Random.Range(0, arrayAround.Length);


            Instantiate(arrayAround[randomNum], instanciaAround, Quaternion.identity);
            Instantiate(arrayAround[randomNum2], instanciaAround2, Quaternion.identity);
        }

        //INSTANCIAS DEL M?S ALL?
        StartCoroutine("Instanciar");
        StartCoroutine("InstanceAround");
    }

    // Update is called once per frame
    void Update()
    {
        intervalo2 = Random.Range(0.1f, 0.9f);
    }

    IEnumerator Instanciar ()
    {
        Vector3 instanciaArray = new Vector3 ( Random.Range(-15f, 15f), Random.Range(1.7f, 7f), initPos.position.z);

        for (; ; )
        {

            int randomNum = Random.Range(0, arrayObst.Length);
            if (arrayObst[randomNum].layer == 9)
            {
                instanciaArray= new Vector3( Random.Range(-15f, 15f), 3f, initPos.position.z);
            } else {
                instanciaArray = new Vector3(Random.Range(-15f, 15f), Random.Range(1.5f, 7f), initPos.position.z);
            }

            Instantiate(arrayObst[randomNum], instanciaArray, Quaternion.identity);
           
            yield return new WaitForSeconds(intervalo);
        }

    }

    IEnumerator InstanceAround ()
    {
        

        for (; ; )
        {
            Vector3 instanciaAround = new Vector3(Random.Range(-190f, -16f), -0.1f, initPos.position.z);
            Vector3 instanciaAround2 = new Vector3(Random.Range(16f, 190f), -0.1f, initPos.position.z + 1f);
            

            int randomNum = Random.Range(0, arrayAround.Length);
            int randomNum2 = Random.Range(0, arrayAround.Length);


            Instantiate(arrayAround[randomNum], instanciaAround, Quaternion.identity);
            Instantiate(arrayAround[randomNum2], instanciaAround2, Quaternion.identity);

            yield return new WaitForSeconds(intervalo2);
        }
     
    }
}
