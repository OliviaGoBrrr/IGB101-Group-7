using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public Text pickupText;

    //Audio Proximity Logic
    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;

    // Pickup and Level Completion Logic
    public int currentPickups = 0;
    public int maxPickups = 5;
    public bool levelComplete = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LevelCompleteCheck();
        UpdateGUI();
        PlayAudioSamples();
    }

    private void LevelCompleteCheck()
    {
        // Once player has gotten all pickups, complete the level
        if (currentPickups >= maxPickups)
            levelComplete = true;

        else
            levelComplete = false;
    }

    //Loop for playing audio proximity events - AudioSource based
    private void PlayAudioSamples()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {

            if (Vector3.Distance(Player.transform.position, audioSources[i].transform.position) <= audioProximity)
            {

                if (!audioSources[i].isPlaying)
                {

                    audioSources[i].Play();
                }

            }
        }
    }

    private void UpdateGUI()
    {
        pickupText.text = "Pickups:" + currentPickups + "/" + maxPickups;
    }
}
