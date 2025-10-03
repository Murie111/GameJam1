using Unity.Mathematics;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public bool talkedToRoommate1;//hasWashing-receptionistInBasement 
    public bool talkedToReceptionistBasement;//staffRoomOpen
    public bool hasKey;
    public bool doneWashing;
    public bool talkedToRoommate2;//hasBin-receptionistInLobby
    public bool talkedToReceptionistLobby;//hasLetter-neighbourAvailable
    public bool doneBins;
    public bool talkedToNeighbour;//letterDelivered

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
            talkLobby.SetActive(false);
            lobbyCheckpoint.SetActive(true);
        }
        if (checkpoint == 4)
        {
            talkNeighbour.SetActive(false);
            neighbourCheckpoint.SetActive(true);
        }
    }
}

