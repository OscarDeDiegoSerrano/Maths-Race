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
        float direccionHorizontal = Input.GetAxisRaw("Horizontal");
        float direccionVertical = Input.GetAxisRaw("Vertical");

        Vector2 direccionIndicada = new Vector2(direccionHorizontal, direccionVertical);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float anchura = spriteRenderer.bounds.size.x / 2;
        float altura = spriteRenderer.bounds.size.y / 2;

        float tercioPantallaX = Camera.main.orthographicSize * Camera.main.aspect / 2.60f;
        float tercioPantallaY = Camera.main.orthographicSize / 2.60f;

        float limitEsquerraX = -tercioPantallaX + anchura;
        float limitDretaX = tercioPantallaX - anchura;
        float limitInferiorY = -Camera.main.orthographicSize + altura;  // Corregir límite inferior
        float limitSuperiorY = Camera.main.orthographicSize - altura;

        Vector2 novaPos = transform.position;
        novaPos += direccionIndicada * _velPlayer * Time.deltaTime;

        // Ajustar solo los límites en el eje X
        novaPos.x = Mathf.Clamp(novaPos.x, limitEsquerraX, limitDretaX);

        // Ajustar los límites en el eje Y para permitir el movimiento hacia arriba y abajo
        novaPos.y = Mathf.Clamp(novaPos.y, limitInferiorY, limitSuperiorY);

        if (direccionHorizontal != 0 || direccionVertical != 0)
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
