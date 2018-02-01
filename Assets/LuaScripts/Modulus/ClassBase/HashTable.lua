
-- [Comment]
-- HashTable
-- edit by cjh
HashTable = SimpleClass()

function HashTable:__init(...)
    self._keys = { }
    -- array
    self._values = { }
    -- table	
end

-- [Comment]
-- 判断是否存在
function HashTable:containsKey(key)
    -- 为了避免循环，这里直接判断value值是不是为nil
    return self._values[key] ~= nil
end

-- [Comment]
-- 增加,如果有相同key直接替换（key,value不能为nil）
function HashTable:add(key, value)
    if value and key then
        if not self:containsKey(key) then
            table.insert(self._keys, key)
        end
        self._values[key] = nil
        self._values[key] = value
    end
end

-- [Comment]
-- 获取，不存在返回 nil
function HashTable:get(key)
    return self._values[key]
end
-- [Comment]
-- 获取长度
function HashTable:size()
    return table.getn(self._keys)
end
-- [Comment]
-- 获取keys,可以用索引取对应位置的key
function HashTable:getKeys()
    return self._keys
end

-- [Comment]
-- 跟据Key索引获取value值 从1开始
function HashTable:getByIndex(index)
    return self._values[self._keys[index]]
end

-- [Comment]
-- 获取values,不可用索引获取value
function HashTable:getValues()
    return self._values
end
-- [Comment]
-- 获取values,可以用索引获取对应位置的value
-- 不需要索引获取值 请使用getValues方法获取
function HashTable:getArrValues()
    local rtn = { }
    local len = self:size()
    for i = 1, len do
        table.insert(rtn, self._values[self._keys[i]])
    end
    return rtn
end
-- [Comment]
--变成table
function HashTable:getTable()
    local rtn = { }
    local len = self:size()
    for i=1,len do
        local key = self._keys[i]
        local value = self._values[key]
        rtn[key]=value
    end
    return rtn
end
-- [Comment]
-- 移除
function HashTable:remove(key)
    if self:containsKey(key) then
        for i = #self._keys, 1, -1 do
            if self._keys[i] == key then
                table.remove(self._keys, i)
                self._values[key] = nil
                return
            end
        end
    end
end

-- [Comment]
-- 移除所有
function HashTable:clrean()
    for i = #self._keys, 1, -1 do
        self._values[self._keys[i]] = nil
        self._keys[i] = nil
    end
    self._values = { }
    self._keys = { }
end