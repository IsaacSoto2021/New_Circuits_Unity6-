using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Skill
{
    public string skillName;
    public bool unlocked;
    public List<Skill> prerequisites;
    public Button skillButton; // UI button

    public Skill(string name)
    {
        skillName = name;
        unlocked = false;
        prerequisites = new List<Skill>();
    }

    public bool CanUnlock()
    {
        foreach (Skill prereq in prerequisites)
        {
            if (!prereq.unlocked)
                return false;
        }
        return true;
    }

    public void Unlock()
    {
        if (CanUnlock() && !unlocked)
        {
            unlocked = true;
            skillButton.interactable = false; // disable button after unlocking

            if (skillButton.CompareTag("MaxHpUpgrade"))
            {
                PlayerData.Instance._maxHp += 50;
                Debug.Log("max hp increased to " + PlayerData.Instance._maxHp);
            }
            else if (skillButton.CompareTag("SpeedUpgrade"))
            {
                PlayerData.Instance._moveSpeed += 0.5f;
                Debug.Log("speed increased to " + PlayerData.Instance._moveSpeed);
            }
            else if (skillButton.CompareTag("DamageUpgrade"))
            {
                PlayerData.Instance._damage += 25;
                Debug.Log("damage increased to " + PlayerData.Instance._damage);
            }
        }
    }
}
