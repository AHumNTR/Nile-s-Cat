using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogue;
    public Animator animator;
    private Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string> ();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;

        animator.SetBool("IsOpen",true);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue (sentence);
        }

        DisplayNextSentences();
    }
    
    public void DisplayNextSentences()
    {

        if (sentences.Count == 0) {

            EndDialogue();
            return;
        
        
        }
        string sentence = sentences.Dequeue ();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogue.text = "";
        foreach (char letter in sentence.ToCharArray()) 
        {
        
        dialogue.text += letter;
            yield return null;
        
        
        
        }
    }
    
    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
