// Contribution (Created CSharp Version) 10/2010: Daniel P. Rossi (DR9885)
// Contribution (Created Bool Array) 10/2010: Daniel P. Rossi (DR9885)
// Contribution (Made functions public) 01/2011: Bren

using UnityEngine;
using System;

public static class PlayerPrefsX
{
	#region Vector3 Array

    /// <summary>
    /// Stores a Vector3 Array or Multiple Parameters into a Key
    /// </summary>
    public static bool SetVector3Array(string key, params Vector3[] Vector3Array)
    {
        if (Vector3Array.Length == 0) return false;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < Vector3Array.Length - 1; i++)
            sb.Append(Vector3Array[i]).Append("|");
        sb.Append(Vector3Array[Vector3Array.Length - 1]);
        try
        {
            PlayerPrefs.SetString(key, sb.ToString());
//			Debug.Log("111111+" + sb.ToString());
        }
        catch (Exception e)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Returns a Float Array from a Key
    /// </summary>
    public static Vector3[] GetVector3Array(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            String[] stringArray = PlayerPrefs.GetString(key).Split("|"[0]);
            float[] Vector3Array_x = new float[stringArray.Length];
			float[] Vector3Array_y = new float[stringArray.Length];
			float[] Vector3Array_z = new float[stringArray.Length];
			Vector3[] newVector3 = new Vector3[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
			{
				Vector3Array_x[i] = Convert.ToSingle(stringArray[i].Substring(1,3));
				Vector3Array_y[i] = Convert.ToSingle(stringArray[i].Substring(5,4));
				Vector3Array_z[i] = Convert.ToSingle(stringArray[i].Substring(10,3));
				newVector3[i] = new Vector3(Vector3Array_x[i],Vector3Array_y[i],Vector3Array_z[i]);
//				Debug.Log("222222+" + newVector3[i]);
			}
               return newVector3;
        }
        return new Vector3[0];
    }

    #endregion
	
	#region Vector2 Array

    /// <summary>
    /// Stores a Vector2 Array or Multiple Parameters into a Key
    /// </summary>
    public static bool SetVector2Array(string key, params Vector2[] Vector2Array)
    {
        if (Vector2Array.Length == 0) return false;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < Vector2Array.Length - 1; i++)
            sb.Append(Vector2Array[i]).Append("|");
        sb.Append(Vector2Array[Vector2Array.Length - 1]);
        try
        {
            PlayerPrefs.SetString(key, sb.ToString());
	//		Debug.Log("!!!!!!! =" +sb.ToString() );
        }
        catch (Exception e)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Returns a Float Array from a Key
    /// </summary>
    public static Vector2[] GetVector2Array(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            String[] stringArray = PlayerPrefs.GetString(key).Split("|"[0]);
            float[] Vector2Array_x = new float[stringArray.Length];
			float[] Vector2Array_y = new float[stringArray.Length];
			Vector2[] newVector2 = new Vector2[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
			{
				Vector2Array_x[i] = Convert.ToSingle(stringArray[i].Substring(1,3));
				Vector2Array_y[i] = Convert.ToSingle(stringArray[i].Substring(5,4));
				newVector2[i] = new Vector2(Vector2Array_x[i],Vector2Array_y[i]);
				
			}
		//		Debug.Log("new Vector2[i] =" + newVector2[1] + "new Vector2[i] =" + newVector2[2] + "new Vector2[i] =" + newVector2[3] + "new Vector2[i] =" + newVector2[4] + "new Vector2[0] =" + newVector2[0]);
               return newVector2;
			
        }
        return new Vector2[0];
    }

    #endregion
	
	#region Vector 2

    /// <summary>
    /// Stores a Vector2 value into a Key
    /// </summary>
    public static bool SetVector2(string key, Vector2 vector)
    {
        return SetFloatArray(key, new float[2] { vector.x, vector.y });
    }

    /// <summary>
    /// Finds a Vector3 value from a Key
    /// </summary>
    public static Vector2 GetVector2(string key)
    {
        float[] floatArray = GetFloatArray(key);
        if (floatArray.Length < 2)
            return Vector2.zero;
        return new Vector2(floatArray[0], floatArray[1]);
    }

    #endregion
	
    #region Vector 3

    /// <summary>
    /// Stores a Vector3 value into a Key
    /// </summary>
    public static bool SetVector3(string key, Vector3 vector)
    {
        return SetFloatArray(key, new float[3] { vector.x, vector.y, vector.z });
    }

    /// <summary>
    /// Finds a Vector3 value from a Key
    /// </summary>
    public static Vector3 GetVector3(string key)
    {
        float[] floatArray = GetFloatArray(key);
        if (floatArray.Length < 3)
            return Vector3.zero;
        return new Vector3(floatArray[0], floatArray[1], floatArray[2]);
    }

    #endregion

    #region Bool Array

    /// <summary>
    /// Stores a Bool Array or Multiple Parameters into a Key
    /// </summary>
    public static bool SetBoolArray(string key, params bool[] boolArray)
    {
        if (boolArray.Length == 0) return false;

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < boolArray.Length - 1; i++)
            sb.Append(boolArray[i]).Append("|");
        sb.Append(boolArray[boolArray.Length - 1]);

