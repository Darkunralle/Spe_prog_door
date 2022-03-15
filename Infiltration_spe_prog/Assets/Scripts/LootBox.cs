using UnityEngine;

public class LootBox : MonoBehaviour, I_Box
{
    [SerializeField, Tooltip("La clé")]
    Keytype m_key;

    [SerializeField, Tooltip("Particule de la box")]
    ParticleSystem m_particle;

    [SerializeField, Tooltip("Animator de la LootBox")]
    Animator m_animatorBox;

    [SerializeField, Tooltip("")]
    string m_openTriggerName = "Open";

    int m_openHash;

    public bool OpenBox(out Keytype o_key)
    {
        bool keyFound = false;
        // Loot de la clé
        if (m_key == null)
        {
            Debug.Log("Le coffre est vide PAS DE CHANCE");
            o_key = null;
        }
        else
        {
            o_key = m_key;
            keyFound = true;
            Debug.Log($"Vous avez loot une clé {m_key.name}");


        }
        m_particle.Stop();
        m_animatorBox?.SetTrigger(m_openHash);
        return keyFound;

    }

    private void Awake()
    {

        if (m_animatorBox == null)
        {
            m_animatorBox = GetComponent<Animator>();
            if (m_animatorBox == null)
            {
                Debug.Log("Tardos l'animator MERCI");
                throw new System.ArgumentNullException();
            }
        }
        m_openHash = Animator.StringToHash(m_openTriggerName);
    }
}
