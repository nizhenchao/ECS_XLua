BottomSkillControl = SimpleClass(BaseControl)

local baseType = 1
local norType = 2
local supType = 3
function BottomSkillControl:__init(...)
    self.vo = SkillUIVO()
end 

function BottomSkillControl:__init_self()

end 

function BottomSkillControl:initEvent()
	EventMgr:addListener(MainCmd.On_Create_Main_Player,Bind(self.onCreateMainPlayer,self))
	EventMgr:addListener(MainCmd.On_Destroy_Main_Player,Bind(self.onDestroyMainPlayer,self))	

	EventMgr:addListener(BottomSkillCmd.On_Cast_Skill,Bind(self.onCastSkill,self))	
	EventMgr:addListener(BottomSkillCmd.On_Cast_Skill_Finish,Bind(self.onCastSkillFinish,self))	
end 

function BottomSkillControl:onCastSkill(id)
   local player = EntityMgr:getMainEntity()
   if player then 
   	  player:updateComp(LCompType.Skill,id)
   end 
end 

function BottomSkillControl:onCastSkillFinish(uid,id)
    if not id or not uid then 
    	return 
    end 
    local isMian = EntityMgr:isMainPlayer(uid)
    if isMian then 
	    self.vo:updateSkillCd(id)	   
	    self:updateUI()
    end
end 

function BottomSkillControl:onCreateMainPlayer(entity)
   if entity then 
   	  --print("entity uid "..entity.uid)
   	  local comp = entity:getComp(LCompType.Skill)
   	  local skillDict = comp:getArgs()
   	  skillDict = skillDict:getValues()
   	  local base = nil 
   	  local norLst = { }
   	  local supLst = { }
   	  for k,v in pairs(skillDict) do    	  	
   	  	  local dt = SkillItemData(v)
          local type = dt:getType()
          if type == baseType then 
              base = dt 
          elseif type == norType then 
              table.insert(norLst,dt)
          elseif type == supType then 
              table.insert(supLst,dt)
          end 
   	  end 
   	  self.vo:update(base,norLst,supLst)
   	  self:openUI()   	  
   else
   	  print("function BottomSkillControl:onCreateMainPlayer(entity)")
   end 
end 

function BottomSkillControl:onDestroyMainPlayer()
   self:closeUI()
end 

function BottomSkillControl:clearSelf()

end 

--Control ClassName--uiEnum--openUI EventCmd--closeUI EventCmd
Register('BottomSkillControl',UIEnum.BottomSkillUI,BottomSkillCmd.On_Open_UI,BottomSkillCmd.On_Close_UI)