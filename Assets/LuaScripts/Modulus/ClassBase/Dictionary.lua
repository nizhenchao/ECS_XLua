Dictionary = SimpleClass()

function Dictionary:__init(...)
    self.dict = { }
end

function Dictionary:getTable()
    return self.dict
end

local function FindItemIdxByKey(self, _key)
    if self.dict ~= nil then
        for key, v in pairs(self.dict) do
            if v.key == _key then
                return key
            end
        end
    end

    return -1
end

function Dictionary:add(_key, _val)
    local idx = FindItemIdxByKey(self, _key)
    if idx == -1 then
        table.insert(self.dict, { key = _key, val = _val })
    end
end

function Dictionary:get(key)
    local idx = FindItemIdxByKey(self, key)
    if idx ~= -1 then
        return self.dict[idx].val
    end

    return nil
end

function Dictionary:removeByKey(key)
    local idx = FindItemIdxByKey(self, key)
    if idx ~= -1 then
        self.dict[idx] = nil
        table.remove(self.dict, idx)
    end
end

function Dictionary:clear()
    if not self.dict then
        return
    end

    for key, v in pairs(self.dict) do
        local val = v.val
        if val ~= nil then
            local func = val['destroy']
            if func then
                val:destroy()
            end
        end
    end

    self.dict = nil
end

function Dictionary:hideAll()
    if not self.dict then
        return
    end

    for key, v in pairs(self.dict) do
        local val = v.val
        if val ~= nil then
            local func = val['active']
            if func then
                val:active(false)
            end
        end
    end
end