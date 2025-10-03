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

    public GameObject talktoReceptionistBasement;
    public GameObject talktoReceptionistLobby;
    public GameObject talktoRoommate1;
    public GameObject talktoRoommate2;



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

}

