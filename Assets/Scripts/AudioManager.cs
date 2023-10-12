using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// namespace DefaultNamespace
// {
//     public class AudioManager : MonoBehaviour
//     {
//         // backing field for actually store the Singleton instance
//         private static AudioManager _instance;
//         private void Awake()
//         {
//             if (_instance == null)
//             {
//                 _instance = this;
//                 DontDestroyOnLoad(this.gameObject);
//             }
//
//             InitializeInstance(this);
//         }
//     }
// }
// [CreateAssetMenu]
// public class AudioData : ScriptableObject
// {
//     public List<AudioClip> sounds = new List<AudioClip>();
// }