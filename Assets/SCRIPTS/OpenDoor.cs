using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenDoor : MonoBehaviour
{
    public GameObject objectName;
    public GameObject player;
    bool open;
    string B;
    private string[] bMap;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        bMap = player.GetComponent<ButtonMapping>().getMap();
        open = false;

    // <- Key Mappings -> 
        B = bMap[1];
    }

    // Update is called once per frame
    void Update()
    {
        GameObject objectName = player.GetComponent<ActiveGameObject>().getActiveObject();
        if (objectName != null && objectName.name == "Fridge-DoorUpper")
        {
            player.GetComponent<InteractionQueueBehavior>().SetQueueMessage("Press B to Interact");
        }
        if(Input.GetButtonDown(B) && objectName != null && objectName.name == "Fridge-DoorUpper" && open==false) {
            objectName.transform.eulerAngles = new Vector3(0.0f, 60.0f, 0.0f);
            open = true;
            AudioSource.PlayClipAtPoint(clip, objectName.transform.position, 0.5f);
        }
        else if(Input.GetButtonDown(B) && objectName != null && objectName.name == "Fridge-DoorUpper" && open==true) {
            objectName.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            open = false;
            AudioSource.PlayClipAtPoint(clip, objectName.transform.position, 0.5f);
        }
    }
}
