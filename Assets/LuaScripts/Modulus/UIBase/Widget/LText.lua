LText = SimpleClass(LUIWidget)

function LText:getWidget()
    return self.widgetObj:GetComponent(CSText) 
end 

--LText一些相关操作--todo
function LText:setText(str)
	if self.widget then 
       self.widget.text = tostring(str)
    end
end 