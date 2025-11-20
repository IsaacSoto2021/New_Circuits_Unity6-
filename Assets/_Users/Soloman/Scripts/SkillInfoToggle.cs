using UnityEngine;

public class SkillInfoToggle : MonoBehaviour
{
    private bool isActive;
    public GameObject infoText;
    public GameObject upgradeButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        infoText.SetActive(false);
        upgradeButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        if (!isActive)
        {
            upgradeButton.SetActive(true);
            infoText.SetActive(true);
            isActive = true;
        }
        else if (isActive)
        {
            upgradeButton.SetActive(false);
            infoText.SetActive(false);
            isActive = false;
        }
    }
}
