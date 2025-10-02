using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 팩토리 - 게임 객체
 */
public static partial class Factory
{
	#region 클래스 팩토리 함수
	/** 객체를 생성한다 */
	public static GameObject CreateGameObj(string a_oName,
		GameObject a_oGameObj_Parent, bool a_bIsStay_WorldState = false)
	{
		return Factory.CreateGameObj(a_oName,
			a_oGameObj_Parent, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static GameObject CreateGameObj(string a_oName,
		GameObject a_oGameObj_Parent, Vector3 a_stPos, bool a_bIsStay_WorldState = false)
	{
		return Factory.CreateGameObj(a_oName,
			a_oGameObj_Parent, a_stPos, Vector3.one, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static GameObject CreateGameObj(string a_oName,
		GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stScale, Vector3 a_stRotate, bool a_bIsStay_WorldState = false)
	{
		var oGameObj = new GameObject(a_oName);
		oGameObj.transform.SetParent(a_oGameObj_Parent?.transform, a_bIsStay_WorldState);

		oGameObj.transform.localPosition = a_stPos;
		oGameObj.transform.localScale = a_stScale;
		oGameObj.transform.localEulerAngles = a_stRotate;

		return oGameObj;
	}
	#endregion // 클래스 팩토리 함수

	#region 클래스 팩토리 함수
	/** 객체를 생성한다 */
	public static T CreateGameObj<T>(string a_oName,
		GameObject a_oGameObj_Parent, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj<T>(a_oName,
			a_oGameObj_Parent, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static T CreateGameObj<T>(string a_oName,
		GameObject a_oGameObj_Parent, Vector3 a_stPos, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj<T>(a_oName,
			a_oGameObj_Parent, a_stPos, Vector3.one, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static T CreateGameObj<T>(string a_oName,
		GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stScale, Vector3 a_stRotate, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj(a_oName,
			a_oGameObj_Parent, a_stPos, a_stScale, a_stRotate, a_bIsStay_WorldState).ExAddComponent<T>();
	}
	#endregion // 클래스 팩토리 함수
}

/**
 * 팩토리 - 게임 객체 (사본)
 */
public static partial class Factory
{
	#region 클래스 팩토리 함수
	/** 객체를 생성한다 */
	public static GameObject CreateGameObj_Clone(string a_oName,
		string a_oPath_Prefab, GameObject a_oGameObj_Parent, bool a_bIsStay_WorldState = false)
	{
		return Factory.CreateGameObj_Clone(a_oName,
			a_oPath_Prefab, a_oGameObj_Parent, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static GameObject CreateGameObj_Clone(string a_oName,
		string a_oPath_Prefab, GameObject a_oGameObj_Parent, Vector3 a_stPos, bool a_bIsStay_WorldState = false)
	{
		return Factory.CreateGameObj_Clone(a_oName,
			a_oPath_Prefab, a_oGameObj_Parent, a_stPos, Vector3.one, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static GameObject CreateGameObj_Clone(string a_oName,
		string a_oPath_Prefab, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stScale, Vector3 a_stRotate, bool a_bIsStay_WorldState = false)
	{
		return Factory.CreateGameObj_Clone(a_oName,
			Resources.Load<GameObject>(a_oPath_Prefab), a_oGameObj_Parent, a_stPos, a_stScale, a_stRotate, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static GameObject CreateGameObj_Clone(string a_oName,
		GameObject a_oPrefab_Origin, GameObject a_oGameObj_Parent, bool a_bIsStay_WorldState = false)
	{
		return Factory.CreateGameObj_Clone(a_oName,
			a_oPrefab_Origin, a_oGameObj_Parent, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static GameObject CreateGameObj_Clone(string a_oName,
		GameObject a_oPrefab_Origin, GameObject a_oGameObj_Parent, Vector3 a_stPos, bool a_bIsStay_WorldState = false)
	{
		return Factory.CreateGameObj_Clone(a_oName,
			a_oPrefab_Origin, a_oGameObj_Parent, a_stPos, Vector3.one, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static GameObject CreateGameObj_Clone(string a_oName,
		GameObject a_oPrefab_Origin, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stScale, Vector3 a_stRotate, bool a_bIsStay_WorldState = false)
	{
		var oGameObj = MonoBehaviour.Instantiate(a_oPrefab_Origin,
			Vector3.zero, Quaternion.identity);

		oGameObj.name = a_oName;
		oGameObj.transform.SetParent(a_oGameObj_Parent?.transform, a_bIsStay_WorldState);

		oGameObj.transform.localPosition = a_stPos;
		oGameObj.transform.localScale = a_stScale;
		oGameObj.transform.localEulerAngles = a_stRotate;

		return oGameObj;
	}
	#endregion // 클래스 팩토리 함수

	#region 제네릭 클래스 팩토리 함수
	/** 객체를 생성한다 */
	public static T CreateGameObj_Clone<T>(string a_oName,
		string a_oPath_Prefab, GameObject a_oGameObj_Parent, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj_Clone<T>(a_oName,
			a_oPath_Prefab, a_oGameObj_Parent, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static T CreateGameObj_Clone<T>(string a_oName,
		string a_oPath_Prefab, GameObject a_oGameObj_Parent, Vector3 a_stPos, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj_Clone<T>(a_oName,
			a_oPath_Prefab, a_oGameObj_Parent, a_stPos, Vector3.one, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static T CreateGameObj_Clone<T>(string a_oName,
		string a_oPath_Prefab, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stScale, Vector3 a_stRotate, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj_Clone<T>(a_oName,
			Resources.Load<GameObject>(a_oPath_Prefab), a_oGameObj_Parent, a_stPos, a_stScale, a_stRotate, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static T CreateGameObj_Clone<T>(string a_oName,
		GameObject a_oPrefab_Origin, GameObject a_oGameObj_Parent, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj_Clone<T>(a_oName,
			a_oPrefab_Origin, a_oGameObj_Parent, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static T CreateGameObj_Clone<T>(string a_oName,
		GameObject a_oPrefab_Origin, GameObject a_oGameObj_Parent, Vector3 a_stPos, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj_Clone<T>(a_oName,
			a_oPrefab_Origin, a_oGameObj_Parent, a_stPos, Vector3.one, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static T CreateGameObj_Clone<T>(string a_oName,
		GameObject a_oPrefab_Origin, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stScale, Vector3 a_stRotate, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj_Clone(a_oName,
			a_oPrefab_Origin, a_oGameObj_Parent, a_stPos, a_stScale, a_stRotate, a_bIsStay_WorldState).GetComponentInChildren<T>();
	}
	#endregion // 제네릭 클래스 팩토리 함수
}
