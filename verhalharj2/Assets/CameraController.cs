using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Vector3 originalPosition;
    Quaternion originalRotation;
    public float zoomSpeed = 5;
    public float cameraYawSpeed = 20;
    public float cameraPitchSpeed = 20;
    public float cameraMoveSpeed = 10;
    float forward;
    float cameraPitch;
    float cameraMouseYaw;
    float cameraMoveX;
    float cameraMoveZ;
    float mouseScrlWheel;
    float mouseX;
    float mouseY;
    bool lookAtOn;
    public GameObject lookatObject;
    //GameManager gm;
    //Vector3 testLevel1Pos = new Vector3(-8.4f, 43f, 0);
    //Vector3 testLevel2Pos = new Vector3(135, 86, -585);

    void Start () {
        //transform.position = testLevel1Pos;
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        //gm = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
    //public void NextLevel() {
    //    if (gm.currentLevel == GameLevel.TestLevel1) {
    //        transform.position = testLevel1Pos;
    //        originalPosition = transform.position;
    //        transform.rotation = originalRotation;
    //    } else if (gm.currentLevel == GameLevel.TestLevel2) {
    //        transform.position = testLevel2Pos;
    //        originalPosition = transform.position;
    //        transform.rotation = originalRotation;
    //    } else {
    //        // paikkaan jossa joku taustakuva?
    //    }
    //}

	void Update () {

        //if (gm.currentState != GameState.Running || gm.currentLevel == GameLevel.None) {
        //    return;
        //}
        if (Input.GetKeyDown(KeyCode.L)) {
            if (!lookAtOn) {
                lookAtOn = true;
            } else {
                lookAtOn = false;
            }
        }

        if (lookAtOn) {
            transform.LookAt(lookatObject.transform);
            return;
        }
        mouseScrlWheel = Input.GetAxis("Mouse ScrollWheel");

        forward = mouseScrlWheel * zoomSpeed;

        transform.Translate(new Vector3(0, 0, forward), Space.Self);

        if (Input.GetKeyDown(KeyCode.Y)) {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
        }

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        if (Input.GetKey(KeyCode.Mouse2)) {
            cameraMouseYaw = mouseX * cameraYawSpeed / 3;
            cameraPitch = -mouseY * cameraPitchSpeed / 3;
        } else if (Input.GetKey(KeyCode.R)) {
            cameraPitch = -cameraPitchSpeed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.F)) {
            cameraPitch = cameraPitchSpeed * Time.deltaTime;
        } else {
            cameraPitch = 0;
        }

        transform.Rotate(cameraPitch, 0, 0);
        transform.Rotate(new Vector3(0, cameraMouseYaw, 0), Space.World);

        if (Input.GetKey(KeyCode.A)) {
            cameraMoveX = -cameraMoveSpeed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.D)) {
            cameraMoveX = cameraMoveSpeed * Time.deltaTime;
        } else {
            cameraMoveX = 0;
        }

        if (Input.GetKey(KeyCode.W)) {
            cameraMoveZ = cameraMoveSpeed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.S)) {
            cameraMoveZ = -cameraMoveSpeed * Time.deltaTime;
        } else {
            cameraMoveZ = 0;
        }

        transform.Translate(new Vector3(cameraMoveX, 0, cameraMoveZ), Space.Self);
    }
}
