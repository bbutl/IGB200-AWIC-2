using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRandomisation : MonoBehaviour
{
    //Physical body parts
    [SerializeField] GameObject[] physcialHead;
    [SerializeField] GameObject[] physicalHands;
    [SerializeField] GameObject[] physicalHair;
    [SerializeField] GameObject[] physicalEyes;
    [SerializeField] GameObject[] physicalClothesOuter;
    [SerializeField] GameObject[] physicalClothesInner;

    //Body part colours
    [SerializeField] Material[] colourSkin;
    [SerializeField] Material[] colourHair;
    [SerializeField] Material[] colourEyes;
    [SerializeField] Material[] colourClothesOuter;
    [SerializeField] Material[] colourClothesInner;

    //Body part meshes
    private SkinnedMeshRenderer[] meshHead;
    private SkinnedMeshRenderer[] meshHands;
    private SkinnedMeshRenderer[] meshHair;
    private SkinnedMeshRenderer[] meshEyes;
    private SkinnedMeshRenderer[] meshClothesOuter;
    private SkinnedMeshRenderer[] meshClothesInner;

    //Random body parts
    private int randomPhyscialHead;
    private int randomPhyscialHands;
    private int randomPhyscialHair;
    private int randomPhyscialEyes;
    private int randomPhyscialClothesOuter;
    private int randomPhyscialClothesInner;

    //Random body colours
    private int randomColourSkin;
    private int randomColourHair;
    private int randomColourEyes;
    private int randomColourClothesOuter;
    private int randomColourClothesInner;

    void Start()
    {
        GetMeshes();
        RandomiseCharacter();
    }

    void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            RandomiseCharacter();
        }
    }

    private void RandomiseCharacter()
    {
        //Randomise physical attributes
        randomPhyscialHead = Random.Range(0, physcialHead.Length);
        randomPhyscialHands = Random.Range(0, physicalHands.Length);
        randomPhyscialHair = Random.Range(0, physicalHair.Length);
        randomPhyscialEyes = Random.Range(0, physicalEyes.Length);
        randomPhyscialClothesOuter = Random.Range(0, physicalClothesOuter.Length);
        randomPhyscialClothesInner = Random.Range(0, physicalClothesInner.Length);

        //Randomise colours
        randomColourSkin = Random.Range(0, colourSkin.Length);
        randomColourHair = Random.Range(0, colourHair.Length);
        randomColourEyes = Random.Range(0, colourEyes.Length);
        randomColourClothesOuter = Random.Range(0, colourClothesOuter.Length);
        randomColourClothesInner = Random.Range(0, colourClothesInner.Length);

        ResetBodyParts();

        //Set the random physical attributes to active
        physcialHead[randomPhyscialHead].SetActive(true);
        physicalHands[randomPhyscialHands].SetActive(true);
        physicalHair[randomPhyscialHair].SetActive(true);
        physicalEyes[randomPhyscialEyes].SetActive(true);
        physicalClothesOuter[randomPhyscialClothesOuter].SetActive(true);
        physicalClothesInner[randomPhyscialClothesInner].SetActive(true);
        
        //Set the random colour for each part
        meshHead[randomPhyscialHead].material = colourSkin[randomColourSkin];
        meshHands[randomPhyscialHands].material = colourSkin[randomColourSkin];
        meshHair[randomPhyscialHair].material = colourHair[randomColourHair];
        meshEyes[randomPhyscialEyes].material = colourEyes[randomColourEyes];
        meshClothesOuter[randomPhyscialClothesOuter].material = colourClothesOuter[randomColourClothesOuter];
        meshClothesInner[randomPhyscialClothesInner].material = colourClothesInner[randomColourClothesInner];
    }

    private void ResetBodyParts()
    {
        for (int i = 0; i < physcialHead.Length; i++)
        {
            physcialHead[i].SetActive(false);
        }
        for (int i = 0; i < physicalHands.Length; i++)
        {
            physicalHands[i].SetActive(false);
        }
        for (int i = 0; i < physicalHair.Length; i++)
        {
            physicalHair[i].SetActive(false);
        }
        for (int i = 0; i < physicalEyes.Length; i++)
        {
            physicalEyes[i].SetActive(false);
        }
        for (int i = 0; i < physicalClothesOuter.Length; i++)
        {
            physicalClothesOuter[i].SetActive(false);
        }
        for (int i = 0; i < physicalClothesInner.Length; i++)
        {
            physicalClothesInner[i].SetActive(false);
        }
    }

    private void GetMeshes()
    {
        meshHead = new SkinnedMeshRenderer[physcialHead.Length];
        meshHands = new SkinnedMeshRenderer[physicalHands.Length];
        meshHair = new SkinnedMeshRenderer[physicalHair.Length];
        meshEyes = new SkinnedMeshRenderer[physicalEyes.Length];
        meshClothesOuter = new SkinnedMeshRenderer[physicalClothesOuter.Length];
        meshClothesInner = new SkinnedMeshRenderer[physicalClothesInner.Length];

        for (int i = 0; i < physcialHead.Length; i++)
        {
            meshHead[i] = physcialHead[i].GetComponent<SkinnedMeshRenderer>();
        }
        for (int i = 0; i < physicalHands.Length; i++)
        {
            meshHands[i] = physicalHands[i].GetComponent<SkinnedMeshRenderer>();
        }
        for (int i = 0; i < physicalHair.Length; i++)
        {
            meshHair[i] = physicalHair[i].GetComponent<SkinnedMeshRenderer>();
        }
        for (int i = 0; i < physicalEyes.Length; i++)
        {
            meshEyes[i] = physicalEyes[i].GetComponent<SkinnedMeshRenderer>();
        }
        for (int i = 0; i < physicalClothesOuter.Length; i++)
        {
            meshClothesOuter[i] = physicalClothesOuter[i].GetComponent<SkinnedMeshRenderer>();
        }
        for (int i = 0; i < physicalClothesInner.Length; i++)
        {
            meshClothesInner[i] = physicalClothesInner[i].GetComponent<SkinnedMeshRenderer>();
        }
    }
}
