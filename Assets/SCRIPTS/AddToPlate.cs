using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AddToPlate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject player;
    private bool reticlein;
    private string B;
    // Start is called before the first frame update
    void Start()
    {
        B = "js10";
    }

    // Update is called once per frame
    void Update()
    {
        if(reticlein && player.GetComponent<Holding>().heldObj.name == "SpatulaSW")
        {
            if(Input.GetButtonDown(B))
            {
                Debug.Log("Finishing Screen"); //Change to winning screen
            }
        }                    
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        reticlein = true;
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        reticlein = false;
    } 
}
