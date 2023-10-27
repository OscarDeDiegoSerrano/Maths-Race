using UnityEngine;

public class GeneradorRespuestas : MonoBehaviour
{
    public GameObject prefabRespuesta; // Asigna el prefab de "Respuesta" en el Inspector.
    public Sprite imagenSe�al; // Asigna la imagen "imagense�al" en el Inspector.
    public float separacion = 1.5f; // Separaci�n entre objetos generados.
    public float velocidadDescenso = 2.0f; // Velocidad de descenso.
    public float generacionIntervalo = 8.0f; // Intervalo de generaci�n.

    private float tiempoUltimaGeneracion;

    void Start()
    {
        tiempoUltimaGeneracion = Time.time;
    }

    void Update()
    {
        // Comprueba si es hora de generar nuevos objetos.
        if (Time.time - tiempoUltimaGeneracion >= generacionIntervalo)
        {
            // Genera tres objetos al mismo tiempo.
            GenerarObjeto(-separacion);
            GenerarObjeto(0);
            GenerarObjeto(separacion);

            // Actualiza el tiempo de �ltima generaci�n.
            tiempoUltimaGeneracion = Time.time;
        }
    }

    void GenerarObjeto(float offset)
    {
        GameObject respuesta = Instantiate(prefabRespuesta, transform);
        respuesta.transform.position = new Vector3(offset, 6.0f, 0);
        respuesta.GetComponent<SpriteRenderer>().sprite = imagenSe�al;

        // Genera un n�mero aleatorio entre 100 y 1000.
        int numeroAleatorio = Random.Range(100, 1001);
        respuesta.GetComponentInChildren<TextMesh>().text = numeroAleatorio.ToString();
    }
}