        try { PlayerPrefs.SetString(key, sb.ToString()); }
        catch (Exception e) { return false; }
        return true;
    }

    /// <summary>
    /// Returns a Bool Array from a Key
    /// </summary>
    public static bool[] GetBoolArray(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string[] stringArray = PlayerPrefs.GetString(key).Split("|"[0]);
            bool[] boolArray = new bool[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
                boolArray[i] = Convert.ToBoolean(stringArray[i]);
            return boolArray;
        }
        return new bool[0];
    }

    /// <summary>
    /// Returns a Bool Array from a Key
    /// Note: Uses default values to initialize if no key was found
    /// </summary>
    public static bool[] GetBoolArray(string key, bool defaultValue, int defaultSize)
    {
        if (PlayerPrefs.HasKey(key))
            return GetBoolArray(key);
        bool[] boolArray = new bool[defaultSize];
        for (int i = 0; i < defaultSize; i++)
            boolArray[i] = defaultValue;
        return boolArray;
    }

    #endregion

    #region Int Array

    /// <summary>
    /// Stores a Int Array or Multiple Parameters into a Key
    /// </summary>
    public static bool SetIntArray(string key, params int[] intArray)
    {
        if (intArray.Length == 0) return false;

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < intArray.Length - 1; i++)
            sb.Append(intArray[i]).Append("|");
        sb.Append(intArray[intArray.Length - 1]);

        try { PlayerPrefs.SetString(key, sb.ToString()); }
        catch (Exception e) { return false; }
        return true;
    }

    /// <summary>
    /// Returns a Int Array from a Key
    /// </summary>
    public static int[] GetIntArray(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string[] stringArray = PlayerPrefs.GetString(key).Split("|"[0]);
            int[] intArray = new int[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
                intArray[i] = Convert.ToInt32(stringArray[i]);
            return intArray;
        }
        return new int[0];
    }

    /// <summary>
    /// Returns a Int Array from a Key
    /// Note: Uses default values to initialize if no key was found
    /// </summary>
    public static int[] GetIntArray(string key, int defaultValue, int defaultSize)
    {
        if (PlayerPrefs.HasKey(key))
            return GetIntArray(key);
        int[] intArray = new int[defaultSize];
        for (int i = 0; i < defaultSize; i++)
            intArray[i] = defaultValue;
        return intArray;
    }

    #endregion

    #region Float Array

    /// <summary>
    /// Stores a Float Array or Multiple Parameters into a Key
    /// </summary>
    public static bool SetFloatArray(string key, params float[] floatArray)
    {
        if (floatArray.Length == 0) return false;

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < floatArray.Length - 1; i++)
            sb.Append(floatArray[i]).Append("|");
        sb.Append(floatArray[floatArray.Length - 1]);

        try
        {
            PlayerPrefs.SetString(key, sb.ToString());
        }
        catch (Exception e)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Returns a Float Array from a Key
    /// </summary>
    public static float[] GetFloatArray(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string[] stringArray = PlayerPrefs.GetString(key).Split("|"[0]);
            float[] floatArray = new float[stringArray.Length];
            for (int i = 0; i < stringArray.Length; i++)
                floatArray[i] = Convert.ToSingle(stringArray[i]);
            return floatArray;
        }
        return new float[0];
    }

    /// <summary>
    /// Returns a String Array from a Key
    /// Note: Uses default values to initialize if no key was found
    /// </summary>
    public static float[] GetFloatArray(string key, float defaultValue, int defaultSize)
    {
        if (PlayerPrefs.HasKey(key))
            return GetFloatArray(key);
        float[] floatArray = new float[defaultSize];
        for (int i = 0; i < defaultSize; i++)
            floatArray[i] = defaultValue;
        return floatArray;
    }

    #endregion

    #region String Array

    /// <summary>
    /// Stores a String Array or Multiple Parameters into a Key w/ specific char seperator
    /// </summary>
    public static bool SetStringArray(string key, char separator, params string[] stringArray)
    {
        if (stringArray.Length == 0) return false;
        try
        { PlayerPrefs.SetString(key, String.Join(separator.ToString(), stringArray)); }
        catch (Exception e)
        { return false; }
        return true;
    }

    /// <summary>
    /// Stores a Bool Array or Multiple Parameters into a Key
    /// </summary>
    public static bool SetStringArray(string key, params string[] stringArray)
    {
        if (!SetStringArray(key, "\n"[0], stringArray))
            return false;
        return true;
    }

    /// <summary>
    /// Returns a String Array from a key & char seperator
    /// </summary>
    public static string[] GetStringArray(string key, char separator)
    {
        if (PlayerPrefs.HasKey(key))
            return PlayerPrefs.GetString(key).Split(separator);
        return new string[0];
    }

    /// <summary>
    /// Returns a Bool Array from a key
    /// </summary>
    public static string[] GetStringArray(string key)
    {
        if (PlayerPrefs.HasKey(key))
            return PlayerPrefs.GetString(key).Split("\n"[0]);
        return new string[0];
    }

    /// <summary>
    /// Returns a String Array from a key & char seperator
    /// Note: Uses default values to initialize if no key was found
    /// </summary>
    public static string[] GetStringArray(string key, char separator, string defaultValue, int defaultSize)
    {
        if (PlayerPrefs.HasKey(key))
            return PlayerPrefs.GetString(key).Split(separator);
        string[] stringArray = new string[defaultSize];
        for (int i = 0; i < defaultSize; i++)
            stringArray[i] = defaultValue;
        return stringArray;
    }

    /// <summary>
    /// Returns a String Array from a key
    /// Note: Uses default values to initialize if no key was found
    /// </summary>
    public static String[] GetStringArray(string key, string defaultValue, int defaultSize)
    {
        return GetStringArray(key, "\n"[0], defaultValue, defaultSize);
    }

    #endregion
}

