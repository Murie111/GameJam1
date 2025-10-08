using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class DialogueManager : MonoBehaviour
{
    public RoomSwap roomSwap;
    public Logic logicScript;
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueUI;
    public GameObject nextSentenceButton;
    public GameObject resetButton;
    public GameObject endButton;
    public Animator animator;
    public float textSpeed;
    private GameObject currentNPC;
    public static DialogueManager instance;
    bool isChoice = false;
    bool loopCheckSwapImage = false;
    bool loopCheckFindNPC = false;
    bool loopCheckFindPlayer = false;
    public GameObject roommate1option1;
    public GameObject roommate1option2;
    public GameObject receptionist1option1;
    public GameObject receptionist1option2;
    public GameObject roommate2option1;
    public GameObject receptionist2option1;
    public GameObject receptionist2option2;
    public GameObject neighbouroption1;
    public GameObject neighbouroption2;
    public GameObject goodEndingOption;
    private bool IsPaused;

    public Queue<string> sentences;
    public Queue<string> names;


    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();          
    }

    private void Awake()
    {
        instance = this;
    }

    public void StartDialogue (Dialogue dialogue){

        animator.SetBool("isOpen", true);
        sentences.Clear();
        names.Clear();

        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }
        foreach (string name in dialogue.names){
            names.Enqueue(name);
        }

        DisplayNextSentence();

    }
    public void DisplayNextSentence(){

        nextSentenceButton.SetActive(true);
        isChoice = false;
        if ((sentences.Count == 0 && names.Count == 0))
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        nameText.text = name;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()){
            if (letter == ('/'))
            {
                isChoice = true;
                nextSentenceButton.SetActive(false);
                yield return new WaitForSeconds(textSpeed);
            }
            else if (letter == ('-'))
            {
                isChoice = false;
                nextSentenceButton.SetActive(true);
                yield return new WaitForSeconds(textSpeed);
            }

            else if (letter == ('1'))
            {
                roommate1option1.SetActive(true);
                yield return new WaitForSeconds(textSpeed);

            }
            else if (letter == ('2'))
            {
                roommate1option2.SetActive(true);
                yield return new WaitForSeconds(textSpeed);

            }
            else if (letter == ('3'))
            {
                receptionist1option1.SetActive(true);
                yield return new WaitForSeconds(textSpeed);

            }
            else if (letter == ('4'))
            {
                receptionist1option2.SetActive(true);
                yield return new WaitForSeconds(textSpeed);

            }
            else if (letter == ('5'))
            {
                roommate2option1.SetActive(true);
                yield return new WaitForSeconds(textSpeed);

            }
            else if (letter == ('6'))
            {
                receptionist2option1.SetActive(true);
                yield return new WaitForSeconds(textSpeed);

            }
            else if (letter == ('7'))
            {
                receptionist2option2.SetActive(true);
                yield return new WaitForSeconds(textSpeed);

            }
            else if (letter == ('8'))
            {
                neighbouroption1.SetActive(true);
                yield return new WaitForSeconds(textSpeed);

            }
            else if (letter == ('9'))
            {
                neighbouroption2.SetActive(true);
                yield return new WaitForSeconds(textSpeed);

            }
            else if (letter == ('0'))
            {
                goodEndingOption.SetActive(true);
                yield return new WaitForSeconds(textSpeed);

            }
            else if (letter == ('~'))
            {
                resetButton.SetActive(true);
                nextSentenceButton.SetActive(false);
            }
            else if (letter == ('^'))
            {
                endButton.SetActive(true);
                nextSentenceButton.SetActive(false);
            }
            else
            {
                if (letter != '.')
                {
                    if (nameText.text == "Roommate")
                    {
                        AudioManager.Instance.CharacterSpeak(AudioManager.Characters.Roommate);
                    }
                    else if (nameText.text == "Receptionist")
                    {
                        AudioManager.Instance.CharacterSpeak(AudioManager.Characters.Receptionist);
                    }
                    else if (nameText.text == "Neighbour")
                    {
                        AudioManager.Instance.CharacterSpeak(AudioManager.Characters.Neighbour);
                    }
                    else
                    {
                        AudioManager.Instance.CharacterSpeak(AudioManager.Characters.Player);
                    }
                }

                dialogueText.text += letter;
                yield return new WaitForSeconds(textSpeed);
            }
        }    
    }
    public void EndDialogue(){

        resetButton.SetActive(false);
        nextSentenceButton.SetActive(false);
        logicScript.passBlink();
        animator.SetBool("isOpen", false);
        NPCInteract passScript = (NPCInteract) currentNPC.GetComponent(typeof(NPCInteract));
        passScript.EndTalking();
        names.Clear();
        sentences.Clear();
        if(logicScript.passedRec == false)
        {
            roomSwap.DialogueEnd();
        }

    }



    public void swapNPC(GameObject interactedNPC)
    {
        currentNPC = interactedNPC;
        Debug.Log("NPC Swapped!");
    }



    public void CorrectResponse()
    {
        names.Dequeue();
        sentences.Dequeue();
        names.Dequeue();
        sentences.Dequeue();
        nextSentenceButton.SetActive(true);
        DisplayNextSentence();
    }
    public void WrongResponse()
    {
        DisplayNextSentence();
    }

    public void ResetButton()
    {
        Debug.Log("resetting");
        sentences.Clear();
        names.Clear();
        resetButton.SetActive(false);
        nextSentenceButton.SetActive(false);
        animator.SetBool("isOpen", false);
        NPCInteract passScript = (NPCInteract)currentNPC.GetComponent(typeof(NPCInteract));
        passScript.EndTalking();
        logicScript.failBlink();

    }

}