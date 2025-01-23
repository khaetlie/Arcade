using UnityEngine;
using UnityEngine.UI;

public class TextHoverEffect : MonoBehaviour
{
    public Text text; // Reference to the Text component
    public Color hoverColor = Color.yellow;
    private Color originalColor;

    void Start()
    {
        originalColor = text.color; // Store the original color
    }

    public void OnMouseEnter()
    {
        text.color = hoverColor; // Change to hover color
    }

    public void OnMouseExit()
    {
        text.color = originalColor; // Revert to original color
    }
}
