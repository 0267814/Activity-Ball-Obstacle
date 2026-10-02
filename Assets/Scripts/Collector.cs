using UnityEngine;
using TMPro; 

public class Collector : MonoBehaviour
{
    
    [SerializeField] private string targetTag = "Target";
    [SerializeField] private int targetAmount = 3; 

    
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private TextMeshProUGUI counterText; 
    private int collectedCount = 0;

    void Start()
    {
        
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }

        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag(targetTag))
        {
            collectedCount++;
            UpdateUI();

            
            Destroy(other.gameObject);

            
            if (collectedCount >= targetAmount)
            {
                TriggerVictory();
            }
        }
    }

    private void TriggerVictory()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }

        Debug.Log("End");
        
         Time.timeScale = 0f;
    }

    private void UpdateUI()
    {
        
        if (counterText != null)
        {
            counterText.text = $"Items: {collectedCount} / {targetAmount}";
        }
        
    }
}