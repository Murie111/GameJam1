using Unity.Mathematics;
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

    public Material mat;

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


    public void Start()
    {
        mat.SetFloat("_PixelRatio", 500f);

        mat.SetColor("_NoiseColour", Color.darkRed);

        mat.SetFloat("_NoiseFactor", 0.1f);
        mat.SetFloat("_NoiseScale", 1000f);
        mat.SetFloat("_NoiseTime", 1000f);
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

    public void pixelChanger()
    {
        if (spiral == 1)
        {
            mat.SetFloat("_PixelRatio", 450f);

            mat.SetColor("_NoiseColour", Color.darkRed);

            mat.SetFloat("_NoiseFactor", 0.1f);
            mat.SetFloat("_NoiseScale", 1000f);
            mat.SetFloat("_NoiseTime", 800f);
        }
        else if (spiral == 2)
        {
            mat.SetFloat("_PixelRatio", 375f);

            mat.SetColor("_NoiseColour", Color.darkRed);

            mat.SetFloat("_NoiseFactor", 0.1f);
            mat.SetFloat("_NoiseScale", 1000f);
            mat.SetFloat("_NoiseTime", 600f);
        }
        else if (spiral == 3)
        {
            mat.SetFloat("_PixelRatio", 300f);

            mat.SetColor("_NoiseColour", Color.indianRed);

            mat.SetFloat("_NoiseFactor", 0.11f);
            mat.SetFloat("_NoiseScale", 1000f);
            mat.SetFloat("_NoiseTime", 500f);
        }
        else if (spiral == 4)
        {
            mat.SetFloat("_PixelRatio", 200f);

            mat.SetColor("_NoiseColour", Color.red);

            mat.SetFloat("_NoiseFactor", 0.12f);
            mat.SetFloat("_NoiseScale", 1000f);
            mat.SetFloat("_NoiseTime", 300f);
        }
        else
        {
            mat.SetFloat("_PixelRatio", 80f);

            mat.SetColor("_NoiseColour", Color.red);

            mat.SetFloat("_NoiseFactor", 0.15f);
            mat.SetFloat("_NoiseScale", 1000f);
            mat.SetFloat("_NoiseTime", 50f);
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

}

