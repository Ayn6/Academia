using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generation : MonoBehaviour
{
    public Transform spawnParent;

    public void ShuffleExistingPieces()
    {
        StartCoroutine(ShuffleAndDisableGrid());
    }

    private IEnumerator ShuffleAndDisableGrid()
    {
        // Получаем детей
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < spawnParent.childCount; i++)
        {
            children.Add(spawnParent.GetChild(i));
        }

        // Перемешиваем
        ShuffleList(children);
        for (int i = 0; i < children.Count; i++)
        {
            children[i].SetSiblingIndex(i);
        }

        // Подождать 1 кадр
        yield return new WaitForEndOfFrame();

        // Отключить грид
        GridLayoutGroup grid = spawnParent.GetComponent<GridLayoutGroup>();
        if (grid != null)
        {
            grid.enabled = false;
        }
    }

    private void ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(i, list.Count);
            (list[i], list[rnd]) = (list[rnd], list[i]);
        }
    }
}
