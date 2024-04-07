using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gamemanager : MonoBehaviour
{

    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;


    bool gameStarted = false;

    public GameObject tapText;

    public TextMeshProUGUI Scoretext;

    int score = 0;
 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawning();

            gameStarted = true;
            tapText.SetActive(false);
            
        }

    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    private void SpawnBlock()
{
    Vector3 spawnPos = spawnPoint.position;
    spawnPos.x = Random.Range(-maxX,maxX);
    
    // Instantiate a new block GameObject
    GameObject newBlock = Instantiate(block, spawnPos, Quaternion.identity);

    // Check if the newBlock is null before accessing it
    if (newBlock != null)
    {
        // Increment the score and update the Scoretext
        score++;
        Scoretext.text = score.ToString();
    }
    else
    {
        // Handle the case where the newBlock is null (optional)
        Debug.LogWarning("Failed to instantiate block.");
    }
}

}
