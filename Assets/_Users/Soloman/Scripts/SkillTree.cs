using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    public List<Skill> allSkills = new List<Skill>();

    [Header("UI Buttons")]
    public Button rootButton;
    public Button tier1Button;
    public Button tier2Button;

    void Start()
    {
        // Create skills with actual currency costs
        Skill root = new Skill("Root Skill", scrap: 50, electronics: 25, crypto: 10);
        Skill tier1 = new Skill("Tier 1 Skill", scrap: 150, electronics: 50, crypto: 25);
        Skill tier2 = new Skill("Tier 2 Skill", scrap: 300, electronics: 100, crypto: 50);

        // Assign UI buttons
        root.skillButton = rootButton;
        tier1.skillButton = tier1Button;
        tier2.skillButton = tier2Button;

        // Set prerequisites
        // Tier 1 requires Root
        tier1.prerequisites.Add(root);
        // Tier 2 requires Tier 1
        tier2.prerequisites.Add(tier1);

        // Add all to list (optional for future expansion)
        allSkills.Add(root);
        allSkills.Add(tier1);
        allSkills.Add(tier2);

        // Hook up button clicks
        rootButton.onClick.AddListener(() => root.Unlock());
        tier1Button.onClick.AddListener(() => tier1.Unlock());
        tier2Button.onClick.AddListener(() => tier2.Unlock());

        // All buttons start interactable (checks happen inside Unlock)
        rootButton.interactable = true;
        tier1Button.interactable = true;
        tier2Button.interactable = true;
    }
}
