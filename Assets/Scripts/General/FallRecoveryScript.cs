using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallRecoveryScript : MonoBehaviour
{
    public bool enableRespawn, disableRespawn;
    public GameObject respawnNotice;
    private LevelManagerScript levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManagerScript>();

        respawnNotice = GameObject.Find("checkpointNotice");
        //recoveryNotice.GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(enableRespawn)
            {
                levelManager.respawn = true;
                respawnNotice.GetComponent<Text>().text = "Respawning Enabled";
                StartCoroutine(ClearText());
            }

            else if(disableRespawn)
            {
                levelManager.respawn = false;
                respawnNotice.GetComponent<Text>().text = "Respawning Disabled";
                StartCoroutine(ClearText());
            }
        }
    }

    private IEnumerator ClearText()
    {
        yield return new WaitForSeconds(4f);
        respawnNotice.GetComponent<Text>().text = "";
        gameObject.SetActive(false);
    }
}
