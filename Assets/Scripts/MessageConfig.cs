using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MessageConfig", menuName = "ScriptableObjects/MessageConfig", order = 0)]
public class MessageConfig : ScriptableObject
{
    [Serializable]
    public class Authors
    {
        public string authorName;
        public string[] messages;
    }

    // Now you can use Alex as a part of MessageConfig
    public Authors[] authors;
}