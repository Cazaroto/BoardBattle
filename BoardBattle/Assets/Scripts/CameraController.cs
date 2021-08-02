using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Private Variables

    Transform basePosition;

    #endregion

    #region Public Variables

    [Header("Game Objects")]
    public Transform LookAtObject;

    [Header("Settings")]
    public float smoothSpeed = 0.125f;
    public Vector3 offSet;

    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        basePosition = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(LookAtObject)
        {
            Vector3 desiredPosition = LookAtObject.position + offSet;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;

            transform.LookAt(LookAtObject);
        }
    }
}
