BaseControl = SimpleClass()

-- 初始化参数列表
local function __create_self_param(self)
    self.__ui = nil
    -- 存储的UI句柄
    self.__eventMap = { }
    -- 存储的事件列表
    self.__isInit = false
    self.uiEnum = ''
    self.openUIEventName = ''
end

function BaseControl:__init(uiEnum,openCmd,closeCmd)
    if self.__isInit == true then
        return
    end
    self.__isInit = true
    __create_self_param(self)
    self.uiEnum = uiEnum
    self.openCmd = openCmd
    self.closeCmd = closeCmd
    self:__init_self()
    self:initUIEvent()
    self:initEvent()
end 

function BaseControl:__init_self()

end 

function BaseControl:initUIEvent()	
	if self.openCmd then 
       EventMgr:addListener(self.openCmd,Bind(self.openUI,self))
    end
    if self.closeCmd then 
    	EventMgr:addListener(self.closeCmd,Bind(self.openUI,self))
    end     
end 

function BaseControl:initEvent()

end 

function BaseControl:openUI(args)
    UIMgr:openUI(self.uiEnum,args)
end 

function BaseControl:closeUI()
	UIMgr:closeUI(self.uiEnum)
end 