LButton = SimpleClass(LUIWidget)

function LButton:getWidget()
    return self.widgetObj:GetComponent(CSButton) 
end 

--LButton一些相关操作--todo