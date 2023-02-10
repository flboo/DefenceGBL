package honey.tianmi.wild;

import android.content.Context;
import android.text.TextUtils;
import android.util.Log;
import com.mob.MobSDK;
import com.mob.OperationCallback;
import com.mob.PrivacyPolicy;
import com.mob.commons.dialog.entity.MobPolicyUi.Builder;
import com.mob.tools.utils.ResHelper;
import com.unity3d.player.UnityPlayer;

public class MobSDKUtils {
    private static String u3dGameObject;
    private static String u3dCallback;
    private static Context context;

    public MobSDKUtils(String gameObject, String u3dCallback) {
        if (context == null) {
            context = UnityPlayer.currentActivity.getApplicationContext();
        }

        if (!TextUtils.isEmpty(gameObject)) {
            u3dGameObject = gameObject;
        }

        if (!TextUtils.isEmpty(u3dCallback)) {
            honey.tianmi.wild.MobSDKUtils.u3dCallback = u3dCallback;
        }

    }

    public String getPrivacyPolicy(boolean url) {
        PrivacyPolicy policy;
        if (url) {
            policy = MobSDK.getPrivacyPolicy(1);
        } else {
            policy = MobSDK.getPrivacyPolicy(2);
        }

        return policy.getContent();
    }

    public boolean submitPolicyGrantResult(boolean granted) {
        final boolean[] result = new boolean[]{true};
        MobSDK.submitPolicyGrantResult(granted, new OperationCallback<Void>() {
            public void onComplete(Void data) {
                result[0] = true;
            }

            public void onFailure(Throwable t) {
                result[0] = false;
            }
        });

        try {
            return result[0];
        } catch (Throwable var4) {
            Log.e("ShareSDK", "result catch: " + var4);
            return false;
        }
    }

    public void setAllowDialog(boolean allowDialog) {
        MobSDK.setAllowDialog(allowDialog);
    }

    public void setPolicyUi(int backgroundColorId, int positiveBtnColorId, int negativeBtnColorId) {
        Builder builder = new Builder();
        if (backgroundColorId > 0) {
            builder = builder.setBackgroundColorId(backgroundColorId);
        }

        if (positiveBtnColorId > 0) {
            builder = builder.setPositiveBtnColorId(positiveBtnColorId);
        }

        if (negativeBtnColorId > 0) {
            builder = builder.setNegativeBtnColorId(negativeBtnColorId);
        }

        MobSDK.setPolicyUi(builder.build());
    }

    public void setPolicyUiRes(String backgroundColorRes, String positiveBtnColorRes, String negativeBtnColorRes) {
        int backgroundColorId = ResHelper.getColorRes(context, backgroundColorRes);
        int positiveBtnColorId = ResHelper.getColorRes(context, positiveBtnColorRes);
        int negativeBtnColorId = ResHelper.getColorRes(context, negativeBtnColorRes);
        this.setPolicyUi(backgroundColorId, positiveBtnColorId, negativeBtnColorId);
    }
}
