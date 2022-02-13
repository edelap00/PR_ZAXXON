using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniSuelos : MonoBehaviour
{
    Renderer rend;
    float scrollVel = GameManager.speed;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Distancia de desplazamiento, según el tiempo transc.
        float offset = (Time.time * scrollVel)/30;
        //Vector de desplazamiento
        Vector2 despl = new Vector2(0, -offset);
        //Desplazamos la textura albedo y la normal
        rend.material.SetTextureOffset("_MainTex", despl);
        rend.material.SetTextureOffset("_BumpMap", despl);
    }
}
