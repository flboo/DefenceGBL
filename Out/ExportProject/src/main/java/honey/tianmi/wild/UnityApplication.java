package honey.tianmi.wild;

import android.app.Activity;
import android.app.Application;
import android.content.Context;
import android.content.res.Configuration;
import android.util.Log;

import androidx.multidex.MultiDex;

import com.coala.statisticscore.StatisticsApplication;
import com.mob.moblink.MobLink;
import com.mob.moblink.Scene;
import com.richox.toolbox.RichOXToolbox;
import com.taurusx.ads.core.api.TaurusXAds;
import com.taurusx.ads.core.api.segment.Segment;

import com.tencent.bugly.Bugly;
import com.we.game.sdk.core.WeGameApplication;

/**
 * Created by Administrator on 2019/5/5.
 */

public class UnityApplication extends Application {

    public static Activity mUnityActivity;

    @Override
    public void onCreate() {

        super.onCreate();
        WeGameApplication.onCreate(this);
        //StatisticsApplication.onCreate(this);
         MobLink.setRestoreSceneListener(new com.mob.moblink.RestoreSceneListener() {
            @Override
            public Class<? extends Activity> willRestoreScene(Scene scene) {
                Class unityClazz = null;
                try {
                    //替换此处com.mob.moblink.unity.MobUnityPlayerActivity为您自己的入口activity
                    //也可以根据方法参数scene 执行调用打开相应的activity
                    unityClazz = Class.forName("honey.tianmi.wild.UnityMain");
                } catch (ClassNotFoundException e) {
                    Log.e("mobSDK", "Can not initialize UnityPlayerActivity", e);
                }
                return unityClazz;
            }

            @Override
            public void completeRestore(Scene scene) {
                Log.d("mobSDK", "Restore scene completed.");
            }

            @Override
            public void notFoundScene(Scene scene) {

            }
        });
         //richox聊天初始化 使用（不影响合规 很清白）
        RichOXToolbox.init(this);
    }

    @Override
    public void onTerminate() {
        super.onTerminate();
        WeGameApplication.onTerminate();
        StatisticsApplication.onTerminate();
    }
    @Override
    protected void attachBaseContext(Context base) {
        super.attachBaseContext(base);
        MultiDex.install(this);
        WeGameApplication.attachBaseContext(base);
        StatisticsApplication.attachBaseContext(base);
    }

    @Override
    public void onConfigurationChanged(Configuration newConfig) {
        super.onConfigurationChanged(newConfig);
        WeGameApplication.onConfigurationChanged(newConfig);
        StatisticsApplication.onConfigurationChanged(newConfig);
    }
}
