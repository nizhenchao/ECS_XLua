--table的key 必须是1-n
function table.removeItem(list, item, removeAll)
	if list==nil then
		return
	end
    local rmCount = 0
    for i = 1, #list do
        if list[i - rmCount] == item then
            table.remove(list, i - rmCount)
            if removeAll then
                rmCount = rmCount + 1
            else
                break
            end
        end
    end
end

function table.deepcopy(t, n)
    if t==nil then
        return nil
    end
    local newT = {}
    if n == nil then    -- 默认为浅拷贝。。。
        n = 1
    end
    for i,v in pairs(t) do
        if n>0 and type(v) == "table" then
            local T = table.deepcopy(v, n-1)
            newT[i] = T
        else
            local x = v
            newT[i] = x
        end
    end
    return newT
end

function table.contains(t, item)
--[[	if type(t)== "number" then
		return t==item
	end--]]
	if t==nil then
		return false
	end
	for k,v in pairs(t) do
		if v==item then
			return true
		end
	end
	return false
end