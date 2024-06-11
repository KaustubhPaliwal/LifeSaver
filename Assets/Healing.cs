using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public Canvas healingDone;
    public Canvas transfStart;
    public GameObject healing;
    public Canvas page4;
    public GameObject wrist;
    public Material Highlight;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Vaccine"))
        {
            Destroy(other.gameObject);
            StartCoroutine(BodyScanRoutine());
        }
    }

    private IEnumerator BodyScanRoutine()
    {
        healing.SetActive(true);
        Destroy(this.GetComponent<SpriteRenderer>());
        page4.gameObject.SetActive(false);
        healingDone.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        healingDone.gameObject.SetActive(false);
        transfStart.gameObject.SetActive(true);
        wrist.GetComponent<MeshRenderer>().material = Highlight;
    }
}
