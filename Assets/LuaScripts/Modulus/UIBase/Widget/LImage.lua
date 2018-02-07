LImage = SimpleClass(LUIWidget)

function LUIWidget:getWidget()
    return self.widgetObj:GetComponent(CSImage) 
end 

--Image一些相关操作--todo
function LImage:setImage(name)
    LuaExtend:setSprite(self:getObj(),name)
end 

function LImage:setNavSize()

end 