package honey.tianmi.wild;

import android.widget.Toast;

import com.nefarian.privacy.policy.IPrivacyPolicyCallback;
import com.nefarian.privacy.policy.PrivacyPolicyConfig;
import com.nefarian.privacy.policy.PrivacyPolicyHelper;

public class PrivacyHelper{

    private ExActivityListener listener;
    public void setListener(ExActivityListener listener)
    {
        this.listener=listener;
    }

    //创建隐私协议对象
    public PrivacyPolicyHelper getPrivacyHelper()
    {
        if (BuildConfig.CustomMark.equals("yyb")) {
            PrivacyPolicyConfig.getInstance().setChannelName("yyb");
        }
        PrivacyPolicyHelper privacyPolicyHelper =
                new PrivacyPolicyHelper.Builder(UnityApplication.mUnityActivity).callback(new IPrivacyPolicyCallback() {
                    @Override
                    public void onUserDisagree() {
                        if(listener != null) listener.onDisagree();
                    }

                    @Override
                    public void onUserAgree() {
                        if(listener != null) listener.onAgree();
                    }
                }).build();
        return privacyPolicyHelper;
    }
}
