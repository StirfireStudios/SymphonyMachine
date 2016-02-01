using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Jam.Utils
{
    /// Global functions to modify the current scene
    public class Scene
    {
        /// Fetch a game object factory from a resource url
        /// @param resource The resource path to the instance
        /// @return A factory instance, for a prefab.
        public static Option<GameObject> Prefab(String resource)
        {
            try
            {
                var rtn = Resources.Load(resource, typeof(GameObject)) as GameObject;
                if (rtn != null)
                {
                    return Option.Some(rtn);
                }
                else
                {
                    Debug.LogError("Failed to load prefab path: " + resource + ": not found");
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to load prefab path: " + resource + ": " + e);
            }
            return Option.None<GameObject>();
        }

        /// Add a new resource prefab instance to the current scene and return it
        /// @param factory The factory type.
        /// @return A new world instance of factory.
        public static Option<GameObject> Spawn(GameObject factory)
        {
            try
            {
                var instance = UnityEngine.Object.Instantiate(factory);
                return Option.Some(instance as GameObject);
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to load prefab: " + factory + ": " + e);
            }
            return Option.None<GameObject>();
        }

        /// Find and return all GameObject instances which have the given component
        public static List<GameObject> Find<T>() where T : Component
        {
            var rtn = new List<GameObject>();
            foreach (var instance in UnityEngine.Object.FindObjectsOfType(typeof(T)))
            {
                rtn.Add((instance as T).gameObject);
            }
            return rtn;
        }

        /// Find and return the first GameObject instance which has the given component
        public static GameObject First<T>() where T : Component
        {
            var rtn = UnityEngine.Object.FindObjectOfType(typeof(T));
            if (rtn != null)
            {
                return (rtn as Component).gameObject;
            }
            return null;
        }

        /// Find and return all instances of T in the scene.
        public static List<T> FindComponents<T>() where T : Component
        {
            var rtn = new List<T>();
            foreach (var instance in UnityEngine.Object.FindObjectsOfType(typeof(T)))
            {
                rtn.Add(instance as T);
            }
            return rtn;
        }

        /// Find and return the first matching component
        public static T FindComponent<T>() where T : Component
        {
            return UnityEngine.Object.FindObjectOfType(typeof(T)) as T;
        }

        /// Return first instance of T in the scene, use this sparingly and carefully.
        public static T Get<T>() where T : Component
        {
            return UnityEngine.Object.FindObjectOfType(typeof(T)) as T;
        }
    }
}
