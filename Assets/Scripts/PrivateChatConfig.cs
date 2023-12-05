using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PrivateChatConfig", menuName = "ScriptableObjects/PrivateChatConfig", order = 1)]
public class PrivateChatConfig : ScriptableObject
{
    [Serializable]
    public class Authors
    {
        public string authorName;
        public string[] messages;
    }

    public Authors maria;
    public Authors you;
}