using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _velCoche; //variable velocitat Nau
    private float velocity = 10f;
    // Start is called before the first frame update
    void Start()
    {
        _velCoche = 5f; //f de float
    }

    // Update is called once per frame
    void Update()
    {
        MovimentCoche();
    }

    private void MovimentCoche()
    {
        //GetAxis acelera poco a poco
        //GetAxisRaw de golpe
        float direccioHorizontal = Input.GetAxisRaw("Horizontal");

        Vector2 direccioIndicada = new Vector2(direccioHorizontal, 0);

        SpriteRenderer SpriteRenderer = GetComponent<SpriteRenderer>();
        float anchura = SpriteRenderer.bounds.size.x / 2;

        //orthographicSize es la distancia desde el centro de la pantalla al borde.
        //Camera.main.aspect devuelve cuanto mas de anchura hay respecto a la altura ya que no todas las pantallas tienen la altura = a la anchura. R = ANCHURA / ALTURA.
        float limitEsquerraX = -Camera.main.orthographicSize * Camera.main.aspect + anchura;
        float limitDretaX = Camera.main.orthographicSize * Camera.main.aspect - anchura;

        //Ens retorna la posició actual de la nau
        Vector2 novaPos = transform.position;
        novaPos += direccioIndicada * _velCoche * Time.deltaTime;
        //Time.deltaTime fa que el joc vagi en la mateixa velocitat en ordinadors diferents.

        novaPos.x = Mathf.Clamp(novaPos.x, limitEsquerraX, limitDretaX);

        transform.position = novaPos;
    }
}
