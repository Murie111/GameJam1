using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AK.Wwise.Event[] sounds;

    public void PlaySound()
    {
        foreach (var sound in sounds)
        { 
            sound.Post(gameObject);
        }
    }
}
