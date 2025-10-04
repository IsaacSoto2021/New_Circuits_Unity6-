using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    private bool playerInside = false;
    public bool hasLock = false;
    public bool hasKeycardLock = false;
    public GameObject targetGameObject;

    public TextMeshProUGUI textElement;

    public GameObject buttonOne;
    public GameObject buttonTwo;
    public GameObject buttonThree;
    public GameObject buttonFour;
    public GameObject codeDisplay;

    // sequence tracking
    public List<int> correctSequence = new List<int>();
    private List<int> playerInput = new List<int>();

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;

            if (hasLock)
            {
                // Generate a new random sequence (1–4)
                correctSequence = GenerateRandomSequence();

                // Display buttons and code UI
                buttonOne.SetActive(true);
                buttonTwo.SetActive(true);
                buttonThree.SetActive(true);
                buttonFour.SetActive(true);

                codeDisplay.SetActive(true);

                // Flash the sequence to player
                StartCoroutine(ShowSequence());
            }
            else if (hasKeycardLock)
            {
                PlayerData.Instance._hasKeycard = false;
                UnlockDoor();
            }
            else
            {
                // Unlock instantly if no lock
                UnlockDoor();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    public void RegisterInput(int buttonNumber)
    {
        if (!playerInside || !hasLock)
        {
            return;
        }

        playerInput.Add(buttonNumber);

        // Check if input matches so far
        int currentIndex = playerInput.Count - 1;
        if (playerInput[currentIndex] != correctSequence[currentIndex])
        {
            playerInput.Clear();
            return;
        }

        // If the whole sequence is correct
        if (playerInput.Count == correctSequence.Count)
        {
            UnlockDoor();
            playerInput.Clear();
        }
    }

    // generate random order of 1–4
    private List<int> GenerateRandomSequence()
    {
        List<int> sequence = new List<int>() { 1, 2, 3, 4 };
        for (int i = 0; i < sequence.Count; i++)
        {
            int randomIndex = Random.Range(i, sequence.Count);
            int temp = sequence[i];
            sequence[i] = sequence[randomIndex];
            sequence[randomIndex] = temp;
        }
        return sequence;
    }

    // flash numbers one at a time
    private IEnumerator ShowSequence()
    {
        textElement.text = "";

        foreach (int number in correctSequence)
        {
            textElement.text = number.ToString();
            yield return new WaitForSeconds(1f); // show number
            textElement.text = "";
            yield return new WaitForSeconds(0.3f); // small pause before next
        }
    }

    private void UnlockDoor()
    {
        GetComponent<Collider>().enabled = false;
        targetGameObject.GetComponent<MeshRenderer>().enabled = false;
        targetGameObject.GetComponent<Collider>().enabled = false;
    }

    void Start()
    {

    }

    void Update()
    {
        
    }
}


