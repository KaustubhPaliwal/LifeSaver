using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodTransfusion : MonoBehaviour
{
    public Canvas transfStart;
    public Canvas transfOn;
    public Canvas transfDone;
    public Canvas vitalCheck;
    public Canvas vitalScan;
    public GameObject wrist;
    public Material wristDefault;
    public Material wristNew;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name==("Blood_Bag"))
        {
            StartCoroutine(BodyScanRoutine());
        }
    }

    private IEnumerator BodyScanRoutine()
    {
        Destroy(wrist.GetComponent<SpriteRenderer>());
        transfStart.gameObject.SetActive(false);
        transfOn.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        transfOn.gameObject.SetActive(false);
        transfDone.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Debug.Log("Transmission worked");
        transfDone.gameObject.SetActive(false);
        vitalCheck.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        vitalCheck.gameObject.SetActive(false);
        vitalScan.gameObject.SetActive(true);
    }
}

