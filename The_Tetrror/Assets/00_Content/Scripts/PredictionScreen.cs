using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictionScreen : MonoBehaviour
{
    [SerializeField] private GameObject screenPoint;
    
    private Quaternion rotation;

    public Quaternion Rotation { get { return rotation; } }

    //Needs a "null sprite" that it shows if it doesn't have a sprite at screenPoint.

    void Start()
    {
        
    }

    public void SetOnScreen(Sprite sprite, Quaternion rotation) {
        if(screenPoint == null) {
            Debug.Log($"{screenPoint.name} was null and couldn't show a picture.");
            return;
        }

        this.rotation = rotation;

        screenPoint.GetComponent<SpriteRenderer>().sprite = sprite;
        screenPoint.transform.rotation = this.rotation;
    }
}
