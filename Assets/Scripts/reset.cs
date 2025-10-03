using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Reset", 3.5f);
    }


    private void Reset()
    {
        SceneManager.LoadScene("Main");
    }
}
