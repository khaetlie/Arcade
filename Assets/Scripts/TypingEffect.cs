using TMPro;
using UnityEngine;
using System.Collections;

public class TypingEffect : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float typingSpeed = 0.05f; // Delay between characters
    public string message = "Welcome to the Arcade!";

    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        textMeshPro.text = ""; // Clear text initially
        foreach (char letter in message.ToCharArray())
        {
            textMeshPro.text += letter; 
            yield return new WaitForSeconds(typingSpeed); 
        }
    }
}
