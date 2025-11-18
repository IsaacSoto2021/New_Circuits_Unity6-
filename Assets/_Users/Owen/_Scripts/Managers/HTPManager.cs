using UnityEngine;

public class HTPManager : MonoBehaviour
{
    public void ClickBackToHQ()
    {
        GameManager.Instance.Return();
    }
}
