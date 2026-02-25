using UnityEngine;

public class PlayerRaycastPushWall : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Rigidbody wallRB;
    [SerializeField] GameObject wallGO;

    [SerializeField] float force;
    [SerializeField] float rayDistance = 3.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        wallRB = wallGO.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.right * rayDistance, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.right, out hit, rayDistance))
        {
            if (hit.collider.name == "Wall")
            {
                Debug.Log("Hit: " + hit.collider.name);
                Debug.DrawRay(transform.position, Vector3.right * rayDistance, Color.red);

                if (wallRB != null) //คำสั่งนี้ไม่มีก็ได้ ไม่หักคะแนน
                {
                    wallRB.AddForce(Vector3.right * force);
                }

            }
        }
    }
}
