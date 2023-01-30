using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float inputX;
    float inputY;

    public Transform Model;

    Animator Anim;

    Vector3 StickDirection;

    Camera MainCam;

    public float damp;

    [Range(1,20)]
    public float rotationSpeed;
    private void Start() {
        Anim = GetComponent<Animator>();
        MainCam = Camera.main;
    }
    private void LateUpdate() {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        StickDirection = new Vector3(inputX,0,inputY);
        inputMove();
        inputRotation();

    }
    [SerializeField]Rigidbody rb;
    void inputMove(){
        Anim.SetFloat("speed",Vector3.ClampMagnitude(StickDirection,1).magnitude, damp , Time.deltaTime * 10);
        // rb.MovePosition(StickDirection);
        transform.Translate(StickDirection);

    }
    void inputRotation() {
        Vector3 rotOfSet = MainCam.transform.TransformDirection(StickDirection);
        rotOfSet.y = 0;

        Model.forward = Vector3.Slerp(Model.forward, rotOfSet, Time.deltaTime * rotationSpeed);
    }
}
