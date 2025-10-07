using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public enum Characters
    {
        Roommate,
        Receptionist,
        Neighbour,
        Player
    }

    [Header("Talk Events")]
    public AK.Wwise.Event RoommateTalk;
    public AK.Wwise.Event ReceptionistTalk;
    public AK.Wwise.Event NeighbourTalk;
    public AK.Wwise.Event PlayerTalk;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);


        AkUnitySoundEngine.PostEvent("Ambience", gameObject);

        SwitchToApartmentSounds();
    }

    public void CharacterSpeak(Characters character)
    {
        switch (character)
        {
            case Characters.Roommate:
                RoommateTalk.Post(gameObject);
                break;
            case Characters.Receptionist:
                ReceptionistTalk.Post(gameObject);
                break;
            case Characters.Neighbour:
                NeighbourTalk.Post(gameObject);
                break;
            case Characters.Player:
                PlayerTalk.Post(gameObject);
                break;
        }
    }

    /// I HATE THIS SOOOOOOO MUCH
    /// WWHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHY
    /// AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    /// SORRY GOD
    /// FORGIVE ME
    /// FORGIVE ME
    /// FORGIVE ME
    /// FORGIVE ME
    /// FORGIVE ME
    /// FORGIVE ME
    /// :(

    public void SwitchToApartmentSounds()
    {
        SwitchState("Apartment");
    }

    public void SwitchToBasementSounds()
    {
        SwitchState("Basement");
    }

    public void SwitchToBathroomSounds()
    {
        SwitchState("Bathroom");
    }

    public void SwitchToHallwaySounds()
    {
        SwitchState("Hallway");
    }

    public void SwitchToLobbySounds()
    {
        SwitchState("Lobby");
    }

    private void SwitchState(string state)
    {
        AkUnitySoundEngine.SetState("RoomAmbience", state);
    }
}