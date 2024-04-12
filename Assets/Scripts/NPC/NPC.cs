using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject canvas;
    public bool playerClouse;
    [Header("UI")]
    [SerializeField] private GameObject dialogoPanel;
    [SerializeField] private TMP_Text dialogoText;

    [Header("Dialogos")]
    [SerializeField, TextArea(4, 6)] private string[] dialogos;
    private bool dialogoStart;
    private int lineIndex;
    [SerializeField] private float typingTime = 0.05f;

    [Header("Sound")]
    [SerializeField] private List<AudioClip> SoudsKeysList;



    void Update()
    {
        if (playerClouse && Input.GetButtonDown("Fire2"))
        {
            if (!dialogoStart)
            {
                StartDialogue();
            }
            else if (dialogoText.text == dialogos[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogoText.text = dialogos[lineIndex];
            }
        }
        
    }

    private void StartDialogue()
    {
        dialogoStart = true;
        dialogoPanel.SetActive(true);
        canvas.SetActive(false);
        lineIndex = 0;

        StartCoroutine(ShowLine());
    }
    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogos.Length)
        {
            StartCoroutine(ShowLine());

        }
        else
        {
            dialogoStart = false;
            dialogoPanel.SetActive(false);
            canvas.SetActive(true);
        }
    }

    private IEnumerator ShowLine()
    {
        dialogoText.text = string.Empty;

        foreach (char c in dialogos[lineIndex])
        {
            int rand = UnityEngine.Random.Range(0, 3);
            dialogoText.text += c;
            SoundManager.Instance.EjecutarAudio(SoudsKeysList[rand]);
            yield return new WaitForSeconds(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            playerClouse = true;
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            playerClouse = false;
            canvas.SetActive(false);
        }
    }
}
