using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // IDropHandler ����� ����
public class Slot : MonoBehaviour, IDropHandler
{
    //���� �������� Icon�Լ��� ��ü �ϴ� ������Ƽ
    public GameObject item
    {
        // item�� �����Ϸ��� �Ҷ�(���� ��) ����
        get
        {
            // transform (rect transform)�� �ڽ� ���翩�� Ȯ��
            if (transform.childCount > 0)
            {
                // ���Կ� �������� ������ �������� gameobject�� ����
                return transform.GetChild(0).gameObject;
            }
            // ���Կ� �������� ���ٸ� null�� ����
            return null;
        }
    }

    // ��ũ��Ʈ�� ������ RectTransform�� �����Ͱ� �������� �ش� �̺�Ʈ�� �߻� 
    public void OnDrop(PointerEventData eventData)
    {
        // ������ ����ִٸ� ����
        if (!item)
        {
            // ���� �����ÿ� �����ϴ� ��ġ���� �ڵ�� ���԰��ӿ�����Ʈ��
            // grid layout group�� �߰��Ͽ� �ڵ� ��ġ �����ǵ��� ���� 
            DragManager.beingDraggedItem.transform.SetParent(transform);
        }
        else // ������ ������� �ʴٸ� ����
        {
            //������ �� ��ġ���� �Ǵ� ������ ���� �� ������ ����
            Item dragItem = DragManager.beingDraggedItem.GetComponent<Item>();
            Item soltItem = item.GetComponent<Item>();

            // �� �������� ���ڰ� ������ ��� ����
            if (dragItem.number == soltItem.number)
            {
                //���� ��� �� ���� �� �� ������ ��� Destory
                int backupNum = dragItem.number;
                Destroy(dragItem.gameObject); Destroy(soltItem.gameObject);

                //�κ�Ʈ�� �Ŵ����� ���� ���� �������� ����
                InventoryManager.inst.CreateUpgradeItem(backupNum + 1, transform);
            }
            else // �� �������� ���ڰ� �ٸ���� ��ġ����
            {
                DragManager.beingDraggedItem.transform.SetParent(transform);
                item.transform.SetParent(DragManager.beingDraggedItem.GetComponent<DragManager>().startParent);
            }
        }
    }
}
