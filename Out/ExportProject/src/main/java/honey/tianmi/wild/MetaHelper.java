package honey.tianmi.wild;

import android.content.Context;
import android.util.Log;

import we.studio.embed.metasec.MetaSecHelper;

public class MetaHelper {
    public static void CommitLicense(Context context, String license)
    {
        //int identifier = context.getResources().getIdentifier("rangers_channel_id", "string", context.getPackageName());
        MetaSecHelper.getInstance().init(context, "221325", license,
                new MetaSecHelper.OnDeviceIDListener() {
                    @Override
                    public void onIdLoaded(String deviceID, String installID) {
                        Log.d("License", "OnIDLoaded= deviceID: " + deviceID + " install id" + installID);
                    }
                });
    }
}
