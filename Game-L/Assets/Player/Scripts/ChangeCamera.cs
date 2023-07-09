using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject TPCamera;
    public GameObject TPPlayer;
    public int currentCamera;
    private Transform parentTransform;
    private Transform targetChildTransform;
    private Transform targetChildTransform1;
    private Transform targetChildTransform2;
    private Transform targetChildTransform3;
    private Transform targetChildTransform4;
    private Transform targetChildTransform5;

    private void Start()
    {
        parentTransform = transform.parent;
        targetChildTransform = transform.parent.Find("Main Camera");
        targetChildTransform1 = transform.parent.Find("Main Camera/WeaponHolder");
        targetChildTransform2 = transform.parent.Find("Main Camera/WeaponHolder/M4");
        targetChildTransform3 = transform.parent.Find("Main Camera/WeaponHolder/Pistol");
        targetChildTransform4 = transform.parent.Find("Main Camera/WeaponHolder/M4/M4_Carbine");
        targetChildTransform5 = transform.parent.Find("Main Camera/WeaponHolder/Pistol/Pistol");
    }

    void Update()
    {
        if (Input.GetButtonDown("ChangeCamera"))
        {
            if (currentCamera == 1)
            {
                currentCamera = 0;
            }
            else 
            {
                currentCamera = 1;
            }
            StartCoroutine (ChCamera());
        }        
    }

    IEnumerator ChCamera() {
        yield return new WaitForSeconds(0.1f);
        if(currentCamera == 0)
        {
            TPCamera.SetActive(false);
            TPPlayer.SetActive(false);
            parentTransform.GetComponent<PlayerMovment>().enabled = true;
            targetChildTransform.GetComponent<Camera>().enabled = true;
            targetChildTransform1.GetComponent<WeaponSwitching>().enabled = true;
            targetChildTransform2.GetComponent<Gun>().enabled = true;
            targetChildTransform3.GetComponent<Gun1>().enabled = true;
            targetChildTransform4.GetComponent<MeshRenderer>().enabled = true;
            targetChildTransform5.GetComponent<MeshRenderer>().enabled = true;
        }
        if(currentCamera == 1)
        {
            TPCamera.SetActive(true);
            TPPlayer.SetActive(true);
            parentTransform.GetComponent<PlayerMovment>().enabled = false;
            targetChildTransform.GetComponent<Camera>().enabled = false;
            targetChildTransform1.GetComponent<WeaponSwitching>().enabled = false;
            targetChildTransform2.GetComponent<Gun>().enabled = false;
            targetChildTransform3.GetComponent<Gun1>().enabled = false;
            targetChildTransform4.GetComponent<MeshRenderer>().enabled = false;
            targetChildTransform5.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
