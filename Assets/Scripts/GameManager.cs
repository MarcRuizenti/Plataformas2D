using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private GameObject player;

    [Header("Coleccionables")]
    public List<GameObject> coleccionables;
    private int maxColection;
    public int coleccion;
    [SerializeField]private GameObject puerta1;
    private bool puerta1Open;

    [Header("UI")]
    public TextMeshProUGUI maxColectionsText;
    public TextMeshProUGUI colectionsText;
    public TextMeshProUGUI vidasText;
    [Header("Pause")]
    public GameObject bottonReturn;
    public GameObject bottonExit;
    public GameObject fondo;
    public GameObject titel;
    void Start()
    {
        puerta1Open = false;
        maxColection = coleccionables.Count;
        maxColectionsText.text = maxColection.ToString();
    }
    void Update()
    {
        colectionsText.text = coleccion.ToString();
        vidasText.text = player.GetComponent<PlayerHealth>().health.ToString();

        if (coleccionables.Count == 0 && !puerta1Open)
        {
            puerta1.GetComponent<Puerta>().enabled = true;
            puerta1Open = true;
        }

        if (Input.GetKeyDown("escape"))
        {
            Time.timeScale = 0;
        }

        if(Time.timeScale == 0)
        {
            bottonExit.SetActive(true);
            bottonReturn.SetActive(true);
            fondo.SetActive(true);
            titel.SetActive(true);
        }
        else
        {
            bottonExit.SetActive(false);
            bottonReturn.SetActive(false);
            fondo.SetActive(false);
            titel.SetActive(false);
        }
    }
}
