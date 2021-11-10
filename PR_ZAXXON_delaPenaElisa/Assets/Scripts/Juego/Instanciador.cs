using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    [SerializeField] GameObject obst;
    [SerializeField] Transform initPos;
    [SerializeField] float intervalo ;
    //variable columnas iniciales
    float distanciaObstaculos = 20;
    float primerObstaculo = 30f;
    [SerializeField] GameObject[] arrayObst;
    
    // Start is called before the first frame update
    void Start()
    {
        intervalo = 2f;
        
        //COLUMNAS INICIALES
        float numColumnas = (transform.position.z - primerObstaculo) / distanciaObstaculos;

        for(float n= primerObstaculo; n <transform.position.z; n+=distanciaObstaculos)
        {
            Vector3 initColPos = new Vector3(Random.Range(-7f, 7f), Random.Range(0, 5f), n);
            print(initColPos);
            int randomNum = Random.Range(0, arrayObst.Length);
            Instantiate(arrayObst[randomNum], initColPos, Quaternion.identity);
        }
        
        //INSTANCIAS DEL MÄS ALLÄ
        StartCoroutine("Instanciar"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Instanciar ()
    {
     

        for (; ; )
        {
            int randomNum = Random.Range(0, arrayObst.Length);
            Instantiate(arrayObst[randomNum], new Vector3(Random.Range(-7f, 7f), Random.Range(0, 5f), initPos.position.z), Quaternion.identity);
           
            yield return new WaitForSeconds(intervalo);
        }

    }
}
