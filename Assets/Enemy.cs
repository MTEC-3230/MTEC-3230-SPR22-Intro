using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public ParticleSystem particleSystem;


    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;


    Vector3 newPosition;


    // Start is called before the first frame update
    void Start()
    {

        float randomStartTime = Random.Range(0, 10f);
        float randomRepeatTime = Random.Range(2, 6); 
        InvokeRepeating("MoveToRandomPosition", randomStartTime, randomRepeatTime);

        Renderer rend;
        rend = this.gameObject.GetComponent<Renderer>();

        rend.material.color = GetRandomColor();

        newPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the journey length.


        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(this.transform.position, newPosition, fractionOfJourney);
    }

    // Handles Enemy Death

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Bullet>())
        {
            particleSystem.Emit(100);
            this.gameObject.GetComponent<Renderer>().enabled = false; 
            Destroy(this.gameObject,2.0f); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        MoveToRandomPosition();
    }


    // Handles Enemy Movement
    void MoveToRandomPosition()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;
        newPosition = new Vector3(Random.Range(-10, 10), 1.0f, Random.Range(-10, 10));
        journeyLength = Vector3.Distance(this.transform.position, newPosition);

    }


    Color GetRandomColor()
    {

        return new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }
}
