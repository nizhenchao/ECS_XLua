ConfigHelper = { }

function ConfigHelper:getConfig(name)
	if _G[name] == nil then 
		require ("Assets.LuaScripts.Config."..name)
	end 
	return _G[name]
end 

function ConfigHelper:getConfigByKey(name,key)
	if _G[name] == nil then 
		require ("Assets.LuaScripts.Config."..name)
	end 
	return _G[name][key]
end 