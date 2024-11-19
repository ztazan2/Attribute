using System;
using UnityEngine;

namespace CustomAttributes
{
    public class AttributeController
    {
        public void ApplySizeAttribute(Component target)
        {
            if (target == null)
            {
                Debug.LogError("Target component is null.");
                return;
            }

            // Get all fields in the target component
            var fields = target.GetType().GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                // Check if the field has the SizeAttribute
                var sizeAttribute = Attribute.GetCustomAttribute(field, typeof(SizeAttribute)) as SizeAttribute;
                if (sizeAttribute != null)
                {
                    // Check if the field is a Transform or RectTransform
                    object fieldValue = field.GetValue(target);
                    if (fieldValue is Transform transform)
                    {
                        ApplyTransformSize(transform, sizeAttribute.Size, field.Name);
                    }
                    else if (fieldValue is RectTransform rectTransform)
                    {
                        ApplyRectTransformSize(rectTransform, sizeAttribute.Size, field.Name);
                    }
                    else
                    {
                        Debug.LogWarning($"Field '{field.Name}' has SizeAttribute but is not Transform or RectTransform.");
                    }
                }
            }
        }

        private void ApplyTransformSize(Transform transform, Vector3 size, string fieldName)
        {
            if (transform.localScale != size) // Check if size is already applied
            {
                transform.localScale = size;
                Debug.Log($"Field '{fieldName}': Transform size applied: {size}");
            }
        }

        private void ApplyRectTransformSize(RectTransform rectTransform, Vector3 size, string fieldName)
        {
            Vector2 newSize = new Vector2(size.x, size.y);
            if (rectTransform.sizeDelta != newSize) // Check if sizeDelta is already applied
            {
                rectTransform.sizeDelta = newSize;
                Debug.Log($"Field '{fieldName}': RectTransform size applied: {newSize}");
            }
        }
    }
}
