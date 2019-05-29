using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Boo.Lang.Environments;
using UnityEditor;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
	public static ObjectPool<T> _instance;
	public List<GameObject> _objectList;
	private GameObject _objectInstance;
	private PrimitiveType _type;
	public int _objectLimit;

	public ObjectPool(int objectAmount, PrimitiveType type)
	{
		_type = type;
		if (_objectList == null) _objectList = new List<GameObject>();
		for (int i = 0; i < objectAmount; i++)
		{
			_objectInstance = GameObject.CreatePrimitive(_type);
			_objectInstance.SetActive(false);
			_objectInstance.name = typeof(T).Name;
			_objectInstance.tag = typeof(T).Name;
			_objectInstance.AddComponent<T>();
			_objectList.Add(_objectInstance);
		}
	}

	public GameObject GetObject()
	{
		for (int i = 0; i < _objectList.Count; i++)
		{
			if (!_objectList[i].activeInHierarchy)
			{
				_objectList[i].SetActive(true);
				Debug.Log(_objectList[i].GetInstanceID());
				return _objectList[i];
			}
			else 
			{
				continue;
			}
			
		}

		if (_objectList.Count < _objectLimit)
		{
			GameObject _newObjectInstance = GameObject.CreatePrimitive(_type);
			_newObjectInstance.name = typeof(T).Name;
			_newObjectInstance.tag = typeof(T).Name;
			_newObjectInstance.AddComponent<T>();
			_objectList.Add(_newObjectInstance);
			return _newObjectInstance;
		}

		return null;
		
	}
}
