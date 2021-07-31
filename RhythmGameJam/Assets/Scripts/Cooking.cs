using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    private Animator animator;
    private int cutscene;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/" + SongManager.instance.songName + " Animator");
    }

    // Update is called once per frame
    void Update()
    {
        float section = SongManager.instance.musicSource.clip.length / animator.runtimeAnimatorController.animationClips.Length;
        if (SongManager.instance.songPositionInSec > section * (cutscene + 1))
        {
            animator.SetInteger("cutscene", cutscene + 1);
            cutscene++;
        }
    }
}
