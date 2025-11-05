using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SkillTreeManager : MonoBehaviour
{
    public void ClickReturnFromSkillTree()
    {
        GameManager.Instance.ReturnFromSkillTree();
    }
}
