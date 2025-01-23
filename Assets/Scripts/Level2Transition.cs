using UnityEngine;

public class LevelTransitionAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Level2Transition"); // Play the animation

        // Optionally, start the game after the animation
        Invoke(nameof(StartLevel2Game), 3f); // Adjust time to match animation length
    }

    private void StartLevel2Game()
    {
        Debug.Log("Level 2 Begins!"); // Replace with your gameplay logic
    }
}
