using UnityEngine;

public class BoxPushUp : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Rigidbody rotateObjRB;
    [SerializeField] GameObject rotateObj;

    [SerializeField] float force;
    [SerializeField] float torque;
    [SerializeField] float rayDistance = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rotateObjRB = rotateObj.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.yellow);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, rayDistance))
        {
            if (hit.collider.name == "Capsule")
            {
                Debug.Log("Hit: " + hit.collider.name);
                Debug.DrawRay(transform.position, Vector3.down * rayDistance, Color.red);

                if (rb != null) //คำสั่งนี้ไม่มีก็ได้ ไม่หักคะแนน
                {
                    rb.AddForce(Vector3.up * force, ForceMode.Impulse);
                    rotateObjRB.isKinematic = true;
                }

            }
        }
    }
}
