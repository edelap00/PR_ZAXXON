using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovNave : MonoBehaviour

{
    //variables
    public float speedX = 5.0f;
    public float speedY = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mov eje 1
        float DesplY = Input.GetAxis("Vertical") * speedY;
        transform.Translate(Vector3.up * DesplY * Time.deltaTime);

        //mov eje 2
        float DesplX = Input.GetAxis("Horizontal") * speedX;
        transform.Translate(Vector3.right * DesplX * Time.deltaTime);

    }
}
