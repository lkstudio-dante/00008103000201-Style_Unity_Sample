using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 충돌 이벤트 전파자 - 2 차원
 */
public partial class CDispatcher_Trigger : CComponent
{
	#region 프로퍼티
	public System.Action<CDispatcher_Trigger, Collider2D> _2DCallback_Enter { get; private set; } = null;
	public System.Action<CDispatcher_Trigger, Collider2D> _2DCallback_Stay { get; private set; } = null;
	public System.Action<CDispatcher_Trigger, Collider2D> _2DCallback_Exit { get; private set; } = null;
	#endregion // 프로퍼티

	#region 함수
	/** 충돌이 시작되었을 경우 */
	public void OnTriggerEnter2D(Collider2D a_oCollider)
	{
		this._2DCallback_Enter?.Invoke(this, a_oCollider);
	}

	/** 충돌이 진행 중 일 경우 */
	public void OnTriggerStay2D(Collider2D a_oCollider)
	{
		this._2DCallback_Stay?.Invoke(this, a_oCollider);
	}

	/** 충돌이 종료되었을 경우 */
	public void OnTriggerExit2D(Collider2D a_oCollider)
	{
		this._2DCallback_Exit?.Invoke(this, a_oCollider);
	}
	#endregion // 함수

	#region 접근 함수
	/** 충돌 시작 콜백을 변경한다 */
	public void SetCallback_Enter(System.Action<CDispatcher_Trigger, Collider2D> a_oCallback)
	{
		this._2DCallback_Enter = a_oCallback;
	}

	/** 충돌 진행 콜백을 변경한다 */
	public void SetCallback_Stay(System.Action<CDispatcher_Trigger, Collider2D> a_oCallback)
	{
		this._2DCallback_Stay = a_oCallback;
	}

	/** 충돌 종료 콜백을 변경한다 */
	public void SetCallback_Exit(System.Action<CDispatcher_Trigger, Collider2D> a_oCallback)
	{
		this._2DCallback_Exit = a_oCallback;
	}
	#endregion // 접근 함수
}

/**
 * 충돌 이벤트 전파자 - 3 차원
 */
public partial class CDispatcher_Trigger : CComponent
{
	#region 프로퍼티
	public System.Action<CDispatcher_Trigger, Collider> _3DCallback_Enter { get; private set; } = null;
	public System.Action<CDispatcher_Trigger, Collider> _3DCallback_Stay { get; private set; } = null;
	public System.Action<CDispatcher_Trigger, Collider> _3DCallback_Exit { get; private set; } = null;
	#endregion // 프로퍼티

	#region 함수
	/** 충돌이 시작되었을 경우 */
	public void OnTriggerEnter(Collider a_oCollider)
	{
		this._3DCallback_Enter?.Invoke(this, a_oCollider);
	}

	/** 충돌이 진행 중 일 경우 */
	public void OnTriggerStay(Collider a_oCollider)
	{
		this._3DCallback_Stay?.Invoke(this, a_oCollider);
	}

	/** 충돌이 종료되었을 경우 */
	public void OnTriggerExit(Collider a_oCollider)
	{
		this._3DCallback_Exit?.Invoke(this, a_oCollider);
	}
	#endregion // 함수

	#region 접근 함수
	/** 충돌 시작 콜백을 변경한다 */
	public void SetCallback_Enter(System.Action<CDispatcher_Trigger, Collider> a_oCallback)
	{
		this._3DCallback_Enter = a_oCallback;
	}

	/** 충돌 진행 콜백을 변경한다 */
	public void SetCallback_Stay(System.Action<CDispatcher_Trigger, Collider> a_oCallback)
	{
		this._3DCallback_Stay = a_oCallback;
	}

	/** 충돌 종료 콜백을 변경한다 */
	public void SetCallback_Exit(System.Action<CDispatcher_Trigger, Collider> a_oCallback)
	{
		this._3DCallback_Exit = a_oCallback;
	}
	#endregion // 접근 함수
}
