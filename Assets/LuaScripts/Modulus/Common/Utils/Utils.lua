Utils = {}

function Utils:newObj(name)
	local name = name and name or ''
   	return CS.UnityEngine.GameObject(name)
end