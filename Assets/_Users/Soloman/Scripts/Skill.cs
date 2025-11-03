using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Skill
{
    public string skillName;
    public bool unlocked;
    public List<Skill> prerequisites;
    public Button skillButton;

    // Cost fields
    public int scrapCost;
    public int electronicsCost;
    public int cryptoCost;

    public Skill(string name, int scrap = 50, int electronics = 25, int crypto = 10)
    {
        skillName = name;
        unlocked = false;
        prerequisites = new List<Skill>();

        scrapCost = scrap;
        electronicsCost = electronics;
        cryptoCost = crypto;
    }

    // Check prerequisites and cost
    public bool CanUnlock()
    {
        foreach (Skill prereq in prerequisites)
        {
            if (!prereq.unlocked)
                return false;
        }

        // Check currencies
        return PlayerData.Instance._scrap >= scrapCost &&
               PlayerData.Instance._electronics >= electronicsCost &&
               PlayerData.Instance._crypto >= cryptoCost;
    }

    public void Unlock()
    {
        if (unlocked)
        {
            Debug.Log($"{skillName} already unlocked!");
            return;
        }

        if (!CanUnlock())
        {
            Debug.Log($"Cannot unlock {skillName} — missing prerequisites or not enough currency!");
            return;
        }

        // Deduct cost
        PlayerData.Instance._scrap -= scrapCost;
        PlayerData.Instance._electronics -= electronicsCost;
        PlayerData.Instance._crypto -= cryptoCost;

        unlocked = true;
        skillButton.interactable = false;

        Debug.Log($"{skillName} unlocked! Cost: {scrapCost} scrap, {electronicsCost} electronics, {cryptoCost} crypto.");

        // Apply effects based on tag
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
