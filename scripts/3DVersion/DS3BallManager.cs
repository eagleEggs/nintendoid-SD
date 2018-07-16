using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DS3BallManager : MonoBehaviour
{

    [SerializeField] private GameObject DS;
    [SerializeField] private GameObject topScreenCollider;
    [SerializeField] private GameObject bottomScreenCollider;
    [SerializeField] private GameObject dsStylus;
    [SerializeField] private int collisionForce;
    private bool onTopScreen;
    private bool onBottomScreen;
    private int topRotateAmount = -90;
    private int bottomRotateAmount = 90;
    private bool rotated = false;

    void Start()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {


            this.GetComponent<Rigidbody>().AddForce(transform.forward * collisionForce);


        if (collision.gameObject.tag == "topScreen" && rotated == false)
        {
            DS.transform.Rotate(transform.position.x, transform.position.y, topRotateAmount);
            rotated = true;

        }

        if (collision.gameObject.tag == "bottomScreen" && rotated == true)
        {

            DS.transform.Rotate(transform.position.x, transform.position.y, bottomRotateAmount);
            rotated = false;

        }



    }


}
