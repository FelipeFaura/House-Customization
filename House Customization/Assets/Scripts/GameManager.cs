using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] CharacterMovement characterMovement;
    [SerializeField] CameraLook cameraLook;
    [SerializeField] ObjectDetector objectDetector;

    public static GameManager gameManager;

    private GameObject selectedObjectOnUI;

    public GameObject SelectedObjectOnUI { 
        get => selectedObjectOnUI; 
        set => selectedObjectOnUI = value; 
    }

    // Start is called before the first frame update

    void Awake() {
        if (gameManager == null) {
            gameManager = this;
        } else {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// UI has been activated, this method stops the player movement and create UI movement.
    /// </summary>
    public void UIActivated() {
        characterMovement.StopMovement();
        cameraLook.StopMovement();
        objectDetector.StopDetection();
        Cursor.lockState = CursorLockMode.None; 
    }

    /// <summary>
    /// UI has been deactivated, this method starts the player movement and stops UI movement.
    /// </summary>
    public void UIDisabled() {
        characterMovement.StartMovement();
        cameraLook.StartMovement();
        objectDetector.StartDetection();
        Cursor.lockState = CursorLockMode.Locked; 
    }

    /// <summary>
    /// Destroy the actual object that user manipulate.
    /// </summary>
    public void DestroyActualObject() {
        
        Destroy(SelectedObjectOnUI);

        // all destroy implications here.
    }
}
