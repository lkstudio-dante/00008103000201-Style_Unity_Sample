using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 상태 머신 처리자
 */
public abstract partial class CBehaviour_StateMachine : StateMachineBehaviour
{
	#region 프로퍼티
	public System.Action<CBehaviour_StateMachine, Animator, AnimatorStateInfo, int> Callback_Enter { get; private set; } = null;
	public System.Action<CBehaviour_StateMachine, Animator, AnimatorStateInfo, int> Callback_Exit { get; private set; } = null;
	public System.Action<CBehaviour_StateMachine, Animator, AnimatorStateInfo, int> Callback_Update { get; private set; } = null;
	#endregion // 프로퍼티

	#region 함수
	/** 상태가 시작되었을 경우 */
	public override void OnStateEnter(Animator a_oSender,
		AnimatorStateInfo a_stInfo_AnimatorState, int a_nIdx_Layer)
	{
		base.OnStateEnter(a_oSender, a_stInfo_AnimatorState, a_nIdx_Layer);
		this.Callback_Enter?.Invoke(this, a_oSender, a_stInfo_AnimatorState, a_nIdx_Layer);
	}

	/** 상태가 종료되었을 경우 */
	public override void OnStateExit(Animator a_oSender,
		AnimatorStateInfo a_stInfo_AnimatorState, int a_nIdx_Layer)
	{
		base.OnStateExit(a_oSender, a_stInfo_AnimatorState, a_nIdx_Layer);
		this.Callback_Exit?.Invoke(this, a_oSender, a_stInfo_AnimatorState, a_nIdx_Layer);
	}

	/** 상태를 갱신한다 */
	public override void OnStateUpdate(Animator a_oSender,
		AnimatorStateInfo a_stInfo_AnimatorState, int a_nIdx_Layer)
	{
		base.OnStateUpdate(a_oSender, a_stInfo_AnimatorState, a_nIdx_Layer);
		this.Callback_Update?.Invoke(this, a_oSender, a_stInfo_AnimatorState, a_nIdx_Layer);
	}
	#endregion // 함수

	#region 접근 함수
	/** 시작 콜백을 변경한다 */
	public void SetCallback_Enter(System.Action<CBehaviour_StateMachine, Animator, AnimatorStateInfo, int> a_oCallback)
	{
		this.Callback_Enter = a_oCallback;
	}

	/** 종료 콜백을 변경한다 */
	public void SetCallback_Exit(System.Action<CBehaviour_StateMachine, Animator, AnimatorStateInfo, int> a_oCallback)
	{
		this.Callback_Exit = a_oCallback;
	}

	/** 갱신 콜백을 변경한다 */
	public void SetCallback_Update(System.Action<CBehaviour_StateMachine, Animator, AnimatorStateInfo, int> a_oCallback)
	{
		this.Callback_Update = a_oCallback;
	}
	#endregion // 접근 함수
}
