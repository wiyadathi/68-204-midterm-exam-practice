using UnityEngine;
using UnityEngine.InputSystem.HID;

public class RotateWithTorque : MonoBehaviour
{
    [SerializeField] Rigidbody bodyRb;
    [SerializeField] Rigidbody rotorRb;

    [SerializeField] float spinTorque;
    [SerializeField] float rayDistance = 3.0f;

    void Start()
    {
        bodyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.blue);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayDistance))
        {
            if (hit.collider.name == "Ground")
            {
                Debug.Log("Hit: " + hit.collider.name);
                Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.yellowGreen);

                StopHeli(); //helicopter stop moving

                if (rotorRb != null) //คำสั่งนี้ไม่มีก็ได้ ไม่หักคะแนน
                {
                    rotorRb.AddTorque(0, spinTorque, 0, ForceMode.Acceleration);
                }

            }
        }
    }

    void FixedUpdate()
    {

           

    }

    void StopHeli()
    {
        //reset helicopter's velocity to stop instantly
        bodyRb.linearVelocity = Vector3.zero;
        bodyRb.angularVelocity = Vector3.zero;

        // heli stop moving
        bodyRb.isKinematic = true;
        //bodyRb.useGravity = false;

        Debug.Log("Helicopter is now Hovering!");
    }
}
