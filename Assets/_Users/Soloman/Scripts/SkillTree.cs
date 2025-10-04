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
        // Create skills
        Skill root = new Skill("Root Skill");
        Skill tier1 = new Skill("Tier 1 Skill");
        Skill tier2 = new Skill("Tier 2 Skill");

        // Assign buttons
        root.skillButton = rootButton;
        tier1.skillButton = tier1Button;
        tier2.skillButton = tier2Button;

        // Set prerequisites
        tier1.prerequisites.Add(root);
        tier2.prerequisites.Add(tier1);

        // Add to list
        allSkills.Add(root);
        allSkills.Add(tier1);
        allSkills.Add(tier2);

        // Hook up button clicks
        rootButton.onClick.AddListener(() => root.Unlock());
        tier1Button.onClick.AddListener(() => tier1.Unlock());
        tier2Button.onClick.AddListener(() => tier2.Unlock());

        // Initially, only the root button is interactable
        rootButton.interactable = true;
        tier1Button.interactable = true;  // player can click, but unlock will fail until root is done
        tier2Button.interactable = true;  // same here
    }
}
