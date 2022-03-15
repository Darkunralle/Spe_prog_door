using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, I_Door
{
    [SerializeField, Tooltip("Type de clé")] Keytype m_neededKey;

    [SerializeField, Tooltip("Animator de la porte")] 
    Animator m_animatorDoor;
    [SerializeField, Tooltip("")]
    string m_openTriggerName = "Open";

    int m_openHash;
    public void OpenDoor(List<Keytype> p_playerKeys)
    {
        if (m_neededKey)
        {
            if (p_playerKeys == null || !p_playerKeys.Contains(m_neededKey))
            {
                Debug.Log(message: $"La cle {m_neededKey.name} est nécessaire");
                return ;
            }
            // Check si le joueur est en possession de la clé
            // si il ne la on return
        }
        Debug.Log(message:"Ouverture");
        m_animatorDoor?.SetTrigger(m_openHash);
        

        // On ouvre
    }

    private void Awake()
    {

        if (m_animatorDoor == null)
        {
            m_animatorDoor = GetComponent<Animator>();
            if (m_animatorDoor == null)
            {
                Debug.Log("Tardos l'animator MERCI");
                throw new System.ArgumentNullException();
            }
        }
        m_openHash = Animator.StringToHash(m_openTriggerName);
    }
}
