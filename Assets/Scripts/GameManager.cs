using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

        public GameObject player1;
        public GameObject TextGameOver;
        public GameObject Titol;
        public GameObject BotoInici;
        //public GameObject generadorNumeros;
        //public GameObject generadorOperacions;
        //public GameObject botoTornarPantallaInici;
        public enum EstatsGameManager
        {
            Inici,
            Jugant,
            GameOver
        }

        private EstatsGameManager _estatGameManager;
        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
