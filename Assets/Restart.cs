using UnityEngine;

public class Restart : MonoBehaviour
{
    [SerializeField] private string scene;

    public void RestartGame()
    {
        Initiate.Fade(scene, Color.white, 1);
    }
}