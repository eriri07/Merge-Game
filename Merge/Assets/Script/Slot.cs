using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // IDropHandler ����� ����
public class Slot : MonoBehaviour, IDropHandler // ����̺�Ʈ ������ ���� ���
{
    GameObject Icon()
    {
        // ���Կ� ������(�ڽ� Ʈ������)�� ������ �������� gameobject�� ����
        // ���Կ� ������(�ڽ� Ʈ������)�� ���ٸ� null�� ����
        if (transform.childCount > 0)
            return transform.GetChild(0).gameObject;
        else
            return null;
    }

    // IDropHandler �������̽� ��ӽ� �����ؾ� �Ǵ� �ݹ� �Լ�
    // �� ��ũ��Ʈ�� ������Ʈ�� �߰� �� ���� ������Ʈ RactTransform����
    // ������ ����� �߻��ϸ� ����Ǵ� �ݹ��Լ�
    public void OnDrop(PointerEventData eventData)
    {
        // ������ ����ִٸ� Icon�� �ڽ����� �߰� ��ġ���� ��.
        if (Icon() == null)
        {
            IconDrag.beingDraggedIcon.transform.SetParent(transform);
            IconDrag.beingDraggedIcon.transform.position = transform.position;
        }
    }
}
