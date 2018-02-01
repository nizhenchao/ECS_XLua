MathUtils = { }
function MathUtils:getShortUid()
	return CS.LuaExtend.getSUID()
end 

function MathUtils:getLongUid()
	return CS.LuaExtend.getLUID()
end 