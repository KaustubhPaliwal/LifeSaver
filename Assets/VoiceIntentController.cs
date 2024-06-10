using Oculus.Voice;
using System;
using System.Linq;
using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine;
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
    public int itemCount;
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

        // Instantiate the new canvas at the same position and rotation
        medicalEquipment.gameObject.SetActive(true);
    }

    public void CheckOff(String[] info)
    {
        if(itemCount < medicalEquipment.transform.childCount)
        {
            if (medicalEquipment.transform.GetChild(itemCount).gameObject.name == "Antiseptic")
            {
                // Get the position and rotation of the canvas to be destroyed
                Vector3 position = medicalEquipment.transform.position;
                Quaternion rotation = medicalEquipment.transform.rotation;
                Transform parent = medicalEquipment.transform.parent;

                // Destroy the old canvas
                medicalEquipment.gameObject.SetActive(false);

                // Instantiate the new canvas at the same position and rotation
                torniquet.gameObject.SetActive(true);
            }

            Debug.Log("Entered Checkoff: Name:" + medicalEquipment.transform.GetChild(itemCount).gameObject.name);
            Debug.Log("Name of children:" + medicalEquipment.transform.GetChild(itemCount).GetChild(1).gameObject.name);
            medicalEquipment.transform.GetChild(itemCount).GetChild(1).gameObject.GetComponent<Text>().color = Color.black;
            medicalEquipment.transform.GetChild(itemCount+1).GetChild(1).gameObject.GetComponent<Text>().color = Color.red;
            medicalEquipment.transform.GetChild(itemCount).GetChild(0).gameObject.SetActive(false);
            itemCount++;
        }
    }

    public void bodyScan(String[] info)
    {
        Debug.Log("Body Scanned" + info[0]);
        diagnosisScan.gameObject.SetActive(true);
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
}
