using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerCollectibles : MonoBehaviour
{
    public Text textComponent;
    public int gemNumber;

    void Start()
    {
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
}
