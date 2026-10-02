using UnityEngine;
using UnityEngine.SceneManagement;

public class LaMuelteElDiavlo : MonoBehaviour
{
    
    [SerializeField] private string targetTag = "Player"; 
        

   
 

  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            RestartScene();
        }
    }

    private void RestartScene()
    {
        Time.timeScale = 1f;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}