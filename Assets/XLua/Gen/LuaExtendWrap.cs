#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class LuaExtendWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LuaExtend);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 29, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getLUID", _m_getLUID_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getSUID", _m_getSUID_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getVectorAngle", _m_getVectorAngle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "loadObj", _m_loadObj_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "destroyObj", _m_destroyObj_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "loadScene", _m_loadScene_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "addMillHandler", _m_addMillHandler_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "addSecHandler", _m_addSecHandler_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "addMinHandler", _m_addMinHandler_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "addEveryMillHandler", _m_addEveryMillHandler_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "removeTimer", _m_removeTimer_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getMillTimer", _m_getMillTimer_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getSecTimer", _m_getSecTimer_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setObjPos", _m_setObjPos_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setActive", _m_setActive_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setUINode", _m_setUINode_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setSprite", _m_setSprite_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getNode", _m_getNode_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getNodeByRecursion", _m_getNodeByRecursion_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "addEventListener", _m_addEventListener_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setMaterialFloat", _m_setMaterialFloat_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "doUpDownScaleAnim", _m_doUpDownScaleAnim_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "doLocalMoveTo", _m_doLocalMoveTo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "doFloatTo", _m_doFloatTo_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "killTweener", _m_killTweener_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "lerpRotation", _m_lerpRotation_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setCameraPlayer", _m_setCameraPlayer_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "doShake", _m_doShake_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "LuaExtend does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getLUID_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        long __cl_gen_ret = LuaExtend.getLUID(  );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getSUID_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        int __cl_gen_ret = LuaExtend.getSUID(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getVectorAngle_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.Vector2 to;translator.Get(L, 1, out to);
                    UnityEngine.Vector2 from;translator.Get(L, 2, out from);
                    
                        float __cl_gen_ret = LuaExtend.getVectorAngle( to, from );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_loadObj_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string url = LuaAPI.lua_tostring(L, 1);
                    System.Action<UnityEngine.GameObject> callBack = translator.GetDelegate<System.Action<UnityEngine.GameObject>>(L, 2);
                    
                    LuaExtend.loadObj( url, callBack );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_destroyObj_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    
                    LuaExtend.destroyObj( obj );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_loadScene_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Action<float>>(L, 2)) 
                {
                    string level = LuaAPI.lua_tostring(L, 1);
                    System.Action<float> progress = translator.GetDelegate<System.Action<float>>(L, 2);
                    
                    LuaExtend.loadScene( level, progress );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string level = LuaAPI.lua_tostring(L, 1);
                    
                    LuaExtend.loadScene( level );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaExtend.loadScene!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_addMillHandler_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.Action<int>>(L, 2)&& translator.Assignable<System.Action<int>>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    int endCount = LuaAPI.xlua_tointeger(L, 1);
                    System.Action<int> eHandler = translator.GetDelegate<System.Action<int>>(L, 2);
                    System.Action<int> cHandler = translator.GetDelegate<System.Action<int>>(L, 3);
                    int interval = LuaAPI.xlua_tointeger(L, 4);
                    
                        long __cl_gen_ret = LuaExtend.addMillHandler( endCount, eHandler, cHandler, interval );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.Action<int>>(L, 2)&& translator.Assignable<System.Action<int>>(L, 3)) 
                {
                    int endCount = LuaAPI.xlua_tointeger(L, 1);
                    System.Action<int> eHandler = translator.GetDelegate<System.Action<int>>(L, 2);
                    System.Action<int> cHandler = translator.GetDelegate<System.Action<int>>(L, 3);
                    
                        long __cl_gen_ret = LuaExtend.addMillHandler( endCount, eHandler, cHandler );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.Action<int>>(L, 2)) 
                {
                    int endCount = LuaAPI.xlua_tointeger(L, 1);
                    System.Action<int> eHandler = translator.GetDelegate<System.Action<int>>(L, 2);
                    
                        long __cl_gen_ret = LuaExtend.addMillHandler( endCount, eHandler );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaExtend.addMillHandler!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_addSecHandler_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.Action<int>>(L, 2)&& translator.Assignable<System.Action<int>>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    int endCount = LuaAPI.xlua_tointeger(L, 1);
                    System.Action<int> eHandler = translator.GetDelegate<System.Action<int>>(L, 2);
                    System.Action<int> cHandler = translator.GetDelegate<System.Action<int>>(L, 3);
                    int interval = LuaAPI.xlua_tointeger(L, 4);
                    
                        long __cl_gen_ret = LuaExtend.addSecHandler( endCount, eHandler, cHandler, interval );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.Action<int>>(L, 2)&& translator.Assignable<System.Action<int>>(L, 3)) 
                {
                    int endCount = LuaAPI.xlua_tointeger(L, 1);
                    System.Action<int> eHandler = translator.GetDelegate<System.Action<int>>(L, 2);
                    System.Action<int> cHandler = translator.GetDelegate<System.Action<int>>(L, 3);
                    
                        long __cl_gen_ret = LuaExtend.addSecHandler( endCount, eHandler, cHandler );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.Action<int>>(L, 2)) 
                {
                    int endCount = LuaAPI.xlua_tointeger(L, 1);
                    System.Action<int> eHandler = translator.GetDelegate<System.Action<int>>(L, 2);
                    
                        long __cl_gen_ret = LuaExtend.addSecHandler( endCount, eHandler );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaExtend.addSecHandler!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_addMinHandler_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 4&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.Action<int>>(L, 2)&& translator.Assignable<System.Action<int>>(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    int endCount = LuaAPI.xlua_tointeger(L, 1);
                    System.Action<int> eHandler = translator.GetDelegate<System.Action<int>>(L, 2);
                    System.Action<int> cHandler = translator.GetDelegate<System.Action<int>>(L, 3);
                    int interval = LuaAPI.xlua_tointeger(L, 4);
                    
                        long __cl_gen_ret = LuaExtend.addMinHandler( endCount, eHandler, cHandler, interval );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.Action<int>>(L, 2)&& translator.Assignable<System.Action<int>>(L, 3)) 
                {
                    int endCount = LuaAPI.xlua_tointeger(L, 1);
                    System.Action<int> eHandler = translator.GetDelegate<System.Action<int>>(L, 2);
                    System.Action<int> cHandler = translator.GetDelegate<System.Action<int>>(L, 3);
                    
                        long __cl_gen_ret = LuaExtend.addMinHandler( endCount, eHandler, cHandler );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& translator.Assignable<System.Action<int>>(L, 2)) 
                {
                    int endCount = LuaAPI.xlua_tointeger(L, 1);
                    System.Action<int> eHandler = translator.GetDelegate<System.Action<int>>(L, 2);
                    
                        long __cl_gen_ret = LuaExtend.addMinHandler( endCount, eHandler );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaExtend.addMinHandler!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_addEveryMillHandler_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& translator.Assignable<System.Action<int>>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    System.Action<int> eHandler = translator.GetDelegate<System.Action<int>>(L, 1);
                    int interval = LuaAPI.xlua_tointeger(L, 2);
                    
                        long __cl_gen_ret = LuaExtend.addEveryMillHandler( eHandler, interval );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<System.Action<int>>(L, 1)) 
                {
                    System.Action<int> eHandler = translator.GetDelegate<System.Action<int>>(L, 1);
                    
                        long __cl_gen_ret = LuaExtend.addEveryMillHandler( eHandler );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaExtend.addEveryMillHandler!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_removeTimer_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    long uid = LuaAPI.lua_toint64(L, 1);
                    
                    LuaExtend.removeTimer( uid );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getMillTimer_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        double __cl_gen_ret = LuaExtend.getMillTimer(  );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getSecTimer_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        double __cl_gen_ret = LuaExtend.getSecTimer(  );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setObjPos_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 4&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.GameObject go = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    float x = (float)LuaAPI.lua_tonumber(L, 2);
                    float y = (float)LuaAPI.lua_tonumber(L, 3);
                    float z = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    LuaExtend.setObjPos( go, x, y, z );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.GameObject go = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    UnityEngine.Vector3 pos;translator.Get(L, 2, out pos);
                    
                    LuaExtend.setObjPos( go, pos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaExtend.setObjPos!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setActive_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    bool isActive = LuaAPI.lua_toboolean(L, 2);
                    
                    LuaExtend.setActive( obj, isActive );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setUINode_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.GameObject uiObj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    int node = LuaAPI.xlua_tointeger(L, 2);
                    
                    LuaExtend.setUINode( uiObj, node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setSprite_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    string name = LuaAPI.lua_tostring(L, 2);
                    
                    LuaExtend.setSprite( obj, name );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getNode_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.GameObject root = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    string path = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.GameObject __cl_gen_ret = LuaExtend.getNode( root, path );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_getNodeByRecursion_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.GameObject root = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    string nodeName = LuaAPI.lua_tostring(L, 2);
                    
                        UnityEngine.GameObject __cl_gen_ret = LuaExtend.getNodeByRecursion( root, nodeName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_addEventListener_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    
                        EventListener __cl_gen_ret = LuaExtend.addEventListener( obj );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setMaterialFloat_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.UI.Image img = (UnityEngine.UI.Image)translator.GetObject(L, 1, typeof(UnityEngine.UI.Image));
                    string key = LuaAPI.lua_tostring(L, 2);
                    float val = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    LuaExtend.setMaterialFloat( img, key, val );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_doUpDownScaleAnim_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& translator.Assignable<System.Action>(L, 3)) 
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    string title = LuaAPI.lua_tostring(L, 2);
                    System.Action onFinish = translator.GetDelegate<System.Action>(L, 3);
                    
                        DG.Tweening.Tweener __cl_gen_ret = LuaExtend.doUpDownScaleAnim( obj, title, onFinish );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    string title = LuaAPI.lua_tostring(L, 2);
                    
                        DG.Tweening.Tweener __cl_gen_ret = LuaExtend.doUpDownScaleAnim( obj, title );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 1&& translator.Assignable<UnityEngine.GameObject>(L, 1)) 
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    
                        DG.Tweening.Tweener __cl_gen_ret = LuaExtend.doUpDownScaleAnim( obj );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaExtend.doUpDownScaleAnim!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_doLocalMoveTo_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 5&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<DG.Tweening.TweenCallback>(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    float dur = (float)LuaAPI.lua_tonumber(L, 2);
                    UnityEngine.Vector3 end;translator.Get(L, 3, out end);
                    DG.Tweening.TweenCallback call = translator.GetDelegate<DG.Tweening.TweenCallback>(L, 4);
                    float delay = (float)LuaAPI.lua_tonumber(L, 5);
                    
                        DG.Tweening.Tweener __cl_gen_ret = LuaExtend.doLocalMoveTo( obj, dur, end, call, delay );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)&& translator.Assignable<DG.Tweening.TweenCallback>(L, 4)) 
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    float dur = (float)LuaAPI.lua_tonumber(L, 2);
                    UnityEngine.Vector3 end;translator.Get(L, 3, out end);
                    DG.Tweening.TweenCallback call = translator.GetDelegate<DG.Tweening.TweenCallback>(L, 4);
                    
                        DG.Tweening.Tweener __cl_gen_ret = LuaExtend.doLocalMoveTo( obj, dur, end, call );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<UnityEngine.Vector3>(L, 3)) 
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    float dur = (float)LuaAPI.lua_tonumber(L, 2);
                    UnityEngine.Vector3 end;translator.Get(L, 3, out end);
                    
                        DG.Tweening.Tweener __cl_gen_ret = LuaExtend.doLocalMoveTo( obj, dur, end );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaExtend.doLocalMoveTo!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_doFloatTo_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 5&& translator.Assignable<DG.Tweening.Core.DOSetter<float>>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<DG.Tweening.TweenCallback>(L, 5)) 
                {
                    DG.Tweening.Core.DOSetter<float> call = translator.GetDelegate<DG.Tweening.Core.DOSetter<float>>(L, 1);
                    float startValue = (float)LuaAPI.lua_tonumber(L, 2);
                    float endValue = (float)LuaAPI.lua_tonumber(L, 3);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    DG.Tweening.TweenCallback finish = translator.GetDelegate<DG.Tweening.TweenCallback>(L, 5);
                    
                        DG.Tweening.Tweener __cl_gen_ret = LuaExtend.doFloatTo( call, startValue, endValue, duration, finish );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                if(__gen_param_count == 4&& translator.Assignable<DG.Tweening.Core.DOSetter<float>>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    DG.Tweening.Core.DOSetter<float> call = translator.GetDelegate<DG.Tweening.Core.DOSetter<float>>(L, 1);
                    float startValue = (float)LuaAPI.lua_tonumber(L, 2);
                    float endValue = (float)LuaAPI.lua_tonumber(L, 3);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                        DG.Tweening.Tweener __cl_gen_ret = LuaExtend.doFloatTo( call, startValue, endValue, duration );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaExtend.doFloatTo!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_killTweener_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int __gen_param_count = LuaAPI.lua_gettop(L);
            
                if(__gen_param_count == 2&& translator.Assignable<DG.Tweening.Tweener>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    DG.Tweening.Tweener tw = (DG.Tweening.Tweener)translator.GetObject(L, 1, typeof(DG.Tweening.Tweener));
                    bool doComplete = LuaAPI.lua_toboolean(L, 2);
                    
                    LuaExtend.killTweener( tw, doComplete );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& translator.Assignable<DG.Tweening.Tweener>(L, 1)) 
                {
                    DG.Tweening.Tweener tw = (DG.Tweening.Tweener)translator.GetObject(L, 1, typeof(DG.Tweening.Tweener));
                    
                    LuaExtend.killTweener( tw );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaExtend.killTweener!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_lerpRotation_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    float angle = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    LuaExtend.lerpRotation( obj, angle );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setCameraPlayer_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    UnityEngine.GameObject player = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    
                    LuaExtend.setCameraPlayer( player );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_doShake_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float time = (float)LuaAPI.lua_tonumber(L, 1);
                    float att = (float)LuaAPI.lua_tonumber(L, 2);
                    float hor = (float)LuaAPI.lua_tonumber(L, 3);
                    float ver = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    LuaExtend.doShake( time, att, hor, ver );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
