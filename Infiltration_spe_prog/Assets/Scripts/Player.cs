using System.Collections.Generic;
using UnityEngine;

//using random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField, Tooltip("Characontroller")]
    CharacterController m_characterController;
    float m_dirX;
    float m_dirY;
    [SerializeField, Tooltip("La vitesse m/s")]
    float m_speed = 10;

    [SerializeField, Tooltip("Trousseau de clé")]
    List<Keytype> m_Keylist;

    [SerializeField, Tooltip("Layer des portes")]
    LayerMask m_doorLayer;
    [SerializeField, Tooltip("Layer des box")]
    LayerMask m_boxLayer;

    [SerializeField, Tooltip("Rotation degré par seconde")]
    private float m_rotateSpeed = 90;

    private void Update()
    {
        m_dirX = Input.GetAxis("Horizontal");
        m_dirY = Input.GetAxis("Vertical");

        float deltaSpeed = m_speed * Time.deltaTime;

        m_characterController.transform.Rotate(0, m_dirX * m_rotateSpeed * Time.deltaTime, 0);

        Vector3 movement = transform.forward * Input.GetAxis("Vertical") * m_speed;

        m_characterController.Move(movement * Time.deltaTime);

        //m_characterController.Move(new Vector3(m_dirX * deltaSpeed, 0, m_dirY * deltaSpeed));
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((m_boxLayer.value & (1 << other.gameObject.layer)) > 0)
        {

            LootBox myBox = other.GetComponent<LootBox>();
            if (myBox && myBox.OpenBox(out Keytype key)){
                if (!m_Keylist.Contains(key))
                {
                    m_Keylist.Add(key);
                }
            }
        }
        else if ((m_doorLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            Door myDoor = other.GetComponent<Door>();
            if (myDoor)
            {
                myDoor.OpenDoor(m_Keylist);
            }
        }
    }
}
