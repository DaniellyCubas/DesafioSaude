using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public string[] dialogueNPC;
    public int dialogueIndex;

    public GameObject dialoguePanel;
    public Text dialogueText;

    public Text nameNPC;
    public Image imageNPC;
    public Sprite spriteNPC;

    public bool prontinho;
    public bool readyToSpeak;
    public bool startDialogue;

    // Start is called before the first frame update
    void Start()
    {
        dialoguePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if (!startDialogue && !prontinho)
            {
                prontinho = true;
                Debug.Log("Teste4");
                FindObjectOfType<Luli>().velh = 0f;
                FindObjectOfType<Luli>().QuantidadePulos = 0;
                StartDialogue();
            }
            else if (dialogueText.text == dialogueNPC[dialogueIndex]) 
            {
                Debug.Log("Teste5");
                NextDialogue();
            }
        }
        else if (Input.GetMouseButton(1))
        { prontinho = false; }
    }
    void NextDialogue()
    {
        dialogueIndex++;

        if (dialogueIndex < dialogueNPC.Length)
        {
            StartCoroutine(ShowDialogue());
            Debug.Log("Teste1");
        }
        else
        {
            Debug.Log("Teste");
            dialoguePanel.SetActive(false);
            startDialogue = false;        
            dialogueIndex = 0;
            readyToSpeak = false;
            FindObjectOfType<Luli>().velh = 5f;
            FindObjectOfType<Luli>().QuantidadePulos = 1;
        }

    }

    void StartDialogue()
    {
        Debug.Log("Teste3");
        nameNPC.text = "Gato";
        imageNPC.sprite = spriteNPC;
        startDialogue = true;
        dialogueIndex = 0; //elemento 0 da matrix
        dialoguePanel.SetActive(true);
        StartCoroutine(ShowDialogue());
    }
    //Corotina para mostrar o dialogo 
    IEnumerator ShowDialogue()
    {
        Debug.Log("Teste2");
        dialogueText.text = "";
        foreach (char letter in dialogueNPC[dialogueIndex])
        {
            dialogueText.text += letter;    
            yield return new WaitForSeconds(0.1f);
        }
    }

 
}
