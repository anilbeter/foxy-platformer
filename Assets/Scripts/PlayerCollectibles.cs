using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerCollectibles : MonoBehaviour
{
    private Text textComponent;
    public int gemNumber;

    void Start()
    {
        gemNumber = PlayerPrefs.GetInt("GemNumber", 0);
        // With this approach, I don't have to set reference manually, its always find Text component that belongs GemUI
        textComponent = GameObject.FindGameObjectWithTag("GemUI").GetComponentInChildren<Text>();
        UpdateText();

    }

    private void UpdateText()
    {
        textComponent.text = gemNumber.ToString();
    }

    // public yaptım çünkü bu methodu Gems scriptinde kullanıcam. Amaç-> player gem'e değdiğinde (onTriggerEnter) GemCollected()'ı çağırmak istiyorum
    public void GemCollected()
    {
        gemNumber++;
        UpdateText();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("GemNumber");
    }
}
