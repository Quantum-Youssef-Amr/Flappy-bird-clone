using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageAnimation : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float TimeBetweenTransition = 1;

    void Start()
    {
        StartCoroutine(Animation());
    }

    private IEnumerator Animation()
    {
        int m_spriteIndex = 0;
        while (true)
        {
            yield return new WaitForSeconds(TimeBetweenTransition);
            image.sprite = sprites[m_spriteIndex];
            m_spriteIndex = ++m_spriteIndex % sprites.Length;
        }
    }
}
