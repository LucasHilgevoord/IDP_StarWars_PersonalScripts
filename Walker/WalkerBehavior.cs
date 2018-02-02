using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerBehavior : MonoBehaviour
{

    private GameObject target;
    [SerializeField]
    public Transform body;
    [SerializeField]
    public Transform head;

    private int range = 30;
    private int rotationSpeed = 10;
    private float fireRate = 3;
    private float fireCountdown = 0f;

    [SerializeField]
    public GameObject bulletPrefab;
    [SerializeField]
    public Transform firePointA;
    [SerializeField]
    public Transform firePointB;
    [SerializeField]
    public Transform firePointC;
    [SerializeField]
    public Transform firePointD;

    [SerializeField]
    public AudioClip shootSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Zoek Target
        //-=VERSIMPEL=-
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) < range)
            {
                Debug.Log("In Range");
                if (target.transform.position.y < transform.position.y)
                {
                    //Als de player lager is dan y0 dan blijft de y0.
                    head.rotation = Quaternion.Slerp(head.rotation, body.rotation, Time.deltaTime * rotationSpeed);
                }
                else
                {
                    //Als de player hoger is dan y0 dan kijkt blijft hij volgen.
                    //var lookPos = target.transform.position - transform.position;
                    //var rotation = Quaternion.LookRotation(lookPos);
                    //head.rotation = Quaternion.Slerp(head.rotation, rotation, Time.deltaTime * rotationSpeed);

                    //Schiet wanneer player in range is en de cooldown op is.
                    if (fireCountdown <= 0f)
                    {
                        StartCoroutine(Shoot());
                        fireCountdown = 1f / fireRate;
                    }

                    fireCountdown -= Time.deltaTime;
                }
            }
            else
            {
                //Als Player niet in range is dan blijft hij de body volgen.
                head.rotation = Quaternion.Slerp(head.rotation, body.rotation, Time.deltaTime * rotationSpeed);
            }
        }
    }

    IEnumerator Shoot()
    {
        Debug.Log("Test");
        Instantiate(bulletPrefab, firePointA.position, head.rotation);
        Instantiate(bulletPrefab, firePointC.position, head.rotation);
        audioSource.PlayOneShot(shootSound, 0.7F);
        yield return new WaitForSeconds(1f);
        Instantiate(bulletPrefab, firePointB.position, head.rotation);
        Instantiate(bulletPrefab, firePointD.position, head.rotation);

    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}