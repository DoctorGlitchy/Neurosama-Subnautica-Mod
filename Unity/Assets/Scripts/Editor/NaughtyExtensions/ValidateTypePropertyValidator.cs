﻿using NaughtyAttributes.Editor;
using SCHIZO.Unity.NaughtyExtensions;
using UnityEditor;

namespace Editor.NaughtyExtensions
{
    public class ValidateTypePropertyValidator : PropertyValidatorBase
    {
        public override void ValidateProperty(SerializedProperty property)
        {
            ValidateTypeAttribute attr = PropertyUtility.GetAttribute<ValidateTypeAttribute>(property);

            if (property.propertyType != SerializedPropertyType.ObjectReference)
            {
                string warning = attr.GetType().Name + " works only on reference types";
                NaughtyEditorGUI.HelpBox_Layout(warning, MessageType.Warning, context: property.serializedObject.targetObject);
                return;
            }

            if (property.objectReferenceValue == null) return;
            if (attr.typeName == property.objectReferenceValue.GetType().Name) return;

            NaughtyEditorGUI.HelpBox_Layout($"{property.displayName} must be of type {attr.typeName}", MessageType.Error, context: property.serializedObject.targetObject);
        }
    }
}
