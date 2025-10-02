using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 컴포넌트
 */
public abstract partial class CComponent : MonoBehaviour, IUpdatable
{
	#region 프로퍼티
	public bool IsDestroy { get; private set; } = false;

	public bool IsDirty_Info { get; private set; } = false;
	public bool IsDirty_State { get; private set; } = false;
	public bool IsDirty_Layout { get; private set; } = false;

	public System.Action<CComponent> Callback_Destroy { get; private set; } = null;
	public System.Action<CComponent> Callback_Schedule { get; private set; } = null;
	public System.Action<CComponent> Callback_NavStack { get; private set; } = null;

	public virtual bool IsEnable => !this.IsDestroy &&
		this.enabled && this.gameObject.activeInHierarchy;
	#endregion // 프로퍼티

	#region IUpdatable
	/** 상태를 갱신한다 */
	public virtual void OnUpdate(float a_fTime_Delta)
	{
		// Do Something
	}

	/** 상태를 갱신한다 */
	public virtual void OnUpdate_Late(float a_fTime_Delta)
	{
		// 정보 저장이 필요 할 경우
		if(this.IsDirty_Info)
		{
			this.SetIsDirty_Info(false, true);
			this.SaveInfo();
		}

		// 상태 갱신이 필요 할 경우
		if(this.IsDirty_State)
		{
			this.SetIsDirty_State(false, true);
			this.UpdateState();
		}

		// 레이아웃 재배치가 필요 할 경우
		if(this.IsDirty_Layout)
		{
			this.SetIsDirty_Layout(false, true);
			this.RebuildLayout();
		}
	}

	/** 상태를 갱신한다 */
	public virtual void OnUpdate_Fixed(float a_fTime_Delta)
	{
		// Do Something
	}
	#endregion // IUpdatable

	#region 함수
	/** 초기화 */
	public virtual void Awake()
	{
		// Do Something
	}

	/** 초기화 */
	public virtual void Start()
	{
		// Do Something
	}

	/** 상태를 리셋한다 */
	public virtual void Reset()
	{
		// Do Something
	}

	/** 제거되었을 경우 */
	public virtual void OnDestroy()
	{
		this.IsDestroy = true;

		this.Callback_Destroy?.Invoke(this);
		this.Callback_Schedule?.Invoke(this);
		this.Callback_NavStack?.Invoke(this);
	}

	/** 내비게이션 스택 이벤트를 처리한다 */
	public virtual void HandleOnEvent_NavStack(EEvent_NavStack a_eEvent)
	{
		// Do Something
	}

	/** 정보를 저장한다 */
	protected virtual void SaveInfo()
	{
		// Do Something
	}

	/** 상태를 갱신한다 */
	protected virtual void UpdateState()
	{
		// Do Something
	}

	/** 레이아웃을 재배치한다 */
	protected virtual void RebuildLayout()
	{
		// Do Something
	}
	#endregion // 함수

	#region 접근 함수
	/** 정보 저장 여부를 변경한다 */
	public void SetIsDirty_Info(bool a_bIsDirty, bool a_bIsForce = false)
	{
		// 강제 모드 일 경우
		if(a_bIsForce)
		{
			this.IsDirty_Info = a_bIsDirty;
		}
		else
		{
			this.IsDirty_Info = this.IsDirty_Info || a_bIsDirty;
		}
	}

	/** 상태 갱신 여부를 변경한다 */
	public void SetIsDirty_State(bool a_bIsDirty, bool a_bIsForce = false)
	{
		// 강제 모드 일 경우
		if(a_bIsForce)
		{
			this.IsDirty_State = a_bIsDirty;
		}
		else
		{
			this.IsDirty_State = this.IsDirty_State || a_bIsDirty;
		}
	}

	/** 레이아웃 재배치 여부를 변경한다 */
	public void SetIsDirty_Layout(bool a_bIsDirty, bool a_bIsForce = false)
	{
		// 강제 모드 일 경우
		if(a_bIsForce)
		{
			this.IsDirty_Layout = a_bIsDirty;
		}
		else
		{
			this.IsDirty_Layout = this.IsDirty_Layout || a_bIsDirty;
		}
	}

	/** 제거 콜백을 변경한다 */
	public void SetCallback_Destroy(System.Action<CComponent> a_oCallback)
	{
		this.Callback_Destroy = a_oCallback;
	}

	/** 스케줄 콜백을 변경한다 */
	public void SetCallback_Schedule(System.Action<CComponent> a_oCallback)
	{
		this.Callback_Schedule = a_oCallback;
	}

	/** 내비게이션 스택 콜백을 변경한다 */
	public void SetCallback_NavStack(System.Action<CComponent> a_oCallback)
	{
		this.Callback_NavStack = a_oCallback;
	}
	#endregion // 접근 함수
}
