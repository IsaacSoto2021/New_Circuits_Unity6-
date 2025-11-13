using UnityEngine;

public class DoorNew : MonoBehaviour
{
    public Transform _moveTo;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {


        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
