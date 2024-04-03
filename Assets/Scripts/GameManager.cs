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
    }
}
