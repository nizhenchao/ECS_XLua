LUIWidget = SimpleClass()

-- 初始化自身变量
local function _create_my_self(self)
   self.widgetType = nil 
end

function LUIWidget:__init(widgetObj,enum,...)
    -- 这里防止 子类不写__init 方法而导致重入
    if self._init ~= nil and self._init == true then
        return
    end
    _create_my_self(self)
    self._init = true
    self.widgetObj = widgetObj
    self.widgetType = enum 
    self.widget = self:getWidget()
end

function LUIWidget:getWidget()
    if self.widgetType then 
       if self.widgetType == UIWidget.LImage then 
          return self.widgetObj:GetComponent(CSImage)
       elseif self.widgetType == UIWidget.LButton then 
          return self.widgetObj:GetComponent(CSButton)
       elseif self.widgetType == UIWidget.LText then 
          return self.widgetObj:GetComponent(CSText)
       end 
    end     
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

function LUIWidget:setImage(name)

end 

function LUIWidget:setText(str)
    self.widget.text = str 
end 

function LUIWidget:onDispose()

end 