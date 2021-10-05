using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{
    [SerializeField] GameObject obst;
    [SerializeField] Transform initPos;
    // Start is called before the first frame update
    void Start()
    {
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
            Instantiate(obst, new Vector3(Random.Range(-4f, 4f), 0f, initPos.position.z), Quaternion.identity);
            yield return new WaitForSeconds(6f);
        }

    }
}
