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
    public GameObject Thermo;
    public Material ThermoDefault;
    public Material ThermoNew;

    private void Start()
    {
        Thermo.GetComponent<MeshRenderer>().material = ThermoNew;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Thermometer"))
        {
            StartCoroutine(BodyScanRoutine());
        }
    }

    private IEnumerator BodyScanRoutine()
    {
        Thermo.GetComponent<MeshRenderer>().material = ThermoDefault;
        healing.SetActive(true);
        Destroy(this.GetComponent<SpriteRenderer>());
        page4.gameObject.SetActive(false);
        healingDone.gameObject.SetActive(true);
        healingDone.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(3f);
        healingDone.gameObject.SetActive(false);
        transfStart.gameObject.SetActive(true);
        wrist.GetComponent<MeshRenderer>().material = Highlight;
    }
}
