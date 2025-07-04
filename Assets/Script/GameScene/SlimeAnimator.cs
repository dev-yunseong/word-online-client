using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimator : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites; 
    void Start()
    {
        StartCoroutine(Animate());
    }

    private IEnumerator Animate()
    {
        while (true)
        {
            foreach (var sprite in sprites)
            {
                GetComponent<SpriteRenderer>().sprite = sprite;
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
