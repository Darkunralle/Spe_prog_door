using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, I_Door
{
    [SerializeField, Tooltip("Type de cl�")] Keytype m_neededKey;
    [SerializeField, Tooltip("La porte elle m�me")] Rigidbody m_door;
    public void OpenDoor(List<Keytype> p_playerKeys)
    {
        if (m_neededKey)
        {
            if (p_playerKeys == null || !p_playerKeys.Contains(m_neededKey))
            {
                Debug.Log(message: $"La cle {m_neededKey.name} est n�cessaire");
                return ;
            }
            // Check si le joueur est en possession de la cl�
            // si il ne la on return
        }
        Debug.Log(message:"Ouverture");
        m_door.MovePosition(new Vector3(m_door.position.x, -2, m_door.position.z));
        

        // On ouvre
    }
}
