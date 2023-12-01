using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _velPlayer; // variable velocidad Player
    public bool seHaMovido;

    public GameObject explosionPrefab; // Prefab de la explosión

    // Start is called before the first frame update
    void Start()
    {
        _velPlayer = 5f; // velocidad determinada
        seHaMovido = false;
    }

    // Update is called once per frame
    void Update()
    {
        movPlayer(); // movimientoPlayer
    }

    private void movPlayer()
    {
        // GetAxis acelera poco a poco
        // GetAxisRaw de golpe
        float direccionHorizontal = Input.GetAxisRaw("Horizontal");

        Vector2 direccionIndicada = new Vector2(direccionHorizontal, 0);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float anchura = spriteRenderer.bounds.size.x / 2;

        // orthographicSize es la distancia desde el centro de la pantalla al borde.
        // Camera.main.aspect devuelve cuanto más de anchura hay respecto a la altura ya que no todas las pantallas tienen la altura = a la anchura. R = ANCHURA / ALTURA.
        float tercioPantalla = Camera.main.orthographicSize * Camera.main.aspect / 2.60f;
        float limitEsquerraX = -tercioPantalla + anchura;
        float limitDretaX = tercioPantalla - anchura;

        // Ens retorna la posición actual de la nave
        Vector2 novaPos = transform.position;
        novaPos += direccionIndicada * _velPlayer * Time.deltaTime;
        // Time.deltaTime hace que el juego vaya a la misma velocidad en ordenadores diferentes.

        novaPos.x = Mathf.Clamp(novaPos.x, limitEsquerraX, limitDretaX);

        if (direccionHorizontal != 0)
        {
            seHaMovido = true;
        }

        transform.position = novaPos;
    }
    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Respuesta")
        {
            //Debug.Log("Fora)");
            if (!objecteTocat.GetComponent<Respuesta>().esCorrecta)
            {
                //Temps de espera
                //Debug.Log("Entra)");
                Invoke("PassarAGameOver", 2f);
            }
        }
    }

    private void PassarAGameOver()
    {
        //Debug.Log("Entra");
        GameObject.Find("GameManager").GetComponent<GameManager>().PassarAEstatInici();
    }
}
