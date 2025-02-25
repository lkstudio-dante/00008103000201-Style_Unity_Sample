using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 싱글턴
 */
public abstract partial class CSingleton<TInst> : CComponent
	where TInst : CSingleton<TInst>
{
	#region 클래스 변수
	private static TInst m_tInst = null;
	#endregion // 클래스 변수

	#region 프로퍼티
	public virtual bool IsEnable_Destroy => false;
	#endregion // 프로퍼티

	#region 클래스 프로퍼티
	public static TInst Inst
	{
		get
		{
			// 인스턴스가 없을 경우
			if(CSingleton<TInst>.m_tInst == null)
			{
				CSingleton<TInst>.m_tInst = Factory.CreateGameObj<TInst>(typeof(TInst).ToString(),
					null);

				Debug.Assert(CSingleton<TInst>.m_tInst != null);
			}

			return CSingleton<TInst>.m_tInst;
		}
	}
	#endregion // 클래스 프로퍼티

	#region 함수
	/** 생성자 */
	protected CSingleton()
	{
		// Do Something
	}

	/** 초기화 */
	public override void Awake()
	{
		base.Awake();
		Debug.Assert(CSingleton<TInst>.m_tInst == null);

		CSingleton<TInst>.m_tInst = this as TInst;

		// 인스턴스 제거 가능 상태 일 경우
		if(CSingleton<TInst>.m_tInst.IsEnable_Destroy)
		{
			return;
		}

		DontDestroyOnLoad(this.gameObject);
	}

	/** 제거되었을 경우 */
	public override void OnDestroy()
	{
		base.OnDestroy();
		CSingleton<TInst>.m_tInst = null;
	}
	#endregion // 함수

	#region 클래스 함수
	/** 인스턴스를 생성한다 */
	public static TInst Create()
	{
		return CSingleton<TInst>.Inst;
	}

	/** 인스턴스를 제거한다 */
	public static void Destroy()
	{
		// 인스턴스 제거가 불가능 할 경우
		if(CSingleton<TInst>.m_tInst == null ||
			!CSingleton<TInst>.m_tInst.IsEnable_Destroy)
		{
			return;
		}

		GameObject.Destroy(CSingleton<TInst>.m_tInst.gameObject);
	}
	#endregion // 클래스 함수
}
