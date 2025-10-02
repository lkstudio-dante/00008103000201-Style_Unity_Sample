using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#if UNITY_EDITOR
using UnityEditor;

/**
 * 에디터 씬 관리자
 */
[InitializeOnLoad]
public partial class CEditor_Manager_Scene
{
	#region 클래스 변수
	private static double m_dblTime_PrevUpdate = 0.0f;

	private static bool IsEnable_Update =>
		!EditorApplication.isPlaying && CEditor_Manager_Scene.Interval_Update.ExIsGreatEquals(1.0f);

	private static double Interval_Update =>
		EditorApplication.timeSinceStartup - m_dblTime_PrevUpdate;
	#endregion // 클래스 변수

	#region 클래스 함수
	/** 생성자 */
	static CEditor_Manager_Scene()
	{
		// 플레이 모드 일 경우
		if(EditorApplication.isPlaying)
		{
			return;
		}

		EditorApplication.update -= CEditor_Manager_Scene.Update;
		EditorApplication.update += CEditor_Manager_Scene.Update;

		EditorApplication.update -= CEditor_Manager_Scene.LateUpdate;
		EditorApplication.update += CEditor_Manager_Scene.LateUpdate;

		EditorApplication.playModeStateChanged -= CEditor_Manager_Scene.OnChangeState_PlayMode;
		EditorApplication.playModeStateChanged += CEditor_Manager_Scene.OnChangeState_PlayMode;

		CEditor_Manager_Scene.m_dblTime_PrevUpdate = EditorApplication.timeSinceStartup;
	}

	/** 상태를 갱신한다 */
	private static void Update()
	{
		// 상태 갱신이 불가능 할 경우
		if(!CEditor_Manager_Scene.IsEnable_Update)
		{
			return;
		}

		Func.EnumerateComponents<CManager_Scene>((a_oManager_Scene) =>
		{
			a_oManager_Scene.Editor_SetupScene();
			return true;
		});
	}

	/** 상태를 갱신한다 */
	private static void LateUpdate()
	{
		// 상태 갱신이 불가능 할 경우
		if(!CEditor_Manager_Scene.IsEnable_Update)
		{
			return;
		}

		m_dblTime_PrevUpdate = EditorApplication.timeSinceStartup;
	}

	/** 플레이 모드가 변경되었을 경우 */
	private static void OnChangeState_PlayMode(PlayModeStateChange a_eMode_Play)
	{
		switch(a_eMode_Play)
		{
			case PlayModeStateChange.EnteredEditMode:
				Access.SetTimeScale(1.0f);
				break;
		}
	}
	#endregion // 클래스 함수
}
#endif // #if UNITY_EDITOR
