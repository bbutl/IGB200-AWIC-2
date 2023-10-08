using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Reaction : MonoBehaviour
{
    public Material currentMaterial;
    public ParticleSystem particles;
    ParticleSystemRenderer particlesRenderer;
    public DialogueManager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        particlesRenderer = particles.GetComponent<ParticleSystemRenderer>();
        currentMaterial = GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.currentSection.GetSpeechContents().Contains("Laugh.."))
        {
            particlesRenderer.enabled = true;
            currentMaterial = Resources.Load<Material>("LaughP");
            particlesRenderer.material = currentMaterial;
        }
        else if (manager.currentSection.GetSpeechContents().Contains("Sad.."))
        {
            particlesRenderer.enabled = true;
            currentMaterial = Resources.Load<Material>("SadP");
            particlesRenderer.material = currentMaterial;
        }

        else
        {
            particlesRenderer.enabled = false;
            currentMaterial = null;
        }
    }
}
