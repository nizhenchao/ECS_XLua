LUIWidget = SimpleClass()

-- 初始化自身变量
local function _create_my_self(self)
  
end

function LUIWidget:__init(widgetObj,...)
    -- 这里防止 子类不写__init 方法而导致重入
    if self._init ~= nil and self._init == true then
        return
    end
    _create_my_self(self)
    self._init = true
    self.widgetObj = widgetObj
    self.widget = self:getWidget()
end

--LUIWidget不带组件
function LUIWidget:getWidget()

end 

function LUIWidget:getObj()
   return self.widgetObj
end 

function LUIWidget:setPosition(x,y,z)

end 

function LUIWidget:setScale(x,y,z)
    
end 

function LUIWidget:setAngle(x,y,z)
    
end 

function LUIWidget:onDispose()

end 