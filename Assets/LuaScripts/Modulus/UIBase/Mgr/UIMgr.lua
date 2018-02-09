UIMgr = { }

function UIMgr:init()
	--缓存UI
	self.openPool = { }
	self.closePool = { }
  --节点管理
  self.nodePool = { }
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
       ui:bindNode()
       ui:onOpen()
       return ui 
    end 
    --需要load
    local conf = UIInfo[uiEnum]
    if conf then 
        local className = conf.className
        if  _G[className] == nil then 
           require (conf.class)
        end 
        local creator = _G[className]         
        local ui = creator(conf,args)
        self.openPool[uiEnum] = ui 
        ui:loadUI(conf.path)
    end
end 

function UIMgr:closeUI(uiEnum)
   if self.openPool[uiEnum] then 
      local ui = self.openPool[uiEnum]
      self.openPool[uiEnum] = nil 
      local isCache = ui:onUIClose()
      if isCache then 
         self.closePool[uiEnum] = ui  
      end            
   end 
end 

--只对Main节点的UI进行了处理 扩展todo
function UIMgr:setNode(ui,node)
  if ui then 
     if node == UINode.UIMain then 
        local lst = self.nodePool[node]
        if lst then 
           for i = 1,#lst do 
               self:closeUI(lst[i].uiEnum)
           end 
           self.nodePool[node] = { }
        end 
     end 
     LuaExtend:setUINode(ui.obj,node)
     if self.nodePool[node] == nil then 
        self.nodePool[node] = { }
     end
     table.insert(self.nodePool[node],ui)
  end
end 

function UIMgr:closeNode(node)

end 

function UIMgr:closeNodeByFilter(filterLst)

end 

function UIMgr:isOpen(uiEnum)
	return self.openPool[uiEnum] ~= nil 
end 

function UIMgr:onLoadScene()
	for k,v in pairs(self.openPool) do 
		v:onUIClose()
	end 
	for k,v in pairs(self.closePool) do 
		v:onUIClose()
	end 
  --缓存UI
  self.openPool = { }
  self.closePool = { }
  --节点管理
  self.nodePool = { }
end 

create(UIMgr)