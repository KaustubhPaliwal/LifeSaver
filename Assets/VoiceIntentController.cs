using Oculus.Voice;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.InputSystem;

public class VoiceIntentController : MonoBehaviour
{
    [Header("Voice")]
    [SerializeField]
    private AppVoiceExperience appVoiceExperience;

    public Canvas patientConsent;
    public Canvas medicalEquipment;
    public Canvas torniquet;
    public Canvas diagnosisScan;
    public Canvas mapMenu;
    public Canvas scanLoading;
    public Canvas page4;
    public int itemCount;
    public GameObject patient;
    public Material temperature;
    public AudioSource scanSound; // Reference to the AudioSource component for playing the sound

    // Start is called before the first frame update
    void Start()
    {
        itemCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            appVoiceExperience.Activate();
        }
    }

    public void Consent(String[] info)
    {
        Debug.Log("Accepted:" + info[0]);
        patientConsent.gameObject.SetActive(false);
        medicalEquipment.gameObject.SetActive(true);
    }

    public void CheckOff(String[] info)
    {
        if (itemCount < medicalEquipment.transform.childCount)
        {
            if (medicalEquipment.transform.GetChild(itemCount).gameObject.name == "Antiseptic")
            {
                medicalEquipment.gameObject.SetActive(false);
                torniquet.gameObject.SetActive(true);
                return;
            }

            Debug.Log("Entered Checkoff: Name:" + medicalEquipment.transform.GetChild(itemCount).gameObject.name);
            Debug.Log("Name of children:" + medicalEquipment.transform.GetChild(itemCount).GetChild(1).gameObject.name);
            medicalEquipment.transform.GetChild(itemCount).GetChild(1).gameObject.GetComponent<Text>().color = Color.black;
            medicalEquipment.transform.GetChild(itemCount + 1).GetChild(1).gameObject.GetComponent<Text>().color = Color.red;
            medicalEquipment.transform.GetChild(itemCount).GetChild(0).gameObject.SetActive(false);
            itemCount++;
        }
    }

    public void bodyScan(String[] info)
    {
        Debug.Log("Body Scanned" + info[0]);
        StartCoroutine(BodyScanRoutine());
    }

    private IEnumerator BodyScanRoutine()
    {
        scanLoading.gameObject.SetActive(true);
        scanSound.Play(); // Play the sound
        Material temp = patient.GetComponent<SkinnedMeshRenderer>().material;
        patient.GetComponent<SkinnedMeshRenderer>().material = temperature; 
        yield return new WaitForSeconds(3f);
        scanLoading.gameObject.SetActive(false);
        diagnosisScan.gameObject.SetActive(true);
        patient.GetComponent<SkinnedMeshRenderer>().material = temp;
    }

    public void askConsent(String[] info)
    {
        diagnosisScan.gameObject.SetActive(false);
        patientConsent.gameObject.SetActive(true);
    }

    public void mapSearch(String[] info)
    {
        torniquet.gameObject.SetActive(false);
        mapMenu.gameObject.SetActive(true);
    }

    public void Page4(String[] info)
    {
        Debug.Log("Entered Page4");
        torniquet.gameObject.SetActive(false);
        page4.gameObject.SetActive(true);
    }
}
