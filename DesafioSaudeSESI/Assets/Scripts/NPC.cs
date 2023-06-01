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
            if (!startDialogue)
            {
                FindObjectOfType<Luli>().velh = 0f;
                StartDialogue();
            }
            else if (dialogueText.text == dialogueNPC[dialogueIndex]) 
            {
                NextDialogue();
            }
        }
    }
    void NextDialogue()
    {
        dialogueIndex++;

        if (dialogueIndex < dialogueNPC.Length)
        {
            StartCoroutine(ShowDialogue()); 
        }
        else
        {
            Debug.Log("Teste");
            dialoguePanel.SetActive(false);
            startDialogue = false;        
            dialogueIndex = 0;
            readyToSpeak = false;
            FindObjectOfType<Luli>().velh = 5f;
            
        }

    }

    void StartDialogue()
    {
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
        dialogueText.text = "";
        foreach (char letter in dialogueNPC[dialogueIndex])
        {
            dialogueText.text += letter;    
            yield return new WaitForSeconds(0.1f);
        }
    }

 
}
