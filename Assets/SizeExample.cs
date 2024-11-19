using UnityEngine;
using CustomAttributes; // AttributeController Ŭ������ �ִ� ���ӽ����̽� �߰�

public class SizeExample : MonoBehaviour
{
    [Size(4, 4, 4)] // For Transform
    public Transform myTransform;

    [Size(3, 3)] // For RectTransform
    public RectTransform myRectTransform;

    private void Start()
    {
        AttributeController attributeController = new AttributeController();
        attributeController.ApplySizeAttribute(this);
    }
}
