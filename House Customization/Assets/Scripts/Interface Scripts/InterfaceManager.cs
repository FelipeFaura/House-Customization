using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    [Header("ActionSelection components")]
    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject editButton;
    [SerializeField] GameObject moveButton;
    [SerializeField] GameObject deleteButton;

    public static InterfaceManager interfaceManager;
    // Start is called before the first frame update

    void Awake() {
        if (interfaceManager == null) {
            interfaceManager = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableDisableActionSelector() {
        // getting Data
        SelectableObject elementScript = GameManager.gameManager.SelectedObjectOnUI.GetComponent<SelectableObject>();

        // UIAction Selector and buttons Activation 
        actionSelector.SetActive(!actionSelector.activeInHierarchy);
        deleteButton.SetActive(elementScript.IsRemovable);
    }

    public void CloseActionUIButton() { 

        // UI Action Selector Deactivation
        actionSelector.SetActive(!actionSelector.activeInHierarchy);
        GameManager.gameManager.UIDisabled();
    }

    public void DeleteSelectedElementButton() {
        GameManager.gameManager.DestroyActualObject(); ;
        actionSelector.SetActive(!actionSelector.activeInHierarchy);
        GameManager.gameManager.UIDisabled();
    }
}
