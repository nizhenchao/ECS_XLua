DataDictionary = SimpleClass()

function DataDictionary:__init(...)
    self.dict = { }
end

local function findValIdxByKey(self, _key)
    if self.dict ~= nil then
        for key, v in pairs(self.dict) do
            if v:getKey() and v:getKey() == _key then
                return key
            end
        end
    end

    return -1
end

function DataDictionary:getTable()
    return self.dict
end

-- dict:sort(Bind(self.sortFunc, self))
function DataDictionary:sort(sortFunc)
    if sortFunc and self.dict then
        table.sort(self.dict, sortFunc)
    end
end

-- 添加时不验证重复
function DataDictionary:add(_val)
    if _val then
        table.insert(self.dict, _val)
    end
end

-- 添加时验证是否有重复元素
function DataDictionary:addCheckRepeat(_val)
    local _key = _val and _val:getKey() or nil
    if not _key then
        return
    end

    local idx = findValIdxByKey(self, _key)
    if idx == -1 then
        self:add(_val)
    end
end

-- 添加时验证是否有重复元素,有则更新
function DataDictionary:updateCheckRepeat(_val)
    local _key = _val and _val:getKey() or nil
    if not _key then
        return
    end

    local idx = findValIdxByKey(self, _key)
    if idx == -1 then
        self:add(_val)
    else
        self.dict[idx] = _val
    end
end

function DataDictionary:get(key)
    local idx = findValIdxByKey(self, key)
    if idx ~= -1 then
        return self.dict[idx]
    end

    return nil
end

function DataDictionary:removeByKey(key)
    local idx = findValIdxByKey(self, key)
    if idx ~= -1 then
        table.remove(self.dict, idx)
    end
end

function DataDictionary:removeByVal(_val)
    local _key = _val and _val:getKey() or nil
    if not _key then
        return
    end

    self:removeByKey(_key)
end

function DataDictionary:clear()
    if not self.dict then
        return
    end

    for key, v in pairs(self.dict) do
        self.dict[key] = nil
    end

    self.dict = { }
end