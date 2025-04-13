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
        // �������� �����
        List<Transform> children = new List<Transform>();
        for (int i = 0; i < spawnParent.childCount; i++)
        {
            children.Add(spawnParent.GetChild(i));
        }

        // ������������
        ShuffleList(children);
        for (int i = 0; i < children.Count; i++)
        {
            children[i].SetSiblingIndex(i);
        }

        // ��������� 1 ����
        yield return new WaitForEndOfFrame();

        // ��������� ����
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
