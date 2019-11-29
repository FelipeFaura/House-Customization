using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private string selectableObjectTag = "SelectableObject";
    [SerializeField] private Material selectedMaterial;

    private Transform objectTouched;
    private GameObject lastObjectTouched;
    private Material defaultSelectedMaterial;
    private bool isDetecting = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast Detector
        if (isDetecting) {


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                objectTouched = hit.transform;
                if (objectTouched.gameObject.CompareTag(selectableObjectTag)) {
                    if (lastObjectTouched != null) {
                        lastObjectTouched.gameObject.GetComponent<SelectableObject>().UnselectObject();
                    }
                    objectTouched.gameObject.GetComponent<Renderer>().material = selectedMaterial;
                    lastObjectTouched = objectTouched.gameObject;
                } else {
                    if (lastObjectTouched != null) {
                        lastObjectTouched.gameObject.GetComponent<SelectableObject>().UnselectObject();
                    }
                }
            }
        

            if (Input.GetMouseButtonDown(0)) {
                if (objectTouched != null && objectTouched.gameObject.CompareTag(selectableObjectTag)) {
                    GameManager.gameManager.SelectedObjectOnUI = objectTouched.gameObject;
                    InterfaceManager.interfaceManager.EnableDisableActionSelector();
                    GameManager.gameManager.UIActivated();
                }
            
            }
        }
    }

    public void StopDetection() {
        isDetecting = false;
    }
    public void StartDetection() {
        isDetecting = true;
    }
}
