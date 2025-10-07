using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public DialogueManager DialogueManager;
    public bool talkedToRoommate1;//hasWashing-receptionistInBasement 
    public bool talkedToReceptionistBasement;//staffRoomOpen
    public bool hasKey;
    public bool doneWashing;
    public bool talkedToRoommate2;//hasBin-receptionistInLobby
    public bool talkedToReceptionistLobby;//hasLetter-neighbourAvailable
    public bool doneBins;
    public bool talkedToNeighbour;//letterDelivered

    public bool passedRec;

    public int checkpoint; //1-kitchen 2-basementhall 3-lobby 4-hallneighbour

    public GameObject talktoReceptionistBasement;
    public GameObject talktoReceptionistLobby;
    public GameObject talktoRoommate1;
    public GameObject talktoRoommate2;

    //setfalse
    public GameObject talkKitchen;
    public GameObject talkBasement;
    public GameObject talkLobby;
    public GameObject talkNeighbour;

    //settrue
    public GameObject kitchenCheckpoint;
    public GameObject basementCheckpoint;
    public GameObject lobbyCheckpoint;
    public GameObject neighbourCheckpoint;

    //num of loops
    public int spiral;

    public GameObject lobby1f;
    public GameObject lobbyBins;
    public GameObject lobbyB1;

    public GameObject whiteBlink;
    public float animTimeFull;
    public float animTimeClose;

    public GameObject goodEnd;
    public GameObject badEnd;

    public GameObject endScreen;

    public Material[] roomMaterials;

    public void Start()
    {
        ChangeMaterials(500f, Color.darkRed, 0.1f, 1000f, 1000f);
    }

    public void roommateConversation1()
    {
        talkedToRoommate1 = true;

    }
    public void receptionistConversationBasement()
    {
        talkedToReceptionistBasement = true;
    }
    public void keyGet()
    {
        hasKey = true;
    }
    public void laundryDone()
    {
        doneWashing = true;
    }
    public void roommateConversation2()
    {
        talkedToRoommate2 = true;
    }
    public void receptionistConversationLobby()
    {
        talkedToReceptionistLobby = true;
    }

    public void neighbourConversation()
    {
        talkedToNeighbour = true;
    }
    public void binsDone()
    {
        doneBins = true;
    }

    public void setCheckpointKitchen()
    {
        checkpoint = 1;
    }
    public void setCheckpointBasement()
    {
        checkpoint = 2;
    }
    public void setCheckpointLobby()
    {
        checkpoint = 3;
    }
    public void setCheckpointNeighbour()
    {
        checkpoint = 4;
    }

    public void failBlink()
    {
        whiteBlink.SetActive(true);
        spiral += 1;
        Debug.Log(spiral);
        Invoke("loadCheck", animTimeClose);
        Invoke("whiteAnimStop", animTimeFull);
        Invoke("pixelChanger", animTimeClose);
    }

    public void changeToReal()
    {
        Invoke("realPixelChange", animTimeClose);
    }

    public void end()
    {
        Invoke("enableEnd",animTimeClose);
        DialogueManager.DisplayNextSentence();
    }

    void enableEnd()
    {
        endScreen.SetActive(true);
       }

    public void pixelChanger()
    {


        if (spiral == 1)
        {
            ChangeMaterials(450f, Color.darkRed, 0.1f, 1000f, 800f);
        }
        else if (spiral == 2)
        {
            ChangeMaterials(375f, Color.darkRed, 0.1f, 1000f, 600f);
        }
        else if (spiral == 3)
        {
            ChangeMaterials(300f, Color.indianRed, 0.12f, 1000f, 500f);
        }
        else if (spiral == 4)
        {
            ChangeMaterials(200f, Color.red, 0.12f, 1000f, 300f);
        }
        else if (spiral == 10)
        {
            ChangeMaterials(50f, Color.red, 0.15f, 1000f, 10f);
        }
        else
        {
            ChangeMaterials(80f, Color.red, 0.15f, 1000f, 50f);
        }
    }

    public void realPixelChange()
    {
        ChangeMaterials(2000f, Color.clear, 0f, 0f, 0f);
    }

    private void ChangeMaterials(float pixels, Color color, float nFactor, float nScale, float nTime)
    {
        foreach (Material mat in roomMaterials)
        {
            mat.SetFloat("_PixelRatio", pixels);

            mat.SetColor("_NoiseColour", color);

            mat.SetFloat("_NoiseFactor", nFactor);
            mat.SetFloat("_NoiseScale", nScale);
            mat.SetFloat("_NoiseTime", nTime);
        }
    }


    public void passBlink()
    {
        Invoke("loadCheck", animTimeClose);

    }

    void whiteAnimStop()
    {
        whiteBlink.SetActive(false);
    }

    public void loadCheck()
    {
        if (checkpoint == 1)
        {
            talkKitchen.SetActive(false);
            kitchenCheckpoint.SetActive(true);
        }
        if (checkpoint == 2)
        {
            talkBasement.SetActive(false);
            basementCheckpoint.SetActive(true);
        }
        if (checkpoint == 3)
        {
            if (!passedRec)
            {
                talkLobby.SetActive(false);
                lobbyCheckpoint.SetActive(true);
            }
            else
            {
                passedRec = false;
                lobby1f.SetActive(true);
                lobbyB1.SetActive(true);
                if (doneWashing)
                {
                    lobbyBins.SetActive(true);
                }
            }
        }
        if (checkpoint == 4)
        {
            talkNeighbour.SetActive(false);
            neighbourCheckpoint.SetActive(true);
        }
        
    }

    public void setRec()
    {
        passedRec = true;
    }

    public void endingLogic()
    {
        if (spiral >= 5)
        {
            badEnd.SetActive(true);
        }
        else if (spiral < 5)
        {
            goodEnd.SetActive(true);
        }
    }

}

