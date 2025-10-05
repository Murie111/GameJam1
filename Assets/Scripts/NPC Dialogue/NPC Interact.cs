using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NPCInteract : MonoBehaviour
{
    public Dialogue dialogue;
    private bool isTalking = false;
    public GameObject nextSentenceButton;
    


    public void startDialogue()
    {
        Debug.Log("active!");
        isTalking = true;
        Invoke("TriggerDialogue", 0.3f);
        nextSentenceButton.SetActive(true);
    }





    private void TriggerDialogue(){
        DialogueManager.instance.swapNPC(gameObject);
        DialogueManager.instance.StartDialogue(dialogue);
    }
    public void EndTalking(){
        if (isTalking == true){
            isTalking = false;
        }
    }
}



