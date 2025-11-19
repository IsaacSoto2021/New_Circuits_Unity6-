using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class DoorNew : MonoBehaviour
{
    public GameObject TheDore;
    public Transform Movespot;
    public Vector3 _moveTo;
    public Vector3 _originalPos;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoveDoorDown();
        }
        if (collision.CompareTag("Enemy"))
        {
            MoveDoorDown();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoveDoorUp();
        }
        if (collision.CompareTag("Enemy"))
        {
            MoveDoorUp();
        }

    }
    public IEnumerator Opendoor()
    {
        TheDore.SetActive(false);
        yield return new WaitForSeconds(3);
        TheDore.SetActive(true);
    }
    private void MoveDoorDown()
    {
        TheDore.SetActive(false);

    }
    private void MoveDoorUp()
    {
        TheDore.SetActive(true);

    }
    void Start()
    {
        _originalPos = TheDore.transform.position;
        _moveTo = Movespot.position;
    }
}
