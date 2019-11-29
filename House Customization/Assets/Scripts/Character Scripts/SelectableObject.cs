using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    [SerializeField] private int number = 23;
    [SerializeField] private bool isRemovable;

    private Material baseMaterial;

    public bool IsRemovable { 
        get => isRemovable; 
    }

    // Start is called before the first frame update
    void Start()
    {
        baseMaterial = this.gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UnselectObject() {
        this.gameObject.GetComponent<Renderer>().material = baseMaterial;
    }
}
