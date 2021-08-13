using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private Text nameText;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Animator animator;
 


    private Queue<string> sentences;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {


        Debug.Log("starting dialogue with " + dialogue.name);
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();


    }


    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        
        Debug.Log(sentence);
        StopAllCoroutines();
        StartCoroutine(TpyeSentence(sentence));

    }

    IEnumerator TpyeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;//amount of time to wait a single frame;
        }
    }



    public void EndDialogue()
    {
        animator.SetBool("isOpen",false);
        Debug.Log("End Dialogue");
        FindObjectOfType<WaittingTime>().CloseDialogueUI();
    }

    
}
