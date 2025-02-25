using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 빌보드
 */
public partial class CBillboard : CComponent
{
	#region 변수
	[Header("=====> Billboard - Etc <=====")]
	[SerializeField] private bool m_bIsBillboard_Cylinder = false;
	#endregion // 변수

	#region 함수
	/** 상태를 갱신한다 */
	public void LateUpdate()
	{
		var stDirection_Forward = Camera.main.transform.forward;
		stDirection_Forward.y = m_bIsBillboard_Cylinder ? 0.0f : stDirection_Forward.y;

		this.transform.forward = stDirection_Forward.normalized;
	}
	#endregion // 함수
}
