LSkillSystem = SimpleClass(LSystem)

function LSkillSystem:__init_self()
    self.subscibe = LCompType.Skill
end 

function LSkillSystem:__init()

end 

function LSkillSystem:onUpdate(lst)
    for k,v in pairs(lst) do 
        local isNeed = v:isNeedUpdate()
        if isNeed then            
           local entity = EntityMgr:getEntity(v:getUid())
           if entity then 
               local skillConf = ConfigHelper:getConfigByKey('SkillConfig',v.castQueue)
               if skillConf then 
                  print("有技能需要释放animName "..skillConf.animName)
                  entity:updateComp(LCompType.Animator,skillConf.animName,true)
                  entity:updateComp(LCompType.Skill,-1)
                  EventMgr:sendMsg(BottomSkillCmd.On_Cast_Skill_Finish,entity.uid,skillConf.id)
               end              
           end
        end 
    end 
end 

function LSkillSystem:disposeComp(comp)

end