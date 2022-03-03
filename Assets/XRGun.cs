using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;

public class XRGun : MonoBehaviour
{



    public GameObject bullet;
    public Transform muzzle;
    public float force = 1000.0f;

    const float k_HeldThreshold = 0.1f;

    float m_TriggerHeldTime;
    bool m_TriggerDown;


    XRGrabInteractable m_InteractableBase;


    // Start is called before the first frame update
    void Start()
    {
        m_InteractableBase = GetComponent<XRGrabInteractable>();

        m_InteractableBase.selectExited.AddListener(DroppedGun);
        m_InteractableBase.activated.AddListener(TriggerPulled);
        m_InteractableBase.deactivated.AddListener(TriggerReleased);

    }

    // Update is called once per frame
    void Update()
    {
        if (m_TriggerDown)
        {
            m_TriggerHeldTime += Time.deltaTime;

            if (m_TriggerHeldTime >= k_HeldThreshold)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {

        GameObject go = Instantiate(bullet, muzzle);
        go.GetComponent<Rigidbody>().AddForce(muzzle.forward * force);


    }



    void TriggerReleased(DeactivateEventArgs args)
    {

        m_TriggerDown = false;
        m_TriggerHeldTime = 0f;

    }

    void TriggerPulled(ActivateEventArgs args)
    {

        m_TriggerDown = true;
    }

    void DroppedGun(SelectExitEventArgs args)
    {
        // In case the gun is dropped while in use.


        m_TriggerDown = false;
        m_TriggerHeldTime = 0f;

    }
}
