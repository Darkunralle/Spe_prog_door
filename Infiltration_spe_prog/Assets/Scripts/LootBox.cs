using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour, I_Box
{
    [SerializeField, Tooltip("La clé")]
    Keytype m_key;

    [SerializeField, Tooltip("Particule de la box")]
    ParticleSystem m_particle;

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
        return keyFound;

    }
}
