using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class EnemyGenerator : MonoBehaviour
{
    
    // Body Parts
    public GameObject head;
    public GameObject body;
    public GameObject leftArm;
    public GameObject rightArm;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public GameObject tail;

    // Special Traits
    public GameObject DragonArm;
    public GameObject FeatherArm;
    public GameObject PixieArm;
    public GameObject DragonLeg;
    public GameObject FeatherLeg;
    public GameObject PixieLeg;
    // public GameObject StrongArm;
    // public GameObject FastLeg;
    public GameObject DragonWings;
    public GameObject WingsFeathers;
    public GameObject PixieWings;
    // public GameObject SturdyTorso;
    public GameObject DragonTorso;
    public GameObject FeatherTorso;
    public GameObject PixieTorso;


    // Materials
    public Material TonedMaterial;
    public Material DragonMaterial;
    public Material PixieMaterial;

    public string role = "None";
    public string chosenTrait = "None";
    public Color enemyColor = Color.red;
    public string colorMood = "None";

    void Start()
    {
        ApplyRoleScale(role);
        ApplyTrait(chosenTrait);
        ApplyColor(enemyColor);
    }

    public void SetRole(int index) { 
        if (index == 0) role = "Minion"; 
        if (index == 1) role = "Leader"; 
        if (index == 2) role = "Boss"; 
    }

    public void SetTrait(int index) { 
        if (index == 0) chosenTrait = "None"; 
        if (index == 1) chosenTrait = "StrongArm"; 
        if (index == 2) chosenTrait = "FastLeg"; 
        if (index == 3) chosenTrait = "Wings"; 
        if (index == 4) chosenTrait = "SturdyTorso"; 
    }

    public void SetColor(int index) {
        if (index == 0) colorMood = "Angry"; 
        if (index == 1) colorMood = "Sad"; 
        if (index == 2) colorMood = "Calm"; 
        if (index == 3) colorMood = "Happy";
    }

    Color PickRandomColor(Color a, Color b, Color c) { 
        float index = Random.Range(0f, 1f) * 3f; 

        if (index < 1f) {
        return a; 
        } else if (index < 2f) {
            return b; 
        } else {
            return c;
        } 
    }


    string RandomPart(string one, string two, string three, float weightOne, float weightTwo, float weightThree) { 
        float roll = Random.Range(0f, 1f) * 100f; 
        if (roll <= weightOne) 
            return one; 
        else if (weightOne < roll && roll <= weightOne + weightTwo) 
            return two; 
        else 
            return three; 
    }   

    void ApplyRoleScale(string role)
    {
        float scale;
        switch (role)
        {
            case "Minion":
                scale = Random.Range(40.0f, 60.0f);
                break;
            case "Leader":
                scale = Random.Range(80.0f, 120.0f);
                break;
            case "Boss":
                scale = Random.Range(140.0f, 160.0f);
                break;
            default:
                scale = Random.Range(40.0f, 60.0f);
                break;
        }
        SetScale(scale);
    }

    void SetScale(float scale) { 
        transform.localScale = new Vector3(scale, scale, scale); 
    }

    void ApplyTrait(string trait)
    {
        // Disable all traits first
        DragonArm.SetActive(false);
        FeatherArm.SetActive(false);
        PixieArm.SetActive(false);
        DragonLeg.SetActive(false);
        FeatherLeg.SetActive(false);
        PixieLeg.SetActive(false);
        // StrongArm.SetActive(false);
        // FastLeg.SetActive(false);
        // SturdyTorso.SetActive(false);
        DragonWings.SetActive(false);
        WingsFeathers.SetActive(false);
        PixieWings.SetActive(false);
        // SturdyTorso.SetActive(false);
        DragonTorso.SetActive(false);
        FeatherTorso.SetActive(false);
        PixieTorso.SetActive(false);
        head.SetActive(true);
        body.SetActive(true);
        leftArm.SetActive(true);
        rightArm.SetActive(true);
        leftLeg.SetActive(true);
        rightLeg.SetActive(true);
        tail.SetActive(true);


        // Enable the chosen trait
        switch (trait)
        {
            case "StrongArm":
                leftArm.SetActive(false);
                rightArm.SetActive(false);
                if (role == "Minion") {
                    string armType = RandomPart("DragonArm", "FeatherArm", "PixieArm", 20f, 20f, 60f);
                    switch (armType)
                    {
                        case "DragonArm":
                            DragonArm.SetActive(true);
                            break;
                        case "FeatherArm":
                            FeatherArm.SetActive(true);
                            break;
                        case "PixieArm":
                            PixieArm.SetActive(true);

                            break;
                    }
                } else if (role == "Leader") {
                    string armType = RandomPart("DragonArm", "FeatherArm", "PixieArm", 20f, 60f, 20f);
                    switch (armType)
                    {
                        case "DragonArm":
                            DragonArm.SetActive(true);
                            break;
                        case "FeatherArm":
                            FeatherArm.SetActive(true);
                            break;
                        case "PixieArm":
                            PixieArm.SetActive(true);
                            break;
                    }
                } else { // Boss
                    string armType = RandomPart("DragonArm", "FeatherArm", "PixieArm", 60f, 20f, 20f);
                    switch (armType)
                    {
                        case "DragonArm":
                            DragonArm.SetActive(true);
                            break;
                        case "FeatherArm":
                            FeatherArm.SetActive(true);
                            break;
                        case "PixieArm":
                            PixieArm.SetActive(true);
                            break;
                    }
                }
                break;
            case "FastLeg":
            leftLeg.SetActive(false);
            rightLeg.SetActive(false);
                if (role == "Minion") {
                    string legType = RandomPart("DragonLeg", "FeatherLeg", "PixieLeg", 20f, 20f, 60f);
                    switch (legType)
                    {
                        case "DragonLeg":
                            DragonLeg.SetActive(true);
                            break;
                        case "FeatherLeg":
                            FeatherLeg.SetActive(true);
                            break;
                        case "PixieLeg":
                            PixieLeg.SetActive(true);
                            break;
                    }
                } else if (role == "Leader") {
                    string legType = RandomPart("DragonLeg", "FeatherLeg", "PixieLeg", 20f, 60f, 20f);
                    switch (legType)
                    {
                        case "DragonLeg":
                            DragonLeg.SetActive(true);
                            break;
                        case "FeatherLeg":
                            FeatherLeg.SetActive(true);
                            break;
                        case "PixieLeg":
                            PixieLeg.SetActive(true);
                            break;
                    }
                } else { // Boss
                    string legType = RandomPart("DragonLeg", "FeatherLeg", "PixieLeg", 60f, 20f, 20f);
                    switch (legType)
                    {
                        case "DragonLeg":
                            DragonLeg.SetActive(true);
                            break;
                        case "FeatherLeg":
                            FeatherLeg.SetActive(true);
                            break;
                        case "PixieLeg":
                            PixieLeg.SetActive(true);
                            break;
                    }
                }
                break;
            case "Wings":
                if (role == "Minion") {
                    string wingType = RandomPart("DragonWings", "WingsFeathers", "PixieWings", 20f, 20f, 60f);
                    switch (wingType)
                    {
                        case "DragonWings":
                            DragonWings.SetActive(true);
                            break;
                        case "WingsFeathers":
                            WingsFeathers.SetActive(true);
                            break;
                        case "PixieWings":
                            PixieWings.SetActive(true);
                            break;
                    }
                } else if (role == "Leader") {
                    string wingType = RandomPart("DragonWings", "WingsFeathers", "PixieWings", 20f, 60f, 20f);
                    switch (wingType)
                    {
                        case "DragonWings":
                            DragonWings.SetActive(true);
                            break;
                        case "WingsFeathers":
                            WingsFeathers.SetActive(true);
                            break;
                        case "PixieWings":
                            PixieWings.SetActive(true);
                            break;
                    }
                } else { // Boss
                    string wingType = RandomPart("DragonWings", "WingsFeathers", "PixieWings", 60f, 20f, 20f);
                    switch (wingType)
                    {
                        case "DragonWings":
                            DragonWings.SetActive(true);
                            break;
                        case "WingsFeathers":
                            WingsFeathers.SetActive(true);
                            break;
                        case "PixieWings":
                            PixieWings.SetActive(true);
                            break;
                    }
                }
                break;
            case "SturdyTorso":
            body.SetActive(false);
                if (role == "Minion") {
                    string torsoType = RandomPart("DragonTorso", "FeatherTorso", "PixieTorso", 20f, 20f, 60f);
                    switch (torsoType)
                    {
                        case "DragonTorso":
                            DragonTorso.SetActive(true);
                            break;
                        case "FeatherTorso":
                            FeatherTorso.SetActive(true);
                            break;
                        case "PixieTorso":
                            PixieTorso.SetActive(true);
                            break;
                    }
                } else if (role == "Leader") {
                    string torsoType = RandomPart("DragonTorso", "FeatherTorso", "PixieTorso", 20f, 60f, 20f);
                    switch (torsoType)
                    {
                        case "DragonTorso":
                            DragonTorso.SetActive(true);
                            break;
                        case "FeatherTorso":
                            FeatherTorso.SetActive(true);
                            break;
                        case "PixieTorso":
                            PixieTorso.SetActive(true);
                            break;
                    }
                } else { // Boss
                    string torsoType = RandomPart("DragonTorso", "FeatherTorso", "PixieTorso", 60f, 20f, 20f);
                    switch (torsoType)
                    {
                        case "DragonTorso":
                            DragonTorso.SetActive(true);
                            break;
                        case "FeatherTorso":
                            FeatherTorso.SetActive(true);
                            break;
                        case "PixieTorso":
                            PixieTorso.SetActive(true);
                            break;
                    }
                }
                break;
            default:
                break;
        }
            
    }

   

    // Apply color to all parts
    void ApplyColor(Color color) { 
        Renderer[] renderers = GetComponentsInChildren<Renderer>(); 
        foreach (Renderer renderer in renderers) { 
            if(renderer.sharedMaterial == TonedMaterial) { 
                renderer.sharedMaterial.color = color; 
            } 
        } 
    }

    Color ApplytheColor(string mood) { 
        switch (mood)
        {
            case "Angry":
                return PickRandomColor(Color.red, new Color(1f, 0.3f, 0f), new Color(0.4f, 0f, 0f));
            case "Sad":
                return PickRandomColor(Color.blue, Color.cyan, new Color(0f, 0.5f, 0.5f));
            case "Calm":
                return PickRandomColor(Color.green, new Color(0.5f, 1f, 0f), new Color(0f, 0.8f, 0.3f));
            case "Happy":
                return PickRandomColor(new Color(1f, 0.4f, 0.7f), Color.magenta, new Color(0.6f, 0f, 0.8f));
            default:
                return Color.white;
        }
    }

    public void RandomizeEnemy() { 
        SetRole(Random.Range(0, 3)); 
        SetTrait(Random.Range(0, 5)); 
        SetColor(Random.Range(0, 5)); 
        GenerateEnemy(); 
    }


    public void GenerateEnemy() { 
        ApplyRoleScale(role); 
        ApplyTrait(chosenTrait); 
        enemyColor = ApplytheColor(colorMood);
        ApplyColor(enemyColor); 
        Debug.Log("Eenemy Generated: " + role + " with trait " + chosenTrait);
    }

    #if UNITY_EDITOR
    public void SaveEnemy()
    {
        string localPath = "Assets/Prefabs/" + gameObject.name + ".prefab";
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        PrefabUtility.SaveAsPrefabAssetAndConnect(gameObject, localPath, InteractionMode.UserAction);
    }
    #endif
}
