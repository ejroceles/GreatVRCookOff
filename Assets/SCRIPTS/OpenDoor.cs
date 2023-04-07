using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenDoor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject objectName;
    public GameObject player;
    bool hover;
    bool open;
    string keyX;
    private string[] bMap;

    // Start is called before the first frame update
    void Start()
    {
        bMap = player.GetComponent<ButtonMapping>().getMap();
        hover = false;
        open = false;

    // <- Key Mappings -> 
        keyX=bMap[2];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown(keyX) && hover==true && open==false) {
            objectName.transform.eulerAngles = new Vector3(0.0f, 60.0f, 0.0f);
            open = true;
        }
        else if(Input.GetButtonDown(keyX) && hover==true && open==true) {
            objectName.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            open = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        hover = true;
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        hover = false;
    }
}
