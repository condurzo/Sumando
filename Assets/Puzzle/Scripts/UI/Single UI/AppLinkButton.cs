using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppLinkButton : SingleButton {

	protected override void Click () {
#if UNITY_ANDROID
        Application.OpenURL(ProjectConfig.googlePlayLink);
#endif
    }
}
