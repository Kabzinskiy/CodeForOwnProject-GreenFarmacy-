using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOptions : MonoBehaviour
{
    [SerializeField] private Sprite particle;
    [SerializeField] private int spriteCount;
    private ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        var animation = particles.textureSheetAnimation;
        animation.mode = ParticleSystemAnimationMode.Sprites;
        animation.AddSprite(particle);
        var em = particles.emission;
        em.SetBursts(
            new ParticleSystem.Burst[]{
                new ParticleSystem.Burst(0f, spriteCount)
            });
    }
}
