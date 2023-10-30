using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _velPlayer; //variable velocidad Player
    public bool seHaMovido;
    // Start is called before the first frame update
    void Start()
    {
        _velPlayer = 5f; //velocidad determinada
        seHaMovido = false;
    }

    // Update is called once per frame
    void Update()
    {
        movPlayer(); //movimientoPlayer
    }
                
    private void movPlayer()
    {
        //GetAxis acelera poco a poco
        //GetAxisRaw de golpe
        float direccionHorizontal = Input.GetAxisRaw("Horizontal");

        Vector2 direccionIndicada = new Vector2(direccionHorizontal, 0);

        SpriteRenderer SpriteRenderer = GetComponent<SpriteRenderer>();
        float anchura = SpriteRenderer.bounds.size.x / 2;

        //orthographicSize es la distancia desde el centro de la pantalla al borde.
        //Camera.main.aspect devuelve cuanto mas de anchura hay respecto a la altura ya que no todas las pantallas tienen la altura = a la anchura. R = ANCHURA / ALTURA.
        float tercioPantalla = Camera.main.orthographicSize * Camera.main.aspect / 2.60f;
        float limitEsquerraX = -tercioPantalla + anchura;
        float limitDretaX = tercioPantalla - anchura;

        //Ens retorna la posició actual de la nau
        Vector2 novaPos = transform.position;
        novaPos += direccionIndicada * _velPlayer * Time.deltaTime;
        //Time.deltaTime fa que el joc vagi en la mateixa velocitat en ordinadors diferents.

        novaPos.x = Mathf.Clamp(novaPos.x, limitEsquerraX, limitDretaX);

        if (direccionHorizontal != 0)
        {
            seHaMovido = true;
        }

        transform.position = novaPos;
    }
}
