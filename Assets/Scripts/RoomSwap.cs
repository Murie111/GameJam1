using UnityEngine;

public class RoomSwap : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject currentRoom;
    public GameObject nextRoom;
    public float animTimeFull;
    public float animTimeClose;
    public GameObject blackBlink;
    public GameObject jobBlink;
    public float jobAnimTimeFull;
    public float jobAnimTimeClose;

    //0- bedroom
    //1- bathroom
    //2- apartment
    //3- kitchen
    //4- talk kitchen
    //5- hallway
    //6- neighbour
    //7- talk neighbour
    //8- lobby
    //9- basehall
    //10-staff room
    //11-bedroom real - good
    //12-bathroom real - good
    //13-apartment real - good
    //14-kitchen real - good
    //15-talk kitchen real - good
    //16-bedroom real - bad
    //17-bathroom real - bad
    //18-apartment real - bad


    public void SwapNextRoom(int destinationRoom)
    {
        blackBlink.SetActive(true);
        nextRoom = rooms[destinationRoom];
        Invoke("SwapDelayNext", animTimeClose);
        Invoke("StopAnim", animTimeFull);
    }
    public void SwapCurrentRoom(int originRoom)
    {
        currentRoom = rooms[originRoom];
        Invoke("SwapDelayCurrent", animTimeClose);
    }

    public void doJob()
    {
        jobBlink.SetActive(true);
        Invoke("StopJobAnim", jobAnimTimeFull);
    }


    void StopAnim()
    {
        blackBlink.SetActive(false);
    }

    void StopJobAnim()
    {
        jobBlink.SetActive(false);
    }
    void SwapDelayNext()
    {
        nextRoom.SetActive(true);
    }
    void SwapDelayCurrent()
    {
        currentRoom.SetActive(false);
    }

    public void DialogueEnd()
    {
        blackBlink.SetActive(true);
        Invoke("StopAnim", animTimeFull);
    }

}
