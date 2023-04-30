using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.EventSystems;

public class PlayerSetup : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public CharacterMovement movement;
    public GameObject xr;
    public GameObject menuController;
    public GameObject playerMenu;
    private Vector3[] kitchenSpawns = new Vector3[]{new Vector3(0,1,0), new Vector3(-2,1,-6), new Vector3(-6,1,-6), new Vector3(-6,1,1)};
    public int playerNumber;
    private bool first = false;

    public void IsLocalPlayer(int num)
    {
        movement.enabled = true;
        xr.SetActive(true);
        menuController.SetActive(true);
        playerMenu.SetActive(true);
        playerNumber = num; //THIS DOESN"T WORK, DO NOT USE
    }

    void Update() {
        if (!first)
        {
            first = true;
            xr.GetComponent<XRCardboardController>().EnableVR();
        }
    }

    [PunRPC]
    void teleportToKitchen()
    {
        this.transform.position = GenerateRandomVector();
    }

    private Vector3 GenerateRandomVector()
    {
        float xRangeMin = -2.5f;
        float xRangeMax = 2.5f;
        float zRangeMin = 3.5f;
        float zRangeMax = 6.5f;
        float fixedYValue = 1f;
        float x = Random.Range(xRangeMin, xRangeMax);
        float z = Random.Range(zRangeMin, zRangeMax);
        return new Vector3(x, fixedYValue, z);
    }

}
