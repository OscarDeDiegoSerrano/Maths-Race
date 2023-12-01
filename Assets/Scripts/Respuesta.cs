using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respuesta : MonoBehaviour
{
    public int Numero { get; set; }
    public string ImagenFondo { get; set; }
    public bool esCorrecta = false;
    public GameObject explosioPrefab;

    private void Start()
    {
        Numero = UnityEngine.Random.Range(20, 101); // Generar número aleatorio entre 20 y 100
        ImagenFondo = "IMGrespuesta"; // Establecer el fondo de imagen como "imagen1"
    }

    public void hacerlaCorrecta()
    {
        esCorrecta = true;
    }

    private void Update()
    {
        // Mover hacia abajo
        transform.Translate(Vector2.down * Time.deltaTime);

        // Obtener el tamaño de la pantalla en unidades del mundo
        float screenHeight = Camera.main.orthographicSize;

        // Si el objeto sale de la pantalla, destruirlo
        if (transform.position.y < -screenHeight)
        {
            Destroy(gameObject);

            // Además, si deseas realizar alguna acción adicional al destruir el objeto, puedes llamar al método correspondiente en GeneradorRespuestas
            GeneradorRespuestas generadorRespuestas = FindObjectOfType<GeneradorRespuestas>();
            if (generadorRespuestas != null)
            {
                generadorRespuestas.PosarIniciFalse();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            if (esCorrecta)
            {
                // Destruir la respuesta correcta
                Destroy(gameObject);
            }
            else
            {
                // Obtener la posición del objeto Player1
                Vector2 posicionExplosion = other.transform.position;

                // Cargar el prefab desde la carpeta Resources
                //GameObject explosionPrefab = Resources.Load("Prefabs/Explosion") as GameObject;
                
                GameObject explosio = Instantiate(explosioPrefab);
                explosio.transform.position = posicionExplosion;

                GameObject.Find("GeneradorOperacions").GetComponent<GeneradorOperacions>().AturarGeneracioOperacions();
            }
        }
    }
}


