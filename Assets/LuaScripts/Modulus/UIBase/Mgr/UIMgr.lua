UIMgr = { }

function UIMgr:init()
	--缓存UI
	self.openPool = { }
	self.closePool = { }
	--缓存ui关闭信息
	self.closeMap = { }
end 

function UIMgr:openUI(uiEnum,args)
	 --已经打开 return 
	if not uiEnum or self.openPool[uiEnum] then
		return 
	end 
	--在关闭池子里 return 
    if self.closePool[uiEnum] then 
       local ui = self.closePool[uiEnum]
       self.closePool[uiEnum] = nil 
       self.openPool[uiEnum] = ui 
       LuaExtend:setActive(ui.obj,true)
       ui:onOpen()
       return 
    end 
    --需要load
    local conf = UIInfo[uiEnum]
    if conf then 
    	local path = conf.path   
		ResExtend:loadObj(path,function(obj)  
			local className = conf.className
            if  _G[className] == nil then 
            	require (conf.class)
            end 
            local creator = _G[className]         
            local ui = creator(obj,conf,args)
            self.openPool[uiEnum] = ui 
            LuaExtend:setUINode(obj,conf.UINode)
            LuaExtend:setActive(ui.obj,true)
            ui:onOpen()
		end)
    end
end 

function UIMgr:onLoadUI()

end 

function UIMgr:closeUI(uiEnum)
   if self.openPool[uiEnum] then 
      local ui = self.openPool[uiEnum]
      self.openPool[uiEnum] = nil 
      ui:onClose()
      local isDestroy = ui.uiInfo and ui.uiInfo.isDestroy or false 
      if not isDestroy then 	      
	      self.closePool[uiEnum] = ui      
	      LuaExtend:setActive(ui.obj,false)
	  else
	  	  ui:onDispose()
      end
   end 
end 

function UIMgr:isOpen(uiEnum)
	return self.openPool[uiEnum] ~= nil 
end 

function UIMgr:onLoadScene()
	for k,v in pairs(self.openPool) do 
		v:onDispose()
	end 
	for k,v in pairs(self.closePool) do 
		v:onDispose()
	end 
	--缓存UI
	self.openPool = { }
	self.closePool = { }
	--缓存ui关闭信息
	self.closeMap = { }
end 

create(UIMgr)