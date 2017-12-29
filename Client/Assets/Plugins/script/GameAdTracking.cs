using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System;

namespace game {
	public class GameAdTracking
	{
		private static GameAdTracking _instance;
		
		public static GameAdTracking getInstance() {
			if( null == _instance ) {
				_instance = new GameAdTracking();
			}
			return _instance;
		}

		/**
     	* 
    	* @Title: onRegister 
    	* @Description: Call this method if you want to track register events as happening during a section.
    	* @param userId    user identifier
    	* @return void     
     	*/

		public  void onRegister(string userId)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameAdTracking_nativeOnRegister (userId);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
	 	*
		* @Title: onLogin
		* @Description:Call this method if you want to track login events as happening during a section.
		* @param userInfo  The details of this parameters are already covered by document.
		* @return void
	 	*/

		public  void onLogin(Dictionary<string,string> userInfo)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			string info = GameUtil.dictionaryToString (userInfo);
			Debug.Log("onLogin   " + info);
			GameAdTracking_nativeOnLogin (info);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	*
    	* @Title: onPay
    	* @Description: Call this method if you want to track pay events as happening during a section.
    	* @param  productInfo  The details of this parameters are already covered by document.
    	* @return void
     	*/
		
		public  void onPay(Dictionary<string,string> userInfo)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			string info = GameUtil.dictionaryToString (userInfo);
			Debug.Log("onPay   " + info);
			GameAdTracking_nativeOnPay (info);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
	 	*
		* @Title: trackEvent
		* @Description: Call this method if you want to track custom events with parameters as happening during a section.
		* @param eventId The custom event name.
		* @param  paramMap The details of this parameters are already covered by document.
	 	*/
		public  void  trackEvent (string eventId,Dictionary<string,string> paramMap = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			string value;
			if (paramMap == null) value = null; 
			else value = GameUtil.dictionaryToString (paramMap);
			GameAdTracking_nativeTrackEvent (eventId,value);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
     	@brief Check function the plugin support or not
     	*/

		public  bool  isFunctionSupported (string functionName)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			return GameAdTracking_nativeIsFunctionSupported (functionName);
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
		 * set debugmode for plugin
		 * 
		 */
		[Obsolete("This interface is obsolete!",false)]
		public  void setDebugMode(bool bDebug)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			GameAdTracking_nativeSetDebugMode (bDebug);
#else
			Debug.Log("This platform does not support!");
#endif
		}
		
		/**
		 * Get Plugin version
		 * 
		 * @return string
	 	*/

		public  string getPluginVersion()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder version = new StringBuilder();
			version.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameAdTracking_nativeGetPluginVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
		 * Get SDK version
		 * 
		 * @return string
	 	*/

		public  string getSDKVersion()
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder version = new StringBuilder();
			version.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameAdTracking_nativeGetSDKVersion (version);
			return version.ToString();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param GameParam param 
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, GameParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			GameAdTracking_nativeCallFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<GameParam> param 
    	 *@return void
    	 */
		public  void callFuncWithParam(string functionName, List<GameParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null) 
			{
				GameAdTracking_nativeCallFuncWithParam (functionName, null, 0);
				
			} else {
				GameAdTracking_nativeCallFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param GameParam param 
    	 *@return int
    	 */
		public  int callIntFuncWithParam(string functionName, GameParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			return GameAdTracking_nativeCallIntFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<GameParam> param 
    	 *@return int
    	 */
		public  int  callIntFuncWithParam(string functionName, List<GameParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return GameAdTracking_nativeCallIntFuncWithParam (functionName, null, 0);
				
			} else {
				return GameAdTracking_nativeCallIntFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return -1;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param GameParam param 
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, GameParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			return GameAdTracking_nativeCallFloatFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}
		

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<GameParam> param 
    	 *@return float
    	 */
		public  float callFloatFuncWithParam(string functionName, List<GameParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return GameAdTracking_nativeCallFloatFuncWithParam (functionName, null, 0);
				
			} else {
				return GameAdTracking_nativeCallFloatFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return 0;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param GameParam param 
    	 *@return string
    	 */
		public  bool callBoolFuncWithParam(string functionName, GameParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			return GameAdTracking_nativeCallBoolFuncWithParam(functionName, list.ToArray(),list.Count);
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<GameParam> param 
    	 *@return string
    	 */
		public  bool callBoolFuncWithParam(string functionName, List<GameParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			if (param == null)
			{
				return GameAdTracking_nativeCallBoolFuncWithParam (functionName, null, 0);
				
			} else {
				return GameAdTracking_nativeCallBoolFuncWithParam (functionName, param.ToArray (), param.Count);
			}
#else
			Debug.Log("This platform does not support!");
			return false;
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<GameParam> param 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, GameParam param)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			List<GameParam> list = new List<GameParam> ();
			list.Add (param);
			StringBuilder value = new StringBuilder();
			value.Capacity = GameUtil.MAX_CAPACITY_NUM;
			GameAdTracking_nativeCallStringFuncWithParam(functionName, list.ToArray(),list.Count,value);
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}

		/**
    	 *@brief methods for reflections
   	 	 *@param function name
   		 *@param List<GameParam> param 
    	 *@return string
    	 */
		public  string callStringFuncWithParam(string functionName, List<GameParam> param = null)
		{
#if !UNITY_EDITOR &&( UNITY_ANDROID ||  UNITY_IOS) 
			StringBuilder value = new StringBuilder();
			value.Capacity = GameUtil.MAX_CAPACITY_NUM;
			if (param == null)
			{
				GameAdTracking_nativeCallStringFuncWithParam (functionName, null, 0,value);
				
			} else {
				GameAdTracking_nativeCallStringFuncWithParam (functionName, param.ToArray (), param.Count,value);
			}
			return value.ToString ();
#else
			Debug.Log("This platform does not support!");
			return "";
#endif
		}
		
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAdTracking_nativeOnRegister(string userId);
		
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAdTracking_nativeOnLogin(string info);
		
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAdTracking_nativeOnPay(string info);

		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAdTracking_nativeTrackEvent(string eventId, string message);
		
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameAdTracking_nativeIsFunctionSupported(string functionName);
		
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAdTracking_nativeSetDebugMode(bool bDebug);
		
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAdTracking_nativeGetPluginVersion(StringBuilder version);
		
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAdTracking_nativeGetSDKVersion(StringBuilder version);
		
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAdTracking_nativeCallFuncWithParam(string functionName, GameParam[] param,int count);
		
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern int GameAdTracking_nativeCallIntFuncWithParam(string functionName, GameParam[] param,int count);
		
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern float GameAdTracking_nativeCallFloatFuncWithParam(string functionName, GameParam[] param,int count);
		
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern bool GameAdTracking_nativeCallBoolFuncWithParam(string functionName, GameParam[] param,int count);
		
		[DllImport(GameUtil.GAME_PLATFORM)]
		private static extern void GameAdTracking_nativeCallStringFuncWithParam(string functionName, GameParam[] param,int count,StringBuilder value);
	}
	
}


