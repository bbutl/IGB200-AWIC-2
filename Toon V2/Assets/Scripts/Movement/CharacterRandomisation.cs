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

    //Body part meshes
    private MeshRenderer[] meshHeadMR;
    private MeshRenderer[] meshHandsMR;
    private MeshRenderer[] meshHairMR;
    private MeshRenderer[] meshEyesMR;
    private MeshRenderer[] meshClothesOuterMR;
    private MeshRenderer[] meshClothesInnerMR;

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
            //RandomiseCharacter();
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
        if (meshHead[randomPhyscialHead] != null)
            meshHead[randomPhyscialHead].material = colourSkin[randomColourSkin];
        else
            meshHeadMR[randomPhyscialHead].material = colourSkin[randomColourSkin];
        if (meshHands[randomPhyscialHands] != null)
            meshHands[randomPhyscialHands].material = colourSkin[randomColourSkin];
        else
            meshHandsMR[randomPhyscialHands].material = colourSkin[randomColourSkin];
        if (meshHair[randomPhyscialHair] != null)
            meshHair[randomPhyscialHair].material = colourHair[randomColourHair];
        else
            meshHairMR[randomPhyscialHair].material = colourHair[randomColourHair];
        if (meshEyes[randomPhyscialEyes] != null)
            meshEyes[randomPhyscialEyes].material = colourEyes[randomColourEyes];
        else
            meshEyesMR[randomPhyscialEyes].material = colourEyes[randomColourEyes];
        if (meshClothesOuter[randomPhyscialClothesOuter] != null)
            meshClothesOuter[randomPhyscialClothesOuter].material = colourClothesOuter[randomColourClothesOuter];
        else
            meshClothesOuterMR[randomPhyscialClothesOuter].material = colourClothesOuter[randomColourClothesOuter];
        if (meshClothesInner[randomPhyscialClothesInner] != null)
            meshClothesInner[randomPhyscialClothesInner].material = colourClothesInner[randomColourClothesInner];
        else
            meshClothesInnerMR[randomPhyscialClothesInner].material = colourClothesInner[randomColourClothesInner];
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

        meshHeadMR = new MeshRenderer[physcialHead.Length];
        meshHandsMR = new MeshRenderer[physicalHands.Length];
        meshHairMR = new MeshRenderer[physicalHair.Length];
        meshEyesMR = new MeshRenderer[physicalEyes.Length];
        meshClothesOuterMR = new MeshRenderer[physicalClothesOuter.Length];
        meshClothesInnerMR = new MeshRenderer[physicalClothesInner.Length];

        for (int i = 0; i < physcialHead.Length; i++)
        {
            if (physcialHead[i].GetComponent<SkinnedMeshRenderer>() != null)
                meshHead[i] = physcialHead[i].GetComponent<SkinnedMeshRenderer>();
            else
                meshHeadMR[i] = physcialHead[i].GetComponent<MeshRenderer>();

        }
        for (int i = 0; i < physicalHands.Length; i++)
        {
            if (physicalHands[i].GetComponent<SkinnedMeshRenderer>() != null)
                meshHands[i] = physicalHands[i].GetComponent<SkinnedMeshRenderer>();
            else
                meshHandsMR[i] = physicalHands[i].GetComponent<MeshRenderer>();
        }
        for (int i = 0; i < physicalHair.Length; i++)
        {
            if (physicalHair[i].GetComponent<SkinnedMeshRenderer>() != null)
                meshHair[i] = physicalHair[i].GetComponent<SkinnedMeshRenderer>();
            else
                meshHairMR[i] = physicalHair[i].GetComponent<MeshRenderer>();
        }
        for (int i = 0; i < physicalEyes.Length; i++)
        {
            if (physicalEyes[i].GetComponent<SkinnedMeshRenderer>() != null)
                meshEyes[i] = physicalEyes[i].GetComponent<SkinnedMeshRenderer>();
            else
                meshEyesMR[i] = physicalEyes[i].GetComponent<MeshRenderer>();
        }
        for (int i = 0; i < physicalClothesOuter.Length; i++)
        {
            if (physicalClothesOuter[i].GetComponent<SkinnedMeshRenderer>() != null)
                meshClothesOuter[i] = physicalClothesOuter[i].GetComponent<SkinnedMeshRenderer>();
            else
                meshClothesOuterMR[i] = physicalClothesOuter[i].GetComponent<MeshRenderer>();
        }
        for (int i = 0; i < physicalClothesInner.Length; i++)
        {
            if (physicalClothesInner[i].GetComponent<SkinnedMeshRenderer>() != null)
                meshClothesInner[i] = physicalClothesInner[i].GetComponent<SkinnedMeshRenderer>();
            else
                meshClothesInnerMR[i] = physicalClothesInner[i].GetComponent<MeshRenderer>();
        }
    }
}
