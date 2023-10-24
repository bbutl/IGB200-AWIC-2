using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Reaction : MonoBehaviour
{
    public Material currentMaterial;
    public ParticleSystem particles;
    ParticleSystemRenderer particlesRenderer;
    public DialogueManager manager;
    private 
    
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
        var emission = particles.emission;
        if (manager.currentSection.GetSpeechContents().Contains("Laugh.."))
        {
            emission.enabled = true;
            currentMaterial = Resources.Load<Material>("LaughP");
            particlesRenderer.material = currentMaterial;
        }
        else if (manager.currentSection.GetSpeechContents().Contains("Sad.."))
        {
            emission.enabled = true;
            currentMaterial = Resources.Load<Material>("SadP");
            particlesRenderer.material = currentMaterial;
        }
        else if (manager.currentSection.GetSpeechContents().Contains("Smile.."))
        {
            emission.enabled = true;
            currentMaterial = Resources.Load<Material>("SmileP");
            particlesRenderer.material = currentMaterial;
        }
        else
        {
            emission.enabled = false;
            currentMaterial = null;
        }
    }
}
