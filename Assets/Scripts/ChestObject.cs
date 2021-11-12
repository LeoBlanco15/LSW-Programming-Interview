using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " chest", menuName = "Chest")]
public class ChestObject : ScriptableObject
{
    public Sprite torso;
    public Sprite pelvis;
    public Sprite shoulderL;
    public Sprite shoulderR;
    public Sprite elbowL;
    public Sprite elbowR;
    public Sprite wristL;
    public Sprite wristR;

    public ChestObject(Chest chest)
    {
        torso = chest.torso.sprite;
        pelvis = chest.pelvis.sprite;
        shoulderL = chest.shoulderL.sprite;
        shoulderR = chest.shoulderR.sprite;
        elbowL = chest.elbowL.sprite;
        elbowR = chest.elbowR.sprite;
        wristL = chest.wristL.sprite;
        wristR = chest.wristR.sprite;
    }
}
