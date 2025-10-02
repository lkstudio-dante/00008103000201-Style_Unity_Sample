using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using UnityEngine.SceneManagement;

/**
 * 씬 로더
 */
public partial class CLoader_Scene : CSingleton<CLoader_Scene>
{
	#region 함수
	/** 씬을 로드한다 */
	public void LoadScene(string a_oName_Scene, bool a_bIsSingle = true)
	{
		SceneManager.LoadScene(a_oName_Scene,
			a_bIsSingle ? LoadSceneMode.Single : LoadSceneMode.Additive);
	}

	/** 씬을 로드한다 */
	public void LoadScene_Async(string a_oName_Scene,
		System.Action<CLoader_Scene, AsyncOperation, bool> a_oCallback, float a_fDelay = 0.0f, bool a_bIsSingle = true)
	{
		var oEnumerator = this.CoLoadScene_Async_Internal(a_oName_Scene,
			a_oCallback, a_fDelay, a_bIsSingle);

		StartCoroutine(oEnumerator);
	}
	#endregion // 함수
}

/**
 * 씬 로더 - 코루틴
 */
public partial class CLoader_Scene : CSingleton<CLoader_Scene>
{
	#region 코루틴 함수
	/** 씬을 로드한다 */
	private IEnumerator CoLoadScene_Async_Internal(string a_oName_Scene,
		System.Action<CLoader_Scene, AsyncOperation, bool> a_oCallback, float a_fDelay, bool a_bIsSingle)
	{
		yield return Access.CoGetWait_ForSecs(a_fDelay, true);

		var oOperation_Async = SceneManager.LoadSceneAsync(a_oName_Scene,
			a_bIsSingle ? LoadSceneMode.Single : LoadSceneMode.Additive);

		CManager_Task.Inst.CoWaitOperation_Async(oOperation_Async,
			(a_oOperation_Async, a_bIsComplete) =>
		{
			a_oCallback?.Invoke(this, a_oOperation_Async, a_bIsComplete);
		});
	}
	#endregion // 코루틴 함수
}
