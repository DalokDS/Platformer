using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
