
-- [Comment] 在hashTable的基础上增加了索引 排序一定要用自己的sort方法
-- HashList
-- edit by raodun
HashList = SimpleClass()

function HashList:__init(...)
    -- array
    self._keys = { }
    -- table
    self._values = { }
    --_keys 的反向
    self._index ={}
end

-- [Comment]
-- 判断是否存在
function HashList:containsKey(key)
    -- 为了避免循环，这里直接判断value值是不是为nil
    return self._values[key] ~= nil
end

-- [Comment]
-- 增加,如果有相同key直接替换（key,value不能为nil）
function HashList:add(key, value)
    if value and key then
        if not self:containsKey(key) then
            table.insert(self._keys, key)
            self._index[key]=#self._keys
        end
        self._values[key] = nil
        self._values[key] = value
    end
end

-- [Comment]
-- 获取，不存在返回 nil
function HashList:get(key)
    return self._values[key]
end
-- [Comment]
-- 获取长度
function HashList:size()
    return table.getn(self._keys)
end
-- [Comment]
-- 获取keys,可以用索引取对应位置的key
function HashList:getKeys()
    return self._keys
end

-- [Comment]
-- 跟据Key索引获取value值 从1开始
function HashList:getByIndex(index)
    return self._values[self._keys[index]]
end
-- [Comment]
-- 根据key找到 在 _keys 中的索引
function HashList:getIndex( key )
    return self._index[key]
end
-- [Comment]
-- 获取values,不可用索引获取value
function HashList:getValues()
    return self._values
end
-- [Comment]
-- 获取values,可以用索引获取对应位置的value
-- 不需要索引获取值 请使用getValues方法获取
function HashList:getArrValues()
    local rtn = { }
    local len = self:size()
    for i = 1, len do
        table.insert(rtn, self._values[self._keys[i]])
    end
    return rtn
end

-- [Comment]
-- 移除
function HashList:remove(key)
    if self:containsKey(key) then
        local pos = self._index[key]
        table.remove(self._keys, pos)
        self._index[key] = nil
        self._values[key] = nil
        --从移除的位置开始 后面的都必须改变
        for i=pos,#self._keys do
            self._index[self._keys[i]]=i
        end
    end
end

-- [Comment]
-- 移除所有
function HashList:clrean()
    self._values = { }
    self._keys = { }
    self._index = { }
end
--排序后 索引的位置都要重置
function HashList:sort(sortFun)
    table.sort( self._keys, sortFun )
    for i=1,#self._keys do
        self._index[self._keys[i]]=i
    end
end