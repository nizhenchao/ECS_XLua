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
           --print("有技能需要释放 技能id "..v.castQueue:peek())
           print("有技能需要释放 技能id ")
        end 
    end 
end 

function LSkillSystem:disposeComp(comp)

end