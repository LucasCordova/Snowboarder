using UnityEngine;

[CreateAssetMenu(fileName = "PowerupScriptable", menuName = "Scriptable Objects/PowerupScriptable")]
public class PowerupScriptable : ScriptableObject
{

    public enum PowerupType
    {
        Speed,
        Torque
    }

    [SerializeField] private PowerupType powerType;
    [SerializeField] private float time;
    [SerializeField] private int amount;

    public PowerupType Type => powerType;
    public float Time => time;
    public int Amount => amount;
}