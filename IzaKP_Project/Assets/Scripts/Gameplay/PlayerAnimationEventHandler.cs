using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventHandler : MonoBehaviour
{
    public void PlayerHitSFX()
    {
        AudioManager.instance.PlaySoundEffect(AudioManager.SoundFXTypes.PlayerHit);
    }
}
