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
    public class CEntityWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(CEntity);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 1, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setPlayAudioEvent", _m_setPlayAudioEvent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setPlayEffectEvent", _m_setPlayEffectEvent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setPlayHitEvent", _m_setPlayHitEvent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "playAudio", _m_playAudio);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "playEffect", _m_playEffect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "playHit", _m_playHit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDestroy", _m_OnDestroy);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "UID", _g_get_UID);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "UID", _s_set_UID);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					CEntity __cl_gen_ret = new CEntity();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to CEntity constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setPlayAudioEvent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                CEntity __cl_gen_to_be_invoked = (CEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action<string> foo = translator.GetDelegate<System.Action<string>>(L, 2);
                    
                    __cl_gen_to_be_invoked.setPlayAudioEvent( foo );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setPlayEffectEvent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                CEntity __cl_gen_to_be_invoked = (CEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action<string> foo = translator.GetDelegate<System.Action<string>>(L, 2);
                    
                    __cl_gen_to_be_invoked.setPlayEffectEvent( foo );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_setPlayHitEvent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                CEntity __cl_gen_to_be_invoked = (CEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action<string> foo = translator.GetDelegate<System.Action<string>>(L, 2);
                    
                    __cl_gen_to_be_invoked.setPlayHitEvent( foo );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_playAudio(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                CEntity __cl_gen_to_be_invoked = (CEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string args = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.playAudio( args );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_playEffect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                CEntity __cl_gen_to_be_invoked = (CEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string args = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.playEffect( args );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_playHit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                CEntity __cl_gen_to_be_invoked = (CEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string args = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.playHit( args );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDestroy(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                CEntity __cl_gen_to_be_invoked = (CEntity)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    __cl_gen_to_be_invoked.OnDestroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                CEntity __cl_gen_to_be_invoked = (CEntity)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushint64(L, __cl_gen_to_be_invoked.UID);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                CEntity __cl_gen_to_be_invoked = (CEntity)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.UID = LuaAPI.lua_toint64(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
