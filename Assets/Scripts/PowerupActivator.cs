using UnityEngine;
using UnityEngine.Timeline;

public interface IPowerupActivator
{
    PowerupScriptable powerup { get; set; };

    void Activate();

}

public class SpeedPowerup : IPowerupActivator
{
    public PowerupScriptable powerup { get; set; }

    public void Activate()
    {

    }
}

public class TorquePowerup : IPowerupActivator
{
    public PowerupScriptable powerup { get; set; }

    public void Activate()
    {
        // Torque
    }
}



