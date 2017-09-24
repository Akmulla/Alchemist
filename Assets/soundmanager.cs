using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundSample {  explosion,drink,mix,die_enemy,hit_player,die_player};

public class soundmanager : MonoBehaviour
{
    public static soundmanager sound_manager;

    public AudioSource source;
    public AudioClip main_theme;

    public AudioClip explosion;
    public AudioClip drink;
    public AudioClip mix;
    public AudioClip die_enemy;
    public AudioClip hit_player;
    public AudioClip die_player;

    // Use this for initialization
    void Awake () {
        sound_manager = this;

    }

    public void SingleSound(SoundSample sound)
    {
        switch (sound)
        {
            case SoundSample.explosion:
                source.PlayOneShot(explosion, 1.0f);
                break;
            case SoundSample.drink:
                source.PlayOneShot(drink, 1.0f);
                break;
            case SoundSample.mix:
                source.PlayOneShot(mix, 1.0f);
                break;
            case SoundSample.die_enemy:
                source.PlayOneShot(die_enemy, 0.6f);
                break;
            case SoundSample.hit_player:
                source.PlayOneShot(hit_player, 1.0f);
                break;
            case SoundSample.die_player:
                source.PlayOneShot(die_player, 1.0f);
                break;
        }
    }
}
