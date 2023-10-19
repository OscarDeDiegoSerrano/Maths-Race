using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player1;
    public GameObject TextGameOver;
    public GameObject Titol;
    public GameObject BotoInici;
    public GameObject BotoControls;
    public GameObject BotoRanking;
    public GameObject generadorRespostes;
    public GameObject generadorOperacions;
    public GameObject BotoTornarInici;
    //public GameObject generadorNumeros;
    //public GameObject generadorOperacions;
    //public GameObject botoTornarPantallaInici;
    public enum EstatsGameManager
    {
        Inici,
        PantallaControls,
        PantallaRanking,
        Jugant,
        GameOver
    }

    private EstatsGameManager _estatGameManager;
    // Start is called before the first frame update
    void Start()
    {
        _estatGameManager = EstatsGameManager.Inici;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ActualitzaEstatGameManager()
    {
        switch (_estatGameManager)
        {
            case EstatsGameManager.Inici:
                player1.SetActive(false);
                Titol.SetActive(true);
                TextGameOver.SetActive(false);
                BotoInici.SetActive(true);
                BotoControls.SetActive(true);
                BotoRanking.SetActive(true);
                BotoTornarInici.SetActive(false);
                break;

            case EstatsGameManager.Jugant:
                player1.SetActive(true);
                Titol.SetActive(false);
                TextGameOver.SetActive(false);
                BotoInici.SetActive(false);
                BotoControls.SetActive(false);
                BotoRanking.SetActive(false);
                BotoTornarInici.SetActive(false);
                break;

        }
    }
}
